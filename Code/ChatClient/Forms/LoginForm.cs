using System.ComponentModel;
using System.Configuration;
using System.Windows.Forms;
using System.Xml.Serialization;
using ChatClient.Core;
using ChatClient.Services;

namespace ChatClient.Forms
{
    [DesignerCategory("Form")]
    public partial class LoginForm : Form
    {
        private TcpClientService? _client;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            var settings = SettingsService.Load();
            textBox1.Text = settings.Username;
            textBox2.Text = settings.ServerIP;
            textBox3.Text = settings.Port.ToString();

            btnConnect.Click += btnConnect_Click;
        }

        private async void btnConnect_Click (object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string ip = textBox2.Text.Trim();
            string portText = textBox3.Text.Trim();

            if(string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please fill all name", "Thieu thong tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(!int.TryParse(portText, out int port))
            {
                MessageBox.Show("Port invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnConnect.Enabled = false;
            btnConnect.Text = "Connecting...";

            // Connect TCP
            _client = new TcpClientService();
            bool connected = await _client.ConnectAsync(ip, port, username, "general");

            if(connected)
            {
                // Save setting
                SettingsService.Save(new ClientSettings
                {
                    Username = username,
                    ServerIp = ip,
                    Port = port,
                });

                // Open ChatForm, hidden LoginForm
                var chatForm = new ChatForm(_client, username);
                chatForm.FormClosed += (s, args) => this.Close();
                this.Hide();
                chatForm.Show();
            } 
            else
            {
                MessageBox.Show("Cannot connect to server!\n Checking IP and Port", "Error connected", MessageBoxButtons.OK, MessageBoxIcon.Error);
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