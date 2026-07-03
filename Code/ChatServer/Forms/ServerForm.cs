using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatServer.Core;
using ChatServer.Services;

namespace ChatServer.Forms;

/// <summary>
/// Main dashboard interface for the Chat Server.
/// Monitors connections, displays real-time logs, and manages server lifecycle.
/// </summary>
[DesignerCategory("Form")]
public partial class ServerForm : Form
{
    #region Fields & Properties

    private TcpServer? _server;
    private bool _isServerRunning;

    // Maps connected usernames to their dynamically generated UI panels
    private readonly Dictionary<string, Control> _clientItems = new();

    private System.Windows.Forms.Timer? _uptimeTimer;
    private DateTime _startTime;

    // Server state tracking
    private int _messageCount;
    private int _serverPort = 8080;
    private int _maxClients = 100;

    #endregion

    #region Constructor & Initialization

    public ServerForm()
    {
        InitializeComponent();

        ConfigureClientList();

        // Set initial UI state
        btnStop.Enabled = false;
        UpdateServerStatus("● Offline", Color.White);
        UpdateStatistics();
    }

    /// <summary>
    /// Configures the FlowLayoutPanel properties for displaying active clients.
    /// </summary>
    private void ConfigureClientList()
    {
        flpClients.FlowDirection = FlowDirection.TopDown;
        flpClients.WrapContents = false;
        flpClients.AutoScroll = true;
    }

    #endregion

    #region Action Handlers

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

        // Abort if the user cancels the settings dialog
        if (settingForm.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        // Apply updated configuration
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

        AddLog($"SERVER SETTINGS UPDATED — Port: {_serverPort}, Max Clients: {_maxClients}, Log: {(Logger.IsEnabled ? "ON" : "OFF")}");

        // Warn the user that network changes require a server restart
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

    #endregion

    #region Server Lifecycle Management

    /// <summary>
    /// Initializes the TCP Server, binds event handlers, and starts the listening loop asynchronously.
    /// </summary>
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

            // Offload the server's blocking accept loop to a background task
            _ = Task.Run(async () =>
            {
                try
                {
                    await _server.StartAsync();
                }
                catch (Exception ex)
                {
                    // Ensure any crashes in the server loop gracefully update the UI
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

    /// <summary>
    /// Instructs the underlying TCP Server to halt and handles UI teardown.
    /// </summary>
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

    /// <summary>
    /// Resets the UI components to their offline state without touching the underlying server logic.
    /// </summary>
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

    #endregion

    #region UI Updates & Render Logic

    /// <summary>
    /// Thread-safe dispatcher for updating the active client roster.
    /// </summary>
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

    /// <summary>
    /// Dynamically constructs and renders a panel representing a newly connected client.
    /// </summary>
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

    /// <summary>
    /// Removes a specific client panel from the dashboard and releases its resources.
    /// </summary>
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

    /// <summary>
    /// Purges all dynamic client panels from the dashboard (used during server shutdown).
    /// </summary>
    private void ClearClientList()
    {
        foreach (Control item in _clientItems.Values)
        {
            flpClients.Controls.Remove(item);
            item.Dispose();
        }

        _clientItems.Clear();
    }

    /// <summary>
    /// Safely appends log messages to the UI console and persists them to disk.
    /// </summary>
    private void AddLog(string message)
    {
        RunOnUiThread(() =>
        {
            // Parse message intent to update statistical counters
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
        // Prioritize server registry count, fallback to UI list count if server is null
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

    #endregion

    #region Utilities

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

    /// <summary>
    /// Helper method to marshal executions back to the main UI thread.
    /// Prevents cross-thread operation exceptions when background tasks interact with WinForms controls.
    /// </summary>
    private void RunOnUiThread(Action action)
    {
        if (IsDisposed) return;

        if (InvokeRequired)
        {
            BeginInvoke(action);
            return;
        }

        action();
    }

    #endregion

    #region Unused / Designer Event Handlers
    // Note: Kept empty to prevent the WinForms designer from generating reference errors.

    private void ServerForm_Load(object sender, EventArgs e)
    {
        // Safe to call, ensures initial state is rendered
        UpdateStatistics();
    }

    private void rtbLog_TextChanged(object sender, EventArgs e) { }
    private void lblMessages_Click(object sender, EventArgs e) { }

    #endregion
}