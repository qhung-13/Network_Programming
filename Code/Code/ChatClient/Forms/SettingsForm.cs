using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatClient.Services;

namespace ChatClient.Forms
{
    public partial class SettingsForm : Form
    {
        private readonly ClientSettingsService _settingsService = new();
        private ClientSettings _currentSettings;
        public event Action<string>? OnUsernameChanged;

        public SettingsForm()
        {
            InitializeComponent();

            foreach (Control c in pnlContent.Controls)
            {
                if (c is Panel p)
                {
                    p.Dock = DockStyle.Fill;
                    p.Visible = false;
                }
            }

            ShowPanel(pnlAccount, btnAccount);

            _currentSettings = _settingsService.Load();
            LoadDataToForm();

            btnSave.Click += btnSave_Click;
            btnCancel.Click += (s, e) => Close();
            btnExportLog.Click += btnExportLog_Click;
            btnClearLog.Click += btnClearLog_Click;
        }

        private void ShowPanel(Panel targetPanel, Button activeButton)
        {
            // Ẩn tất cả panel
            pnlAccount.Visible = false;
            pnlConnection.Visible = false;
            pnlNotifications.Visible = false;
            pnlAppearance.Visible = false;
            pnlLogStorage.Visible = false;

            // Reset màu tất cả button
            btnAccount.BackColor = Color.Transparent;
            btnConnection.BackColor = Color.Transparent;
            btnNotifications.BackColor = Color.Transparent;
            btnAppearance.BackColor = Color.Transparent;
            btnLogStorage.BackColor = Color.Transparent;

            btnAccount.ForeColor = Color.FromArgb(168, 200, 232);
            btnConnection.ForeColor = Color.FromArgb(168, 200, 232);
            btnNotifications.ForeColor = Color.FromArgb(168, 200, 232);
            btnAppearance.ForeColor = Color.FromArgb(168, 200, 232);
            btnLogStorage.ForeColor = Color.FromArgb(168, 200, 232);

            // Hiện panel được chọn
            targetPanel.Visible = true;
            targetPanel.BringToFront();

            // Highlight button được chọn
            activeButton.BackColor = Color.FromArgb(14, 42, 69);
            activeButton.ForeColor = Color.FromArgb(77, 184, 255);

            // Load log preview mỗi khi mở tab Log & Storage
            if (targetPanel == pnlLogStorage)
            {
                LoadLogPreview();
            }
        }

        private void LoadDataToForm()
        {
            // Tab Account
            txtDisplayName.Text = _currentSettings.Username;
            txtServerIP.Text = _currentSettings.ServerIP;
            txtPort.Text = _currentSettings.Port.ToString();

            // Tab Connection (đồng bộ luôn)
            textBox1.Text = _currentSettings.ServerIP;
            textBox2.Text = _currentSettings.Port.ToString();

            // Tab Notifications
            chkNewMessageNotif.Checked = _currentSettings.EnableNotifications;
            chkNotifSound.Checked = _currentSettings.EnableSound;
            chkRoomJoinLeaveNotif.Checked = true;

            // Tab Account checkbox
            chkAutoReconnect.Checked = _currentSettings.AutoReconnect;

            lblMessagesSentValue.Text = _currentSettings.MessagesSent.ToString();
            lblRoomsJoinedValue.Text = _currentSettings.RoomsJoined.ToString();

            var ts = TimeSpan.FromSeconds(_currentSettings.TotalOnlineSeconds);
            lblOnlineTimeValue.Text = $"{(int)ts.TotalHours}h {ts.Minutes}m";

            // Tab Log & Storage
            txtLogPath.Text = GetCurrentLogPath();
        }

        private void LoadLogPreview()
        {
            string logPath = GetCurrentLogPath();

            if (File.Exists(logPath))
            {
                try
                {
                    var lines = File.ReadAllLines(logPath);
                    var lastLines = lines.Length > 50 ? lines[^50..] : lines;
                    rtbLogPreview.Text = string.Join(Environment.NewLine, lastLines);
                    rtbLogPreview.SelectionStart = rtbLogPreview.Text.Length;
                    rtbLogPreview.ScrollToCaret();

                    var fileInfo = new FileInfo(logPath);
                    lblLogSizeValue.Text = $"{fileInfo.Length / 1024} KB";
                }
                catch
                {
                    rtbLogPreview.Text = "Không thể đọc file log.";
                }
            }
            else
            {
                rtbLogPreview.Text = "Chưa có file log nào.";
                lblLogSizeValue.Text = "0 KB";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string oldUsername = _currentSettings.Username;
            string newUsername = txtDisplayName.Text.Trim();

            _currentSettings.Username = newUsername;
            _currentSettings.ServerIP = txtServerIP.Text.Trim();

            if (int.TryParse(txtPort.Text.Trim(), out int port))
                _currentSettings.Port = port;

            _currentSettings.EnableNotifications = chkNewMessageNotif.Checked;
            _currentSettings.EnableSound = chkNotifSound.Checked;
            _currentSettings.AutoReconnect = chkAutoReconnect.Checked;

            _settingsService.Save(_currentSettings);

            if (oldUsername != newUsername)
            {
                OnUsernameChanged?.Invoke(newUsername);
            }

            MessageBox.Show("Đã lưu cài đặt!", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnExportLog_Click(object sender, EventArgs e)
        {
            string sourceLogPath = GetCurrentLogPath();

            if (!File.Exists(sourceLogPath))
            {
                MessageBox.Show("Chưa có file log nào để xuất!", "Không tìm thấy log",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Log Files (*.log)|*.log|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveDialog.FileName = $"chatlog_{DateTime.Now:yyyyMMdd_HHmmss}.log";
            saveDialog.Title = "Xuất file log";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.Copy(sourceLogPath, saveDialog.FileName, overwrite: true);
                    MessageBox.Show($"Đã xuất log thành công!\n{saveDialog.FileName}", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xuất log: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            string logPath = GetCurrentLogPath();

            var result = MessageBox.Show(
                "Bạn có chắc muốn xóa toàn bộ log?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes && File.Exists(logPath))
            {
                File.WriteAllText(logPath, "");
                rtbLogPreview.Clear();
                lblLogSizeValue.Text = "0 KB";
                MessageBox.Show("Đã xóa log!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string GetCurrentLogPath()
        {
            var currentDir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            while (currentDir != null)
            {
                string chatSharedPath = Path.Combine(currentDir.FullName, "ChatShared");
                if (Directory.Exists(chatSharedPath))
                {
                    return Path.Combine(chatSharedPath, "Log", "server.log");
                }
                currentDir = currentDir.Parent;
            }

            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log", "server.log");
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlAccount, btnAccount);
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlConnection, btnConnection);
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlNotifications, btnNotifications);
        }

        private void btnAppearance_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlAppearance, btnAppearance);
        }

        private void btnLogStorage_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlLogStorage, btnLogStorage);
        }
    }
}