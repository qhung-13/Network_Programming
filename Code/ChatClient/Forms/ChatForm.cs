using System.ComponentModel;
using System.Media;
using System.Text.Json;
using System.Linq.Expressions;
using System.Security.Policy;
using ChatClient.Core;
using ChatClient.Services;
using ChatShared;
using ChatShared.Models;
using ChatShared.Protocol;
using Message = ChatShared.Models.Message;

namespace ChatClient.Forms
{
    [DesignerCategory("Form")]
    public partial class ChatForm : Form
    {
        #region Fields & Properties

        // Stores message history per room to maintain context when switching tabs
        private readonly Dictionary<string, List<(string username, string content, DateTime time, bool isSystem, string? replyToUsername, string? replyToContent, bool isForwarded)>> _messageHistory = new();
        private readonly Dictionary<string, Panel> _roomPanels = new();
        private readonly HashSet<string> _joinedRooms = new();

        private readonly TcpClientService _client;
        private readonly ClientSettingsService _settingsService = new();

        private readonly string _userId;
        private string _displayName;

        // Navigation and state tracking
        private string _currentRoom = "general";
        private string? _pendingJoinRoom = null;
        private string? _previousRoomBeforeJoin = null;
        private DateTime _sessionStartTime;

        // Reply mechanism state
        private string? _replyToUsername = null;
        private string? _replyToContent = null;
        private Panel? _replyPreviewPanel = null;

        // System tray notification component
        private NotifyIcon? _notifyIcon;

        #endregion

        #region Constructor & Initialization

        public ChatForm(TcpClientService client, string userId, string displayName)
        {
            InitializeComponent();
            _client = client;
            _userId = userId;
            _displayName = displayName;
        }

        private void SetupNotification()
        {
            _notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application,
                Visible = true,
                Text = "ChatApp",
            };
        }

        private async void ChatForm_Load(object sender, EventArgs e)
        {
            _sessionStartTime = DateTime.Now;
            _joinedRooms.Add(_currentRoom);

            // Initialize user profile UI
            lblNameOnline.Text = _displayName;
            lblQH.Text = GetInitials(_displayName);
            SetupNotification();

            // Bind network events
            _client.OnMessageReceived += OnMessageReceived;
            _client.OnDisconnected += OnDisconnected;

            // Fetch initial server state
            await _client.RequestRoomListAsync();
            await _client.RequestRoomHistoryAsync(_currentRoom);

            // Bind UI input events
            btnSend.Click += btnSend_Click;
            textBox1.KeyDown += textBox1_KeyDown;

            // Bind room navigation clicks
            panel5.Click += (s, e) => JoinRoom("general");
            lblgeneral.Click += (s, e) => JoinRoom("general");
            panel6.Click += (s, e) => JoinRoom("random");
            lblrandom.Click += (s, e) => JoinRoom("random");
            panel7.Click += (s, e) => JoinRoom("gaming");
            label2.Click += (s, e) => JoinRoom("gaming");
            panel8.Click += (s, e) => JoinRoom("study");
            lblstudy.Click += (s, e) => JoinRoom("study");

            // Configure layout properties
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            panel3.AutoScroll = true;

            // Setup settings modal interaction
            btnSettings1.Click += async (s, e) =>
            {
                using var settingsForm = new SettingsForm();
                var result = settingsForm.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    var settings = _settingsService.Load();
                    string newDisplayName = settings.Username.Trim();

                    if (string.IsNullOrWhiteSpace(newDisplayName))
                        return;

                    _displayName = newDisplayName;
                    lblNameOnline.Text = newDisplayName;
                    lblQH.Text = GetInitials(newDisplayName);

                    // Sync display name with server and refresh history
                    await _client.UpdateDisplayNameAsync(_userId, newDisplayName);
                    await _client.RequestRoomHistoryAsync(_currentRoom);
                }
            };

