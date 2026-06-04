using System.ComponentModel;
using ChatClient.Core;
using ChatClient.Services;
using ChatShared.Models;
using ChatShared.Protocol;
using Message = ChatShared.Models.Message;

namespace ChatClient.Forms
{
    [DesignerCategory("Form")]
    public partial class ChatForm : Form
    {
        private readonly TcpClientService _client;
        private readonly string _username;
        private string _currentRoom = "general";

        public ChatForm(TcpClientService client, string username)
        {
            InitializeComponent();
            _client = client;
            _username = username;
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
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

            // Gán sự kiện Settings
            btnSettings.Click += (s, e) => new SettingsForm().ShowDialog();

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
                    if (msg.Room == _currentRoom)
                        AddChatMessage(msg.Username, msg.Content, msg.Time);
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
                    // Cập nhật danh sách phòng nếu cần
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

            textBox1.Clear();
            await _client.SendMessageAsync(_username, _currentRoom, content);
        }

        // ===== CHUYỂN PHÒNG =====
        private async void JoinRoom(string roomName)
        {
            if (roomName == _currentRoom) return;

            _currentRoom = roomName;
            label1.Text = $"# {roomName}";
            HighlightRoom(roomName);

            // Xóa tin nhắn cũ
            flowLayoutPanel1.Controls.Clear();
            AddSystemMessage($"Bạn đã vào phòng #{roomName}");

            await _client.JoinRoomAsync(_username, roomName);
        }

        private void HighlightRoom(string roomName)
        {
            // Reset màu tất cả phòng
            panel5.BackColor = Color.Transparent;
            panel6.BackColor = Color.Transparent;
            panel7.BackColor = Color.Transparent;
            panel8.BackColor = Color.Transparent;

            // Highlight phòng đang chọn
            switch (roomName)
            {
                case "general": panel5.BackColor = Color.DodgerBlue; break;
                case "random": panel6.BackColor = Color.DodgerBlue; break;
                case "gaming": panel7.BackColor = Color.DodgerBlue; break;
                case "study": panel8.BackColor = Color.DodgerBlue; break;
            }
        }

        // ===== HIỂN THỊ TIN NHẮN =====
        private void AddChatMessage(string username, string content, DateTime time)
        {
            var msgPanel = new Panel();
            msgPanel.Width = flowLayoutPanel1.ClientSize.Width - 20;
            msgPanel.Height = 60;
            msgPanel.Margin = new Padding(5, 5, 5, 0);
            msgPanel.BackColor = Color.White;

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
            lblMeta.Text = $"{username}  {time:HH:mm}";
            lblMeta.Location = new Point(52, 8);
            lblMeta.AutoSize = true;
            lblMeta.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblMeta.ForeColor = Color.Black;

            // Nội dung
            var lblContent = new Label();
            lblContent.Text = content;
            lblContent.Location = new Point(52, 28);
            lblContent.AutoSize = true;
            lblContent.Font = new Font("Segoe UI", 9f);
            lblContent.ForeColor = Color.DimGray;
            lblContent.MaximumSize = new Size(msgPanel.Width - 60, 0);

            msgPanel.Controls.AddRange(new Control[] { avatar, lblMeta, lblContent });

            // Điều chỉnh height theo nội dung
            msgPanel.Height = Math.Max(60, lblContent.Bottom + 10);

            flowLayoutPanel1.Controls.Add(msgPanel);

            // Scroll xuống dưới
            flowLayoutPanel1.ScrollControlIntoView(msgPanel);
        }

        private void AddSystemMessage(string content)
        {
            var lbl = new Label();
            lbl.Text = content;
            lbl.AutoSize = false;
            lbl.Width = flowLayoutPanel1.ClientSize.Width - 20;
            lbl.Height = 24;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.ForeColor = Color.Gray;
            lbl.Font = new Font("Segoe UI", 8f, FontStyle.Italic);
            lbl.Margin = new Padding(5, 3, 5, 0);

            flowLayoutPanel1.Controls.Add(lbl);
            flowLayoutPanel1.ScrollControlIntoView(lbl);
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

        private void btnCreateNewRoom_Click_1(object sender, EventArgs e)
        {

        }

        private void lblChatRoom_Click(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _client.OnMessageReceived -= OnMessageReceived;
            _client.OnDisconnected -= OnDisconnected;
            _client.Disconnect();
            base.OnFormClosed(e);
        }
    }
}