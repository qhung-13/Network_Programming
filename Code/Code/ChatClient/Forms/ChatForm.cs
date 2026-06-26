using System.ComponentModel;
using ChatClient.Core;
using ChatClient.Services;
using ChatShared;
using ChatShared.Models;
using ChatShared.Protocol;
using Message = ChatShared.Models.Message;
using System.Text.Json;
using System.Linq.Expressions;
using System.Security.Policy;

namespace ChatClient.Forms
{
    [DesignerCategory("Form")]
    public partial class ChatForm : Form
    {
        private readonly Dictionary<string, List<(string username, string content, DateTime time, bool isSystem, string? replyToUsername, string? replyToContent, bool isForwarded)>> _messageHistory = new();
        private readonly TcpClientService _client;
        private string _username;
        private string _currentRoom = "general";
        private string? _replyToUsername = null;
        private string? _replyToContent = null;
        private Panel? _replyPreviewPanel = null;
        private readonly Dictionary<string, Panel> _roomPanels = new();
        private readonly ClientSettingsService _settingsService = new();
        private DateTime _sessionStartTime;
        private readonly HashSet<string> _joinedRooms = new();

        public ChatForm(TcpClientService client, string username)
        {
            InitializeComponent();
            _client = client;
            _username = username;
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            _sessionStartTime = DateTime.Now;
            _joinedRooms.Add(_currentRoom);

            // Hiển thị tên user
            lblNameOnline.Text = _username;
            lblQH.Text = GetInitials(_username);

            // Gán sự kiện nhận message
            _client.OnMessageReceived += OnMessageReceived;
            _client.OnDisconnected += OnDisconnected;

            // Gán sự kiện gửi message
            btnSend.Click += btnSend_Click;
            textBox1.KeyDown += textBox1_KeyDown;

            // Gán sự kiện click phòng
            panel5.Click += (s, e) => JoinRoom("general");
            lblgeneral.Click += (s, e) => JoinRoom("general");
            panel6.Click += (s, e) => JoinRoom("random");
            lblrandom.Click += (s, e) => JoinRoom("random");
            panel7.Click += (s, e) => JoinRoom("gaming");
            label2.Click += (s, e) => JoinRoom("gaming");
            panel8.Click += (s, e) => JoinRoom("study");
            lblstudy.Click += (s, e) => JoinRoom("study");
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            panel3.AutoScroll = true;
            _ = _client.RequestRoomListAsync();


            btnSettings1.Click += (s, e) =>
            {
                var settingsForm = new SettingsForm();
                settingsForm.OnUsernameChanged += (newUsername) =>
                {
                    _username = newUsername;
                    lblNameOnline.Text = newUsername;
                    lblQH.Text = GetInitials(newUsername);
                };
                settingsForm.ShowDialog(this);
            };

            // Highlight phòng general mặc định
            HighlightRoom("general");

            AddSystemMessage("Đã kết nối thành công!");
        }

