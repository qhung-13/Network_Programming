using System.ComponentModel;
using System.Windows.Forms;
using ChatClient.Core;
using ChatClient.Services;

namespace ChatClient.Forms
{
    [DesignerCategory("Form")]
    public partial class LoginForm : Form
    {
        private readonly ClientSettingsService _settingsService = new();

        private TcpClientService? _client;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            var settings = _settingsService.Load();
            textBox1.Text = settings.Username;
            textBox2.Text = settings.ServerIP;
            textBox3.Text = settings.Port.ToString();
            btnConnect.Click += btnConnect_Click;
        }

        private async void btnConnect_Click (object sender, EventArgs e)
        {
            string displayname = textBox1.Text.Trim();
            string ip = textBox2.Text.Trim();
            string portText = textBox3.Text.Trim();

            if(string.IsNullOrEmpty(displayname))
            {
                MessageBox.Show("Vui lòng nhập tên hiển thị!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (displayname.Length < 2 || displayname.Length > 20)
            {
                MessageBox.Show("Tên hiển thị phải từ 2 đến 20 ký tự!", "Tên không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            if (string.IsNullOrEmpty(ip))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ IP server!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            if (!System.Net.IPAddress.TryParse(ip, out _))
            {
                MessageBox.Show("Địa chỉ IP không hợp lệ!\nVí dụ đúng: 192.168.1.100 hoặc 127.0.0.1", "IP không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            if (string.IsNullOrEmpty(portText))
            {
                MessageBox.Show("Vui lòng nhập port!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return;
            }

            if (!int.TryParse(portText, out int port))
            {
                MessageBox.Show("Port invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (port < 1024 || port > 65535)
            {
                MessageBox.Show("Port phải từ 1024 đến 65535!\nPort thường dùng: 8080, 8888, 9000", "Port không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return;
            }

            btnConnect.Enabled = false;
            btnConnect.Text = "Connecting...";

            // Connect TCP
            string userId = Guid.NewGuid().ToString("N");
            _client = new TcpClientService();
            bool connected = await _client.ConnectAsync(ip, port, userId, displayname, "general");

            if(connected)
            {
                // Save setting
                _settingsService.Save(new ClientSettings
                {
                    Username = displayname,
                    ServerIP = ip,
                    Port = port,
                });

                // Open ChatForm, hidden LoginForm
                var chatForm = new ChatForm(_client, userId, displayname);
                chatForm.FormClosed += (s, args) => this.Close();
                this.Hide();
                chatForm.Show();
            } 
            else
            {
                MessageBox.Show($"Không thể kết nối tới {ip}:{port}\nKiểm tra lại IP, port và đảm bảo server đang chạy!", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnConnect.Enabled = true;
                btnConnect.Text = "Connect";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void lblChatApp_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblStartChatting_Click(object sender, EventArgs e)
        {

        }

        private void lblPort_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblContact_Click(object sender, EventArgs e)
        {

        }
    }
}