            // Set initial UI state
            HighlightRoom("general");
            AddSystemMessage("Đã kết nối thành công!");
            ClientLogger.Log($"CONNECTED - DisplayName={_displayName}, Room={_currentRoom}");
        }

        #endregion

        #region Network Event Handlers

        /// <summary>
        /// Main dispatcher for incoming network messages. 
        /// Ensures UI updates are marshalled back to the main thread.
        /// </summary>
        private void OnMessageReceived(Message msg)
        {
            // Ensure thread safety when updating UI controls from background network thread
            if (InvokeRequired)
            {
                BeginInvoke(() => OnMessageReceived(msg));
                return;
            }

            switch (msg.Type)
            {
                case MessageType.Chat:
                    {
                        var roomName = NormalizeRoomName(msg.Room);
                        var senderName = string.IsNullOrWhiteSpace(msg.DisplayName) ? msg.Username : msg.DisplayName;

                        ShowNewMessageNotification(msg, senderName, roomName);
                        ClientLogger.Log($"RECEIVE - Room=#{roomName}, User={senderName}, Content=\"{msg.Content}\"");

                        if (!_messageHistory.ContainsKey(roomName))
                            _messageHistory[roomName] = new();

                        // Persist message to local memory state
                        _messageHistory[roomName].Add((
                            senderName,
                            msg.Content,
                            msg.Time,
                            false,
                            msg.ReplyToUsername,
                            msg.ReplyToContent,
                            msg.IsForwarded
                        ));

                        // Render immediately if the message belongs to the currently active room
                        if (roomName == _currentRoom)
                        {
                            RenderChatMessage(
                                senderName,
                                msg.Content,
                                msg.Time,
                                msg.ReplyToUsername,
                                msg.ReplyToContent,
                                msg.IsForwarded
                            );
                        }
                        break;
                    }

                case MessageType.Join:
                    {
                        string joinedRoom = NormalizeRoomName(msg.Room);

                        // Finalize room transition if this confirms a pending join request
                        if (!string.IsNullOrWhiteSpace(_pendingJoinRoom) &&
                            joinedRoom == _pendingJoinRoom &&
                            msg.Username == _userId)
                        {
                            ConfirmRoomSwitch(joinedRoom);
                        }

                        if (joinedRoom == _currentRoom && !string.IsNullOrWhiteSpace(msg.Content))
                        {
                            AddSystemMessage(msg.Content);
                        }

                        UpdateOnlineList();
                        break;
                    }

                case MessageType.Leave:
                    {
                        string leftRoom = NormalizeRoomName(msg.Room);

                        if (leftRoom == _currentRoom && !string.IsNullOrWhiteSpace(msg.Content))
                        {
                            AddSystemMessage(msg.Content);
                        }

                        UpdateOnlineList();
                        break;
                    }

                case MessageType.GetRooms:
                    try
                    {
                        var rooms = JsonSerializer.Deserialize<List<Room>>(msg.Content ?? "");
                        if (rooms != null)
                        {
                            RenderRoomList(rooms);
                        }
                    }
                    catch
                    {
                        AddSystemMessage("Không thể tải danh sách phòng");
                    }
                    break;

                case MessageType.RoomUsers:
                    {
                        var roomName = NormalizeRoomName(msg.Room);

                        if (roomName == _currentRoom)
                        {
                            var users = JsonSerializer.Deserialize<List<User>>(msg.Content ?? "[]");
                            if (users != null)
                            {
                                UpdateRoomUsers(users);
                            }
                        }
                        break;
                    }

                case MessageType.RoomHistory:
                    {
                        try
                        {
                            string roomName = NormalizeRoomName(msg.Room);

                            var messages = JsonSerializer.Deserialize<List<Message>>(msg.Content ?? "[]")
                                ?? new List<Message>();

                            _messageHistory[roomName] = messages.Select(m => (
                                username: string.IsNullOrWhiteSpace(m.DisplayName) ? m.Username : m.DisplayName,
                                content: m.Content,
                                time: m.Time,
                                isSystem: false,
                                replyToUsername: m.ReplyToUsername,
                                replyToContent: m.ReplyToContent,
                                isForwarded: m.IsForwarded
                            )).ToList();

                            if (!string.IsNullOrWhiteSpace(_pendingJoinRoom) && roomName == _pendingJoinRoom)
                            {
                                ConfirmRoomSwitch(roomName);
                            }

                            if (roomName == _currentRoom)
                            {
                                RenderRoomHistory(roomName);
                            }
                        }
                        catch
                        {
                            AddSystemMessage("Không thể tải lịch sử tin nhắn");
                        }
                        break;
                    }

                case MessageType.Error:
                    HandleServerError(msg);
                    break;
            }
        }

        private void OnDisconnected()
        {
            if (InvokeRequired)
            {
                BeginInvoke(OnDisconnected);
                return;
            }

            ClientLogger.Log("DISCONNECTED - Lost connection to server");
            MessageBox.Show("Mất kết nối với server!", "Ngắt kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Close();
        }

        #endregion

        #region Outgoing Actions

        private async void btnSend_Click(object sender, EventArgs e) => await SendMessage();

        private async void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // Intercept Enter key to trigger send action without adding a newline
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await SendMessage();
            }
        }

        private async Task SendMessage()
        {
            string content = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(content)) return;

            content = EmojiHelper.Parse(content);
            textBox1.Clear();

            var msg = new Message
            {
                Type = MessageType.Chat,
                Username = _userId,
                DisplayName = _displayName,
                Room = _currentRoom,
                Content = content,
                Time = DateTime.Now,
                ReplyToUsername = _replyToUsername,
                ReplyToContent = _replyToContent,
            };

            await _client.SendMessageDirectAsync(msg);
            ClientLogger.Log($"SEND - Room=#{_currentRoom}, User={_displayName}, Content=\"{content}\"");

            // Reset reply state after sending
            CancelReply();

            var settings = _settingsService.Load();
            settings.MessagesSent++;
            _settingsService.Save(settings);
        }

        private async void JoinRoom(string roomName)
        {
            roomName = NormalizeRoomName(roomName);
            if (roomName == _currentRoom) return;

            _previousRoomBeforeJoin = _currentRoom;
            _pendingJoinRoom = roomName;

            label1.Text = "# " + roomName;
            HighlightRoom(roomName);

            flowLayoutPanel1.Controls.Clear();
            RenderSystemMessage($"Đang vào phòng #{roomName}...");

            await _client.JoinRoomAsync(_userId, roomName);
        }

        private void ConfirmRoomSwitch(string roomName)
        {
            roomName = NormalizeRoomName(roomName);

            _currentRoom = roomName;
            label1.Text = "# " + roomName;
            HighlightRoom(roomName);

            if (_joinedRooms.Add(roomName))
            {
                var settings = _settingsService.Load();
                settings.RoomsJoined = _joinedRooms.Count;
                _settingsService.Save(settings);
            }

            _pendingJoinRoom = null;
            _previousRoomBeforeJoin = null;
        }

        private async void btnCreateNewRoom_Click_1(object sender, EventArgs e)
        {
            using var form = new CreateNewRoom();

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                var room = new Room
                {
                    RoomName = form._roomName,
                    Description = form._roomDescription,
                    MaxMembers = form._memberLimit,
                    CurrentMembers = 0,
                    CreatedAt = DateTime.Now
                };

                await _client.CreateRoomAsync(_userId, room);
                await _client.RequestRoomListAsync();

                AddSystemMessage($"Đã tạo phòng #{room.RoomName}");
                ClientLogger.Log($"CREATE ROOM - #{room.RoomName}, Description=\"{room.Description}\", MaxMembers={room.MaxMembers}");
            }
        }

        private async void ForwardMessage(string originalUsername, string content)
        {
            // Retrieve available rooms excluding the current one
            var rooms = _roomPanels.Keys.Where(r => NormalizeRoomName(r) != _currentRoom).OrderBy(r => r).ToArray();

            if (rooms.Length == 0)
            {
                MessageBox.Show("Không có phòng khác để chuyển tiếp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Build dynamic forwarding dialog
            using var dialog = new Form
            {
                Text = "Chuyển tiếp đến phòng",
                Size = new Size(280, 200),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var lbl = new Label { Text = "Chọn phòng muốn chuyển tiếp:", Location = new Point(15, 15), AutoSize = true };
            var listBox = new ListBox { Location = new Point(15, 40), Size = new Size(240, 80) };
            listBox.Items.AddRange(rooms);
            listBox.SelectedIndex = 0;

            var btnOk = new Button
            {
                Text = "Chuyển tiếp",
                Location = new Point(15, 130),
                Size = new Size(110, 30),
                BackColor = Color.FromArgb(83, 74, 183),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                DialogResult = DialogResult.OK
            };

            var btnCancel = new Button
            {
                Text = "Hủy",
                Location = new Point(135, 130),
                Size = new Size(80, 30),
                DialogResult = DialogResult.Cancel
            };

            dialog.Controls.AddRange(new Control[] { lbl, listBox, btnOk, btnCancel });
            dialog.AcceptButton = btnOk;

            if (dialog.ShowDialog() == DialogResult.OK && listBox.SelectedItem != null)
            {
                string targetRoom = listBox.SelectedItem.ToString()!;

                var msg = new Message
                {
                    Type = MessageType.Chat,
                    Username = _userId,
                    DisplayName = _displayName,
                    Room = targetRoom,
                    Content = content,
                    Time = DateTime.Now,
                    IsForwarded = true,
                    ReplyToUsername = originalUsername,
                    ReplyToContent = content
                };

                await _client.SendMessageDirectAsync(msg);
                ClientLogger.Log($"FORWARD - From={originalUsername}, ToRoom=#{targetRoom}, Content=\"{content}\"");

                // Inject forward record into target room's local history
                if (!_messageHistory.ContainsKey(targetRoom))
                    _messageHistory[targetRoom] = new();

                _messageHistory[targetRoom].Add((_displayName, content, DateTime.Now, false, originalUsername, content, true));

                AddSystemMessage($"Đã chuyển tiếp tin nhắn tới #{targetRoom}");
            }
        }

        #endregion

        #region UI Rendering & State Updates

        private void HighlightRoom(string roomName)
        {
            roomName = NormalizeRoomName(roomName);
            foreach (var panel in _roomPanels.Values)
            {
                panel.BackColor = Color.Transparent;
            }

            if (_roomPanels.TryGetValue(roomName, out var selectedPanel))
            {
                selectedPanel.BackColor = Color.DodgerBlue;
            }
        }

        private void AddChatMessage(string username, string content, DateTime time, string? replyToUsername = null, string? replyToContent = null, bool isForwarded = false)
        {
            if (!_messageHistory.ContainsKey(_currentRoom))
                _messageHistory[_currentRoom] = new();

            _messageHistory[_currentRoom].Add((username, content, time, false, replyToUsername, replyToContent, isForwarded));
            RenderChatMessage(username, content, time, replyToUsername, replyToContent, isForwarded);
        }

        private void AddSystemMessage(string content)
        {
            if (!_messageHistory.ContainsKey(_currentRoom))
                _messageHistory[_currentRoom] = new();

            _messageHistory[_currentRoom].Add(("", content, DateTime.Now, true, null, null, false));
            RenderSystemMessage(content);
        }

        private void UpdateOnlineList()
        {
            // Sync UI counter with the actual generated control count
            lblSLOnline.Text = $"- {flowLayoutPanel2.Controls.Count} users online";
        }

        private void RenderChatMessage(string username, string content, DateTime time, string? replyToUsername = null, string? replyToContent = null, bool isForwarded = false)
        {
            var msgPanel = new Panel
            {
                Width = flowLayoutPanel1.ClientSize.Width - 20,
                Margin = new Padding(5, 5, 5, 0),
                BackColor = Color.White,
                Padding = new Padding(8)
            };

            int yOffset = 8;

            // Generate deterministic avatar
            var avatar = new Label
            {
                Text = GetInitials(username),
                Size = new Size(36, 36),
                Location = new Point(8, 12),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = GetAvatarColor(username),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold)
            };

            // Meta information (Name & Timestamp)
            var lblMeta = new Label
            {
                Text = isForwarded ? $"{username} đã chuyển tiếp {time:HH:mm}" : $"{username} {time:HH:mm}",
                Location = new Point(52, yOffset),
                AutoSize = true,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = isForwarded ? Color.FromArgb(83, 74, 183) : Color.Black
            };

            yOffset += 28;

            // Optional: Render reply block quote
            if (!string.IsNullOrEmpty(replyToUsername))
            {
                var replyBar = new Panel
                {
                    Location = new Point(48, yOffset),
                    Width = msgPanel.Width - 70,
                    Height = 28,
                    BackColor = Color.FromArgb(235, 235, 245)
                };

                var replyLine = new Panel
                {
                    Width = 3,
                    Dock = DockStyle.Left,
                    BackColor = Color.FromArgb(83, 74, 183)
                };

                var replyText = new Label
                {
                    Text = $"{replyToUsername}: {(replyToContent?.Length > 40 ? replyToContent[..40] + "..." : replyToContent)}",
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 8f, FontStyle.Italic),
                    ForeColor = Color.FromArgb(83, 74, 183),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(6, 0, 0, 0)
                };

                replyBar.Controls.Add(replyText);
                replyBar.Controls.Add(replyLine);
                msgPanel.Controls.Add(replyBar);

                yOffset += 32;
            }

            // Message Body
            var lblContent = new Label
            {
                // Note: Retaining original sequence where formatting might be overwritten
                Text = ChatShared.EmojiHelper.Parse(content)
            };
            lblContent.Text = content;
            lblContent.Location = new Point(52, yOffset);
            lblContent.AutoSize = true;
            lblContent.Font = new Font("Segoe UI", 9f);
            lblContent.ForeColor = Color.DimGray;
            lblContent.MaximumSize = new Size(msgPanel.Width - 120, 0);

            msgPanel.Controls.Add(lblContent);
            yOffset += lblContent.Height + 8;

            // Interaction buttons
            var btnReply = new Button
            {
                Text = "Reply",
                Location = new Point(48, yOffset),
                Size = new Size(65, 22),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8f),
                ForeColor = Color.Gray,
                BackColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnReply.FlatAppearance.BorderSize = 1;
            btnReply.FlatAppearance.BorderColor = Color.LightGray;
            btnReply.Click += (s, e) => ShowReplyPreview(username, content);

            var btnForward = new Button
            {
                Text = "Forward",
                Location = new Point(120, yOffset),
                Size = new Size(75, 22),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8f),
                ForeColor = Color.Gray,
                BackColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnForward.FlatAppearance.BorderSize = 1;
            btnForward.FlatAppearance.BorderColor = Color.LightGray;
            btnForward.Click += (s, e) => ForwardMessage(username, content);

            msgPanel.Controls.AddRange(new Control[] { avatar, lblMeta, btnReply, btnForward });
            msgPanel.Height = yOffset + 30;

            flowLayoutPanel1.Controls.Add(msgPanel);
            flowLayoutPanel1.ScrollControlIntoView(msgPanel);
        }

        private void RenderSystemMessage(string content)
        {
            var lbl = new Label
            {
                Text = "[HỆ THỐNG] " + content,
                AutoSize = false,
                Width = flowLayoutPanel1.ClientSize.Width - 20,
                Height = 24,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 8f, FontStyle.Italic),
                Margin = new Padding(5, 3, 5, 0)
            };

            flowLayoutPanel1.Controls.Add(lbl);
            flowLayoutPanel1.ScrollControlIntoView(lbl);
        }

        private void RenderRoomList(List<Room> rooms)
        {
            panel3.SuspendLayout();
            panel3.Controls.Clear();
            _roomPanels.Clear();
            panel3.AutoScroll = true;

            lblChatRoom.Dock = DockStyle.None;
            lblChatRoom.Location = new Point(0, 0);
            lblChatRoom.Height = 24;
            lblChatRoom.Width = panel3.Width;
            lblChatRoom.ForeColor = Color.White;
            panel3.Controls.Add(lblChatRoom);

            int y = 30;

            foreach (var room in rooms)
            {
                string roomName = NormalizeRoomName(room.RoomName);

                var roomPanel = new Panel
                {
                    Size = new Size(panel3.ClientSize.Width - 20, 29),
                    Location = new Point(6, y),
                    BackColor = roomName == _currentRoom ? Color.DodgerBlue : Color.Transparent,
                    Cursor = Cursors.Hand,
                    Tag = roomName
                };

                var lblRoom = new Label
                {
                    Text = "# " + roomName,
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    ForeColor = Color.White,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Cursor = Cursors.Hand,
                    Padding = new Padding(4, 0, 0, 0)
                };

                roomPanel.Controls.Add(lblRoom);

                roomPanel.Click += (s, e) => JoinRoom(roomName);
                lblRoom.Click += (s, e) => JoinRoom(roomName);

                panel3.Controls.Add(roomPanel);
                _roomPanels[roomName] = roomPanel;

                y += 35;
            }

            panel3.AutoScrollMinSize = new Size(0, y + 10);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel3.Invalidate();
        }

        private void RenderRoomHistory(string roomName)
        {
            roomName = NormalizeRoomName(roomName);
            flowLayoutPanel1.Controls.Clear();

            if (!_messageHistory.TryGetValue(roomName, out var history) || history.Count == 0)
            {
                RenderSystemMessage($"Phòng #{roomName} chưa có tin nhắn.");
                return;
            }

            foreach (var (username, content, time, isSystem, replyToUsername, replyToContent, isForwarded) in history)
            {
                if (isSystem)
                    RenderSystemMessage(content);
                else
                    RenderChatMessage(username, content, time, replyToUsername, replyToContent, isForwarded);
            }
        }

        private void ShowReplyPreview(string username, string content)
        {
            _replyToUsername = username;
            _replyToContent = content;

            if (_replyPreviewPanel != null)
            {
                panel12.Controls.Remove(_replyPreviewPanel);
                _replyPreviewPanel.Dispose();
            }

            // Construct floating reply preview indicator above input field
            _replyPreviewPanel = new Panel
            {
                Height = 36,
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(235, 235, 235),
                Padding = new Padding(10, 0, 10, 0)
            };

            var lblReply = new Label
            {
                Text = $"Đang trả lời {username}: {(content.Length > 40 ? content[..40] + "..." : content)}",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9f, FontStyle.Italic),
                ForeColor = Color.FromArgb(83, 74, 183),
                TextAlign = ContentAlignment.MiddleLeft
            };

            var btnCancel = new Button
            {
                Text = "X",
                Dock = DockStyle.Right,
                Width = 30,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Gray
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => CancelReply();

            _replyPreviewPanel.Controls.Add(lblReply);
            _replyPreviewPanel.Controls.Add(btnCancel);

            this.Controls.Add(_replyPreviewPanel);
            _replyPreviewPanel.BringToFront();
            panel12.BringToFront();
        }

        private void CancelReply()
        {
            _replyToUsername = null;
            _replyToContent = null;

            if (_replyPreviewPanel != null)
            {
                panel12.Controls.Remove(_replyPreviewPanel);
                _replyPreviewPanel.Dispose();
                _replyPreviewPanel = null;
            }
        }

        private void UpdateRoomUsers(List<User> users)
        {
            lblSLOnline.Text = $"- {users.Count} users online";
            flowLayoutPanel2.Controls.Clear();

            foreach (var user in users)
            {
                string displayName = string.IsNullOrWhiteSpace(user.DisplayName) ? user.Username : user.DisplayName;

                var userPanel = new Panel
                {
                    Width = flowLayoutPanel2.ClientSize.Width - 10,
                    Height = 30,
                    Margin = new Padding(3, 2, 3, 0)
                };

                var avatar = new Label
                {
                    Text = GetInitials(displayName),
                    Size = new Size(22, 22),
                    Location = new Point(4, 4),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = GetAvatarColor(user.Username),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 7f, FontStyle.Bold)
                };

                var dot = new Label
                {
                    Text = "●",
                    ForeColor = Color.LimeGreen,
                    Font = new Font("Segoe UI", 7f),
                    AutoSize = true,
                    Location = new Point(28, 8)
                };

                var lblName = new Label
                {
                    Text = displayName,
                    Location = new Point(42, 7),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9f),
                    ForeColor = Color.White
                };

                userPanel.Controls.AddRange(new Control[] { avatar, dot, lblName });
                flowLayoutPanel2.Controls.Add(userPanel);
            }
        }

        private void ShowNewMessageNotification(Message msg, string senderName, string roomName)
        {
            // Suppress echo notifications
            if (msg.Username == _userId)
                return;

            var settings = _settingsService.Load();

            if (settings.EnableSound)
            {
                try { SystemSounds.Asterisk.Play(); } catch { /* Ignore playback errors */ }
            }

            if (settings.EnableNotifications && _notifyIcon != null)
            {
                string content = msg.Content.Length > 80 ? msg.Content[..80] + "..." : msg.Content;

                _notifyIcon.BalloonTipTitle = $"Tin nhắn mới từ {senderName}";
                _notifyIcon.BalloonTipText = $"#{roomName}: {content}";
                _notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                _notifyIcon.ShowBalloonTip(3000);
            }
        }

        private void lbUsers_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Background
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(18, 17, 31)), e.Bounds);

            // Circular Avatar
            var colors = new[] {
                Color.FromArgb(83,74,183),   // purple
                Color.FromArgb(15,110,86),   // green
                Color.FromArgb(186,117,23),  // yellow
                Color.FromArgb(153,53,86)    // pink
            };

            var avatarColor = colors[e.Index % colors.Length];
            var avatarRect = new Rectangle(e.Bounds.X + 8, e.Bounds.Y + 5, 26, 26);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.FillEllipse(new SolidBrush(avatarColor), avatarRect);

            // Online status indicator dot
            e.Graphics.FillEllipse(Brushes.LimeGreen, e.Bounds.Right - 16, e.Bounds.Y + 13, 8, 8);
        }

        #endregion

        #region Helpers & Cleanup

        private string GetInitials(string name)
        {
            var parts = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 2)
                return $"{parts[0][0]}{parts[^1][0]}".ToUpper();

            return name.Length >= 2 ? name[..2].ToUpper() : name.ToUpper();
        }

        private Color GetAvatarColor(string username)
        {
            var colors = new[]
            {
                Color.FromArgb(83, 74, 183),
                Color.FromArgb(15, 110, 86),
                Color.FromArgb(186, 117, 23),
                Color.FromArgb(153, 53, 86),
                Color.FromArgb(56, 138, 221)
            };
            return colors[Math.Abs(username.GetHashCode()) % colors.Length];
        }

        private string NormalizeRoomName(string roomName)
        {
            return roomName.Trim().TrimStart('#').ToLower();
        }

        private void HandleServerError(Message msg)
        {
            string errorRoom = NormalizeRoomName(msg.Room);
            string errorContent = string.IsNullOrWhiteSpace(msg.Content) ? "Có lỗi xảy ra từ server." : msg.Content;

            // Rollback UI state if room join fails
            if (!string.IsNullOrWhiteSpace(_pendingJoinRoom) && errorRoom == _pendingJoinRoom)
            {
                string fallbackRoom = string.IsNullOrWhiteSpace(_previousRoomBeforeJoin) ? "general" : _previousRoomBeforeJoin;

                _currentRoom = fallbackRoom;
                label1.Text = "# " + fallbackRoom;
                HighlightRoom(fallbackRoom);

                flowLayoutPanel1.Controls.Clear();
                RenderRoomHistory(fallbackRoom);

                _pendingJoinRoom = null;
                _previousRoomBeforeJoin = null;
            }

            AddSystemMessage(errorContent);

            MessageBox.Show(errorContent, "Không thể vào phòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ClientLogger.Log($"SERVER ERROR - {errorContent}");
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Flush session analytics
            var settings = _settingsService.Load();
            var sessionSeconds = (long)(DateTime.Now - _sessionStartTime).TotalSeconds;
            settings.TotalOnlineSeconds += sessionSeconds;
            _settingsService.Save(settings);

            // Teardown network connections and tray icons
            _client.OnMessageReceived -= OnMessageReceived;
            _client.OnDisconnected -= OnDisconnected;
            _client.Disconnect();

            if (_notifyIcon != null)
            {
                _notifyIcon.Visible = false;
                _notifyIcon.Dispose();
                _notifyIcon = null;
            }

            base.OnFormClosed(e);
        }

        #endregion

        #region Unused / Designer Event Handlers
        // Note: Retained to prevent WinForms designer file (.Designer.cs) from throwing missing method errors.

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e) { }
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e) { }
        private void splitContainer1_Panel1_Paint_1(object sender, PaintEventArgs e) { }
        private void pnlUser_Paint(object sender, PaintEventArgs e) { }
        private void lbRooms_SelectedIndexChanged(object sender, EventArgs e) { }
        private void pnlInput_Paint(object sender, PaintEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void rtbChat_TextChanged(object sender, EventArgs e) { }
        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblNameOnline_Click(object sender, EventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void panel8_Paint(object sender, PaintEventArgs e) { }
        private void panel9_Paint(object sender, PaintEventArgs e) { }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e) { }
        private void btnCreateNewRoom_Click(object sender, EventArgs e) { }
        private void panel5_Paint(object sender, PaintEventArgs e) { }
        private void lblChatRoom_Click(object sender, EventArgs e) { }

        #endregion
    }
}