        private void OnMessageReceived(Message msg)
        {
            if (InvokeRequired)
            {
                BeginInvoke(() => OnMessageReceived(msg));
                return;
            }

            switch (msg.Type)
            {
                case MessageType.Chat:
                    if (!_messageHistory.ContainsKey(msg.Room))
                    {
                        _messageHistory[msg.Room] = new();
                        _messageHistory[msg.Room].Add((msg.Username, msg.Content, msg.Time, false, msg.ReplyToUsername, msg.ReplyToContent, msg.IsForwarded));
                    }
                    if (msg.Room == _currentRoom)
                        AddChatMessage(msg.Username, msg.Content, msg.Time,
            msg.ReplyToUsername, msg.ReplyToContent, msg.IsForwarded);
                    break;

                case MessageType.Join:
                    if (msg.Room == _currentRoom)
                        AddSystemMessage(msg.Content);
                    UpdateOnlineList();
                    break;

                case MessageType.Leave:
                    if (msg.Room == _currentRoom)
                        AddSystemMessage(msg.Content);
                    UpdateOnlineList();
                    break;

                case MessageType.GetRooms:
                    try
                    {
                        var rooms = JsonSerializer.Deserialize<List<Room>>(msg.Content ?? "");

                        if(rooms != null)
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
                    if(msg.Room == _currentRoom)
                    {
                        var users = JsonSerializer.Deserialize<List<string>>(msg.Content ?? "[]");
                        if (users != null)
                        {
                            UpdateRoomUsers(users);
                        }
                    }
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

            MessageBox.Show("Mất kết nối với server!", "Ngắt kết nối",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Close();
        }

        // ===== GỬI MESSAGE =====
        private async void btnSend_Click(object sender, EventArgs e)
        {
            await SendMessage();
        }

        private async void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // Bấm Enter để gửi
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
                Username = _username,
                Room = _currentRoom,
                Content = content,
                Time = DateTime.Now,
                ReplyToUsername = _replyToUsername,
                ReplyToContent = _replyToContent,
            };

            await _client.SendMessageDirectAsync(msg);
            CancelReply();

            var settings = _settingsService.Load();
            settings.MessagesSent++;
            _settingsService.Save(settings);
        }

        // ===== CHUYỂN PHÒNG =====
        private async void JoinRoom(string roomName)
        {
            if (roomName == _currentRoom) return;

            if(_joinedRooms.Add(roomName))
            {
                var settings = _settingsService.Load();
                settings.RoomsJoined = _joinedRooms.Count;
                _settingsService.Save(settings);
            }

            _currentRoom = roomName;
            label1.Text = "# " + roomName;
            HighlightRoom(roomName);

            flowLayoutPanel1.Controls.Clear();

            if (_messageHistory.TryGetValue(roomName, out var history))
            {
                foreach (var (username, content, time, isSystem, replyToUsername, replyToContent, isForwarded) in history)
                {
                    if (isSystem)
                        RenderSystemMessage(content);
                    else
                        RenderChatMessage(username, content, time, replyToUsername, replyToContent, isForwarded);
                }
            }
            else
            {
                AddSystemMessage($"You had joined room #{roomName}");
            }

            await _client.JoinRoomAsync(_username, roomName);
        }

        private void HighlightRoom(string roomName)
        {
            roomName = NormalizeRoomName(roomName);
            foreach(var panel in _roomPanels.Values)
            {
                panel.BackColor = Color.Transparent;
            }

            if(_roomPanels.TryGetValue(roomName, out var selectedPanel))
            {
                selectedPanel.BackColor = Color.DodgerBlue;
            }
            //// Reset màu tất cả phòng
            //panel5.BackColor = Color.Transparent;
            //panel6.BackColor = Color.Transparent;
            //panel7.BackColor = Color.Transparent;
            //panel8.BackColor = Color.Transparent;

            //// Highlight phòng đang chọn
            //switch (roomName)
            //{
            //    case "general": panel5.BackColor = Color.DodgerBlue; break;
            //    case "random": panel6.BackColor = Color.DodgerBlue; break;
            //    case "gaming": panel7.BackColor = Color.DodgerBlue; break;
            //    case "study": panel8.BackColor = Color.DodgerBlue; break;
            //}
        }

        // ===== HIỂN THỊ TIN NHẮN =====
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
            // Cập nhật số online trong header
            // Server sẽ gửi danh sách qua GetRooms
            // Tạm thời chỉ update label
            lblSLOnline.Text = $"- {flowLayoutPanel2.Controls.Count} users online";
        }

