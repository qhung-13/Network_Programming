using System;
using System.Drawing;
using System.Windows.Forms;
using ChatServer.Services;

namespace ChatServer.Forms
{
    public partial class ServerSettingForm : Form
    {
        public int MaxClient { get; private set; } = 100;
        public string LogPath { get; private set; } = Logger.LogFilePath;
        public int Port { get; private set; } = 8080;
        public bool EnableLog { get; private set; } = true;

        public ServerSettingForm()
        {
            InitializeComponent();
        }

        public ServerSettingForm(
            int currentMaxClient,
            string currentLogPath,
            int currentPort,
            bool currentEnableLog
        ) : this()
        {
            MaxClient = currentMaxClient;
            LogPath = currentLogPath;
            Port = currentPort;
            EnableLog = currentEnableLog;

            LoadCurrentSettingsToForm();
        }

        private void ServerSettingForm_Load(object sender, EventArgs e)
        {
            LoadCurrentSettingsToForm();
        }

        private void LoadCurrentSettingsToForm()
        {
            txtMaxClients.Text = MaxClient.ToString();
            txtLogPath.Text = LogPath;
            txtPort.Text = Port.ToString();
            chkEnableLog.Checked = EnableLog;

            UpdateLogToggleStyle();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!TryValidateSettings())
            {
                return;
            }

            MaxClient = int.Parse(txtMaxClients.Text.Trim());
            LogPath = txtLogPath.Text.Trim();
            Port = int.Parse(txtPort.Text.Trim());
            EnableLog = chkEnableLog.Checked;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnBrowseLogPath_Click(object sender, EventArgs e)
        {
            using SaveFileDialog dialog = new()
            {
                Title = "Choose server log path",
                Filter = "Log file (*.log)|*.log|Text file (*.txt)|*.txt|All files (*.*)|*.*",
                FileName = "server.log",
                OverwritePrompt = false
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                txtLogPath.Text = dialog.FileName;
            }
        }

        private void btnExportLog_Click(object sender, EventArgs e)
        {
            using SaveFileDialog dialog = new()
            {
                Title = "Export server log",
                Filter = "Log file (*.log)|*.log|Text file (*.txt)|*.txt|All files (*.*)|*.*",
                FileName = $"server-log-{DateTime.Now:yyyyMMdd-HHmmss}.log",
                OverwritePrompt = true
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                Logger.ExportTo(dialog.FileName);

                MessageBox.Show(
                    "Export log thành công.",
                    "Export Log",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không thể export log.\n\n{ex.Message}",
                    "Export Log Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void chkEnableLog_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLogToggleStyle();
        }

        private bool TryValidateSettings()
        {
            if (!int.TryParse(txtMaxClients.Text.Trim(), out int maxClient) || maxClient <= 0)
            {
                MessageBox.Show(
                    "Max Clients phải là số nguyên lớn hơn 0.",
                    "Invalid Setting",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                txtMaxClients.Focus();
                return false;
            }

            if (!int.TryParse(txtPort.Text.Trim(), out int port) || port < 1 || port > 65535)
            {
                MessageBox.Show(
                    "Port phải là số nguyên từ 1 đến 65535.",
                    "Invalid Setting",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                txtPort.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLogPath.Text))
            {
                MessageBox.Show(
                    "Log Path không được để trống.",
                    "Invalid Setting",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                txtLogPath.Focus();
                return false;
            }

            return true;
        }

        private void UpdateLogToggleStyle()
        {
            chkEnableLog.Text = chkEnableLog.Checked ? "ON" : "OFF";
            chkEnableLog.BackColor = chkEnableLog.Checked
                ? Color.DodgerBlue
                : Color.LightGray;

            chkEnableLog.ForeColor = chkEnableLog.Checked
                ? Color.White
                : Color.DimGray;
        }
    }
}