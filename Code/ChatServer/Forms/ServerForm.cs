using System;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatServer.Core;


namespace ChatServer.Forms
{
    [DesignerCategory("Form")]
    public partial class ServerForm : Form
    {
        private TcpServer? _server;
        private bool _isServerRunning = false;
        private readonly Dictionary<string, Control> _clientItems = new();
        private System.Windows.Forms.Timer? _uptimeTimer;
        private DateTime _startTime;
        private int _messageCount = 0;

        public ServerForm()
        {
            InitializeComponent();
            flpClients.FlowDirection = FlowDirection.TopDown;
            flpClients.WrapContents = false;
            flpClients.AutoScroll = true;

            btnStop.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            MessageBox.Show("btnStart_Click called!");
            if (_isServerRunning)
            {
                AddLog("Server is already running.");
                return;
            }

            //if(!int.TryParse(txtPort.Text, out int port))
            //{
            //    MessageBox.Show("Port khong hop le", "Error", MessageBoxButtons.Oke, MessageBoxIcon.Error);
            //    return;
            //}

            int port = 8080;
            _server = new TcpServer(port);
            _server.OnLog += AddLog;
            _server.OnClientChanged += UpdateClientList;

            _isServerRunning = true;
            _startTime = DateTime.Now;
            _messageCount = 0;

            btnStart.Enabled = false;
            btnStop.Enabled = true;
            lblStatus.Text = "Running!";
            lblStatus.ForeColor = Color.LimeGreen;

            // Start count uptime
            StartUptimeTimer();

            _ = Task.Run(async () =>
            {
                try
                {
                    await _server.StartAsync();
                    _isServerRunning = false;

                    BeginInvoke(() =>
                    {
                        btnStart.Enabled = true;
                        btnStop.Enabled = false;
                        lblStatus.Text = "Ended !";
                        lblStatus.ForeColor = Color.Red;
                        StopUptimeTimer();
                    });
                }
                catch (Exception ex)
                {
                    BeginInvoke(() => AddLog($"Error: {ex.Message}"));
                }
            });

            AddLog($"Starting server on port {port}...");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (!_isServerRunning || _server == null)
            {
                AddLog("Server is not running.");
                return;
            }

            _server.Stop();
            _isServerRunning = false;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            lblStatus.Text = "Offline!";
            lblStatus.ForeColor = Color.Red;
            StopUptimeTimer();

            AddLog($"[{DateTime.Now:HH:mm:ss}] SERVER STOPPED");
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            rtbLog.Clear();
        }

        private void AddLog(string message)
        {
            if(InvokeRequired)
            {
                BeginInvoke(new Action(() => AddLog(message)));
                return;
            }

            if (message.Contains("MSG"))
            {
                _messageCount++;
                lblMessages.Text = $"Messages: {_messageCount}";
            }

            rtbLog.AppendText(message + Environment.NewLine);
            rtbLog.ScrollToCaret();
        }

        private void UpdateClientList(string username, bool isConnected)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => UpdateClientList(username, isConnected)));
                return;
            }

            if (isConnected)
            {
                AddClientItem(username);
            }
            else
            {
                RemoveClientItem(username);
            }
            UpdateStatus("Offline", Color.Red);
        }

        private void UpdateStatus(string status, Color color)
        {
            if (_server == null)
            {
                return;
            }

            int clientCount = _server.Clients.Count;
            int roomCount = _server.RoomManager.GetAllRooms().Count;

            lblClients.Text = $"Clients: {clientCount}";
            lblRooms.Text = $"Rooms: {roomCount}";
            lblClientCount.Text = $"CLIENTS — {clientCount}";
        }

        private void StartUptimeTimer ()
        {
            _uptimeTimer = new System.Windows.Forms.Timer();
            _uptimeTimer.Interval = 1000;
            _uptimeTimer.Tick += (s, e) =>
            {
                var uptime = DateTime.Now - _startTime;
                lblUptime.Text = uptime.ToString(@"hh\:mm\:ss");
            };
            _uptimeTimer.Start();
        }

        private void StopUptimeTimer ()
        {
            _uptimeTimer?.Stop();
            _uptimeTimer?.Dispose();
            lblUptime.Text = "Uptime: 00:00:00";
        }

        private void AddClientItem(string username)
        {
            if (_clientItems.ContainsKey(username))
                return;

            Panel item = new Panel();
            item.Width = flpClients.ClientSize.Width - 25;
            item.Height = 38;
            item.Margin = new Padding(5);
            item.Padding = new Padding(6);
            item.Tag = username;

            Label lblStatus = new Label();
            lblStatus.Text = "🟢";
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(6, 9);

            Label lblName = new Label();
            lblName.Text = username;
            lblName.AutoSize = true;
            lblName.Location = new Point(35, 10);
            lblName.ForeColor = Color.White;

            item.Controls.Add(lblStatus);
            item.Controls.Add(lblName);

            flpClients.Controls.Add(item);
            _clientItems[username] = item;
        }

        private void RemoveClientItem(string username)
        {
            if (!_clientItems.ContainsKey(username))
                return;

            Control item = _clientItems[username];

            flpClients.Controls.Remove(item);
            item.Dispose();

            _clientItems.Remove(username);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ServerForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtbLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlClients_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblMessages_Click(object sender, EventArgs e)
        {

        }
    }
}