        // ===== HELPER =====
        private string GetInitials(string name)
        {
            var parts = name.Split(' ');
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

        private void RenderChatMessage(string username, string content, DateTime time, string? replyToUsername = null, string? replyToContent = null, bool isForwarded = false)
        {
            var msgPanel = new Panel();
            msgPanel.Width = flowLayoutPanel1.ClientSize.Width - 20;
            msgPanel.Height = 60;
            msgPanel.Margin = new Padding(5, 5, 5, 0);
            msgPanel.BackColor = Color.White;
            msgPanel.Padding = new Padding(8);

            int yOffset = 8;

            // Avatar
            var avatar = new Label();
            avatar.Text = GetInitials(username);
            avatar.Size = new Size(36, 36);
            avatar.Location = new Point(8, 12);
            avatar.TextAlign = ContentAlignment.MiddleCenter;
            avatar.BackColor = GetAvatarColor(username);
            avatar.ForeColor = Color.White;
            avatar.Font = new Font("Segoe UI", 9f, FontStyle.Bold);

            // Tên + thời gian
            var lblMeta = new Label();
            lblMeta.Text = isForwarded ? $"{username} đã chuyển tiếp {time:HH:mm}" : $"{username} {time:HH:mm}";
            lblMeta.Location = new Point(52, yOffset);
            lblMeta.AutoSize = true;
            lblMeta.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblMeta.ForeColor = isForwarded ? Color.FromArgb(83, 74, 183) : Color.Black;

            yOffset += 28;

            if(!string.IsNullOrEmpty(replyToUsername))
            {
                var replyBar = new Panel();
                replyBar.Location = new Point(48, yOffset);
                replyBar.Width = msgPanel.Width - 70;
                replyBar.Height = 28;
                replyBar.BackColor = Color.FromArgb(235, 235, 245);

                var replyLine = new Panel();
                replyLine.Width = 3;
                replyLine.Dock = DockStyle.Left;
                replyLine.BackColor = Color.FromArgb(83, 74, 183);

                var replyText = new Label();
                replyText.Text = $"{replyToUsername}: {(replyToContent?.Length > 40 ? replyToContent[..40] + "..." : replyToContent)}";
                replyText.Dock = DockStyle.Fill;
                replyText.Font = new Font("Segoe UI", 8f, FontStyle.Italic);
                replyText.ForeColor = Color.FromArgb(83, 74, 183);
                replyText.TextAlign = ContentAlignment.MiddleLeft;
                replyText.Padding = new Padding(6, 0, 0, 0);

                replyBar.Controls.Add(replyText);
                replyBar.Controls.Add(replyLine);
                msgPanel.Controls.Add(replyBar);

                yOffset += 32;
            }

            // Nội dung
            var lblContent = new Label();
            lblContent.Text = ChatShared.EmojiHelper.Parse(content);
            lblContent.Text = content;
            lblContent.Location = new Point(52, yOffset);
            lblContent.AutoSize = true;
            lblContent.Font = new Font("Segoe UI", 9f);
            lblContent.ForeColor = Color.DimGray;
            lblContent.MaximumSize = new Size(msgPanel.Width - 120, 0);
            msgPanel.Controls.Add(lblContent);

            yOffset += lblContent.Height + 8;

            var btnReply = new Button();
            btnReply.Text = "Reply";
            btnReply.Location = new Point(48, yOffset);
            btnReply.Size = new Size(65, 22);
            btnReply.FlatStyle = FlatStyle.Flat;
            btnReply.FlatAppearance.BorderSize = 1;
            btnReply.FlatAppearance.BorderColor = Color.LightGray;
            btnReply.Font = new Font("Segoe UI", 8f);
            btnReply.ForeColor = Color.Gray;
            btnReply.BackColor = Color.White;
            btnReply.Cursor = Cursors.Hand;
            btnReply.Click += (s, e) => ShowReplyPreview(username, content);

            var btnForward = new Button();
            btnForward.Text = "Forward";
            btnForward.Location = new Point(120, yOffset);
            btnForward.Size = new Size(75, 22);
            btnForward.FlatStyle = FlatStyle.Flat;
            btnForward.FlatAppearance.BorderSize = 1;
            btnForward.FlatAppearance.BorderColor = Color.LightGray;
            btnForward.Font = new Font("Segoe UI", 8f);
            btnForward.ForeColor = Color.Gray;
            btnForward.BackColor = Color.White;
            btnForward.Cursor = Cursors.Hand;
            btnForward.Click += (s, e) => ForwardMessage(username, content);

            msgPanel.Controls.AddRange(new Control[] { avatar, lblMeta, btnReply, btnForward });
            msgPanel.Height = yOffset + 30;

            flowLayoutPanel1.Controls.Add(msgPanel);
            flowLayoutPanel1.ScrollControlIntoView(msgPanel);

            flowLayoutPanel1.Controls.Add(msgPanel);
            flowLayoutPanel1.ScrollControlIntoView(msgPanel);
        }

        private void RenderSystemMessage(string content)
        {
            var lbl = new Label();
            lbl.Text = "[HỆ THỐNG] " + content;
            lbl.AutoSize = false;
            lbl.Width = flowLayoutPanel1.ClientSize.Width - 20;
            lbl.Height = 24;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.ForeColor = Color.Gray;
            lbl.Font = new Font("Segoe UI", 8f, FontStyle.Italic);
            lbl.Margin = new Padding(5, 3, 5, 0);

            //flowLayoutPanel1.Controls.Add(lbl);
            //flowLayoutPanel1.ScrollControlIntoView(lbl);
        }

        private void ShowReplyPreview(string username, string content)
        {
            _replyToUsername = username;
            _replyToContent = content;

            if(_replyPreviewPanel != null)
            {
                panel12.Controls.Remove(_replyPreviewPanel);
                _replyPreviewPanel.Dispose();
            }

            // Create panel review
            _replyPreviewPanel = new Panel();
            _replyPreviewPanel.Height = 36;
            _replyPreviewPanel.Dock = DockStyle.Top;
            _replyPreviewPanel.BackColor = Color.FromArgb(235, 235, 235);
            _replyPreviewPanel.Padding = new Padding(10, 0, 10, 0);

            var lblReply = new Label();
            lblReply.Text = $"Đang trả lời {username}: {(content.Length > 40 ? content[..40] + "..." : content)}";
            lblReply.Dock = DockStyle.Fill;
            lblReply.Font = new Font("Segoe UI", 9f, FontStyle.Italic);
            lblReply.ForeColor = Color.FromArgb(83, 74, 183);
            lblReply.TextAlign = ContentAlignment.MiddleLeft;

            var btnCancel = new Button();
            btnCancel.Text = "X";
            btnCancel.Dock = DockStyle.Right;
            btnCancel.Width = 30;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.ForeColor = Color.Gray;
            btnCancel.Click += (s, e) => CancelReply();

            _replyPreviewPanel.Controls.Add(lblReply);
            _replyPreviewPanel.Controls.Add(btnCancel);

            //textBox1.Top += 36;
            //btnSend.Top += 36;

            //panel12.Controls.Add(_replyPreviewPanel);
            //_replyPreviewPanel.SendToBack();

            //panel12.Height += 36;
            //panel12.Top -= 36;

            this.Controls.Add(_replyPreviewPanel);
            _replyPreviewPanel.BringToFront();
            panel12.BringToFront();
        }

        private void CancelReply()
        {
            _replyToUsername = null;
            _replyToContent = null;

            if(_replyPreviewPanel != null)
            {
                panel12.Controls.Remove(_replyPreviewPanel);
                _replyPreviewPanel.Dispose();
                _replyPreviewPanel = null;
                //panel12.Height -= 36;
            }
        }

        private async void ForwardMessage(string originalUsername, string content)
        {
            var rooms = new[] { "general", "random", "gaming", "study" }.Where(r => r != _currentRoom).ToArray();

            using var dialog = new Form();
            dialog.Text = "Chuyển tiếp đến phòng";
            dialog.Size = new Size(280, 200);
            dialog.StartPosition = FormStartPosition.CenterParent;
            dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            dialog.MaximizeBox = false;
            dialog.MinimizeBox = false;

            var lbl = new Label();
            lbl.Text = "Chọn phòng muốn chuyển tiếp:";
            lbl.Location = new Point(15, 15);
            lbl.AutoSize = true;

            var listBox = new ListBox();
            listBox.Items.AddRange(rooms);
            listBox.Location = new Point(15, 40);
            listBox.Size = new Size(240, 80);
            listBox.SelectedIndex = 0;

            var btnOk = new Button();
            btnOk.Text = "Chuyển tiếp";
            btnOk.Location = new Point(15, 130);
            btnOk.Size = new Size(110, 30);
            btnOk.BackColor = Color.FromArgb(83, 74, 183);
            btnOk.ForeColor = Color.White;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.DialogResult = DialogResult.OK;

            var btnCancel = new Button();
            btnCancel.Text = "Hủy";
            btnCancel.Location = new Point(135, 130);
            btnCancel.Size = new Size(80, 30);
            btnCancel.DialogResult = DialogResult.Cancel;

            dialog.Controls.AddRange(new Control[] { lbl, listBox, btnOk, btnCancel });
            dialog.AcceptButton = btnOk;

            if (dialog.ShowDialog() == DialogResult.OK && listBox.SelectedItem != null)
            {
                string targetRoom = listBox.SelectedItem.ToString()!;

                var msg = new Message
                {
                    Type = MessageType.Chat,
                    Username = _username,
                    Room = targetRoom,  // ← Gửi tới phòng khác
                    Content = content,
                    Time = DateTime.Now,
                    IsForwarded = true,
                    ReplyToUsername = originalUsername,
                    ReplyToContent = content
                };

                await _client.SendMessageDirectAsync(msg);

                if (!_messageHistory.ContainsKey(targetRoom))
                    _messageHistory[targetRoom] = new();
                _messageHistory[targetRoom].Add((_username, content, DateTime.Now, false, originalUsername, content, true));

                AddSystemMessage($"Đã chuyển tiếp tin nhắn tới #{targetRoom}");
            }
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

        private void UpdateRoomUsers(List<string> users)
        {
            lblSLOnline.Text = $"- {users.Count} users online";

            flowLayoutPanel2.Controls.Clear();

            foreach (var username in users)
            {
                var userPanel = new Panel();
                userPanel.Width = flowLayoutPanel2.ClientSize.Width - 10;
                userPanel.Height = 30;
                userPanel.Margin = new Padding(3, 2, 3, 0);

                var avatar = new Label();
                avatar.Text = GetInitials(username);
                avatar.Size = new Size(22, 22);
                avatar.Location = new Point(4, 4);
                avatar.TextAlign = ContentAlignment.MiddleCenter;
                avatar.BackColor = GetAvatarColor(username);
                avatar.ForeColor = Color.White;
                avatar.Font = new Font("Segoe UI", 7f, FontStyle.Bold);

                var dot = new Label();
                dot.Text = "●";
                dot.ForeColor = Color.LimeGreen;
                dot.Font = new Font("Segoe UI", 7f);
                dot.AutoSize = true;
                dot.Location = new Point(28, 8);

                var lblName = new Label();
                lblName.Text = username;
                lblName.Location = new Point(42, 7);
                lblName.AutoSize = true;
                lblName.Font = new Font("Segoe UI", 9f);
                lblName.ForeColor = Color.White;

                userPanel.Controls.AddRange(new Control[] { avatar, dot, lblName });
                flowLayoutPanel2.Controls.Add(userPanel);
            }
        }

        private string NormalizeRoomName(string roomName)
        {
            return roomName.Trim().TrimStart('#').ToLower();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            var settings = _settingsService.Load();
            var sessionSeconds = (long)(DateTime.Now - _sessionStartTime).TotalSeconds;
            settings.TotalOnlineSeconds += sessionSeconds;
            _settingsService.Save(settings);

            _client.OnMessageReceived -= OnMessageReceived;
            _client.OnDisconnected -= OnDisconnected;
            _client.Disconnect();
            base.OnFormClosed(e);
        } 

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pnlUser_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbRooms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pnlInput_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbUsers_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;



            // Nền
            e.Graphics.FillRectangle(
                new SolidBrush(Color.FromArgb(18, 17, 31)), e.Bounds);

            // Avatar tròn
            var colors = new[] {
        Color.FromArgb(83,74,183),   // tím
        Color.FromArgb(15,110,86),   // xanh lá
        Color.FromArgb(186,117,23),  // vàng
        Color.FromArgb(153,53,86)    // hồng
    };
            var avatarColor = colors[e.Index % colors.Length];
            var avatarRect = new Rectangle(e.Bounds.X + 8, e.Bounds.Y + 5, 26, 26);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.FillEllipse(new SolidBrush(avatarColor), avatarRect);

            // Chữ tắt trong avatar


            // Tên

            // Chấm xanh online
            e.Graphics.FillEllipse(Brushes.LimeGreen,
                e.Bounds.Right - 16, e.Bounds.Y + 13, 8, 8);
        }

        private void rtbChat_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblNameOnline_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCreateNewRoom_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnCreateNewRoom_Click_1(object sender, EventArgs e)
        {
            using var form = new CreateNewRoom();

            if(form.ShowDialog(this) == DialogResult.OK)
            {
                var room = new Room
                {
                    RoomName = form._roomName,
                    Description = form._roomDescription,
                    Maxmembers = form._memberLimit,
                    CurrentMembers = 0,
                    CreatedAt = DateTime.Now
                };

                await _client.CreateRoomAsync(_username, room);

                await _client.RequestRoomListAsync();

                AddSystemMessage($"Đã tạo phòng #{room.RoomName}");
            }
        }

        private void lblChatRoom_Click(object sender, EventArgs e)
        {

        }
    }
}