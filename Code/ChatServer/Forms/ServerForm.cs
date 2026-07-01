using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatServer.Core;
using ChatServer.Services;

namespace ChatServer.Forms
{
    [DesignerCategory("Form")]
    public partial class ServerForm : Form
    {
        private TcpServer? _server;
        private bool _isServerRunning;

        private readonly Dictionary<string, Control> _clientItems = new();

        private System.Windows.Forms.Timer? _uptimeTimer;
        private DateTime _startTime;

        private int _messageCount;
        private int _serverPort = 8080;
        private int _maxClients = 100;

        public ServerForm()
        {
            InitializeComponent();

            ConfigureClientList();

            btnStop.Enabled = false;
            UpdateServerStatus("● Offline", Color.White);
            UpdateStatistics();
        }

        private void ConfigureClientList()
        {
            flpClients.FlowDirection = FlowDirection.TopDown;
            flpClients.WrapContents = false;
            flpClients.AutoScroll = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_isServerRunning)
            {
                AddLog("SERVER INFO — Server is already running.");
                return;
            }

            StartServer();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            rtbLog.Clear();

            try
            {
                Logger.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không thể xóa file log.\n\n{ex.Message}",
                    "Log Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void btnSettings2_Click(object sender, EventArgs e)
        {
            using ServerSettingForm settingForm = new(
                currentMaxClient: _maxClients,
                currentLogPath: Logger.LogFilePath,
                currentPort: _serverPort,
                currentEnableLog: Logger.IsEnabled
            );

            settingForm.StartPosition = FormStartPosition.CenterParent;

            if (settingForm.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            _maxClients = settingForm.MaxClient;
            _serverPort = settingForm.Port;

            try
            {
                Logger.Configure(settingForm.LogPath, settingForm.EnableLog);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không thể cập nhật cấu hình log.\n\n{ex.Message}",
                    "Log Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            AddLog(
                $"SERVER SETTINGS UPDATED — Port: {_serverPort}, Max Clients: {_maxClients}, Log: {(Logger.IsEnabled ? "ON" : "OFF")}"
            );

            if (_isServerRunning)
            {
                MessageBox.Show(
                    "Server đang chạy. Nếu bạn đổi Port thì cần Stop rồi Start lại server để áp dụng Port mới.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void StartServer()
        {
            try
            {
                _server = new TcpServer(_serverPort);
                _server.OnLog += AddLog;
                _server.OnClientChanged += UpdateClientList;

                _isServerRunning = true;
                _startTime = DateTime.Now;
                _messageCount = 0;

                btnStart.Enabled = false;
                btnStop.Enabled = true;

                UpdateServerStatus("● Running", Color.White);
                UpdateStatistics();
                StartUptimeTimer();

                AddLog($"SERVER STARTING — Port: {_serverPort}");

                _ = Task.Run(async () =>
                {
                    try
                    {
                        await _server.StartAsync();
                    }
                    catch (Exception ex)
                    {
                        RunOnUiThread(() =>
                        {
                            AddLog($"SERVER ERROR — {ex.Message}");
                            StopServerUiOnly();
                        });
                    }
                });
            }
            catch (Exception ex)
            {
                _isServerRunning = false;

                MessageBox.Show(
                    $"Không thể khởi động server.\n\n{ex.Message}",
                    "Server Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                AddLog($"SERVER ERROR — Cannot start server: {ex.Message}");
                StopServerUiOnly();
            }
        }

        private void StopServer()
        {
            if (!_isServerRunning || _server == null)
            {
                AddLog("SERVER INFO — Server is not running.");
                return;
            }

            try
            {
                _server.Stop();
                AddLog("SERVER STOPPED");
            }
            catch (Exception ex)
            {
                AddLog($"SERVER ERROR — Cannot stop server: {ex.Message}");
            }
            finally
            {
                StopServerUiOnly();
            }
        }

        private void StopServerUiOnly()
        {
            _isServerRunning = false;

            btnStart.Enabled = true;
            btnStop.Enabled = false;

            UpdateServerStatus("● Offline", Color.White);
            StopUptimeTimer();
            ClearClientList();
            UpdateStatistics();
        }

        private void UpdateClientList(string username, bool isConnected)
        {
            RunOnUiThread(() =>
            {
                if (isConnected)
                {
                    AddClientItem(username);
                }
                else
                {
                    RemoveClientItem(username);
                }

                UpdateStatistics();
            });
        }

        private void AddClientItem(string username)
        {
            if (_clientItems.ContainsKey(username))
            {
                return;
            }

            Panel item = new()
            {
                Width = Math.Max(flpClients.ClientSize.Width - 28, 150),
                Height = 42,
                Margin = new Padding(8, 5, 8, 5),
                Padding = new Padding(8),
                BackColor = Color.FromArgb(30, 120, 220),
                Tag = username
            };

            Label lblStatusIcon = new()
            {
                Text = "●",
                AutoSize = true,
                ForeColor = Color.Lime,
                Location = new Point(8, 12)
            };

            Label lblName = new()
            {
                Text = username,
                AutoSize = false,
                Width = item.Width - 40,
                Height = 24,
                Location = new Point(28, 10),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };

            item.Controls.Add(lblStatusIcon);
            item.Controls.Add(lblName);

            flpClients.Controls.Add(item);
            _clientItems[username] = item;
        }

        private void RemoveClientItem(string username)
        {
            if (!_clientItems.TryGetValue(username, out Control? item))
            {
                return;
            }

            flpClients.Controls.Remove(item);
            item.Dispose();

            _clientItems.Remove(username);
        }

        private void ClearClientList()
        {
            foreach (Control item in _clientItems.Values)
            {
                flpClients.Controls.Remove(item);
                item.Dispose();
            }

            _clientItems.Clear();
        }

        private void AddLog(string message)
        {
            RunOnUiThread(() =>
            {
                if (message.Contains("MSG", StringComparison.OrdinalIgnoreCase))
                {
                    _messageCount++;
                    lblMessages.Text = $"Messages: {_messageCount}";
                }

                string uiLogLine = $"[{DateTime.Now:HH:mm:ss}] {message}";

                rtbLog.AppendText(uiLogLine + Environment.NewLine);
                rtbLog.ScrollToCaret();

                try
                {
                    Logger.Log(message);
                }
                catch (Exception ex)
                {
                    rtbLog.AppendText($"[LOGGER ERROR] {ex.Message}{Environment.NewLine}");
                    rtbLog.ScrollToCaret();
                }
            });
        }

        private void UpdateStatistics()
        {
            int clientCount = _server?.Clients.Count ?? _clientItems.Count;
            int roomCount = _server?.RoomManager.GetAllRooms().Count ?? 0;

            lblClients.Text = $"Clients: {clientCount}";
            lblRooms.Text = $"Rooms: {roomCount}";
            lblMessages.Text = $"Messages: {_messageCount}";
            lblClientCount.Text = $"CLIENTS — {clientCount}";
        }

        private void UpdateServerStatus(string text, Color color)
        {
            lblStatus.Text = text;
            lblStatus.ForeColor = color;
        }

        private void StartUptimeTimer()
        {
            StopUptimeTimer();

            _uptimeTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000
            };

            _uptimeTimer.Tick += (_, _) =>
            {
                TimeSpan uptime = DateTime.Now - _startTime;
                lblUptime.Text = $"Uptime: {uptime:hh\\:mm\\:ss}";
            };

            _uptimeTimer.Start();
        }

        private void StopUptimeTimer()
        {
            if (_uptimeTimer != null)
            {
                _uptimeTimer.Stop();
                _uptimeTimer.Dispose();
                _uptimeTimer = null;
            }

            lblUptime.Text = "Uptime: 00:00:00";
        }

        private void RunOnUiThread(Action action)
        {
            if (IsDisposed)
            {
                return;
            }

            if (InvokeRequired)
            {
                BeginInvoke(action);
                return;
            }

            action();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            UpdateStatistics();
        }

        private void rtbLog_TextChanged(object sender, EventArgs e)
        {
        }

        private void lblMessages_Click(object sender, EventArgs e)
        {
        }
    }
}