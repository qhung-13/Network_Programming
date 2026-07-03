using System;
using System.Drawing;
using System.Windows.Forms;
using ChatServer.Services;

namespace ChatServer.Forms;

/// <summary>
/// Dialog form for configuring server-side parameters such as port, maximum clients, and logging preferences.
/// </summary>
public partial class ServerSettingForm : Form
{
    #region Properties

    // Public properties to expose the validated settings back to the caller (e.g., ServerForm)
    public int MaxClient { get; private set; } = 100;
    public string LogPath { get; private set; } = Logger.LogFilePath;
    public int Port { get; private set; } = 8080;
    public bool EnableLog { get; private set; } = true;

    #endregion

    #region Constructors

    public ServerSettingForm()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Initializes the settings form with the currently active server configuration.
    /// </summary>
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

    #endregion

    #region Form Events

    private void ServerSettingForm_Load(object sender, EventArgs e)
    {
        LoadCurrentSettingsToForm();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        // Halt the save process if any input fails the validation checks
        if (!TryValidateSettings())
        {
            return;
        }

        // Apply the validated inputs to the public properties
        MaxClient = int.Parse(txtMaxClients.Text.Trim());
        LogPath = txtLogPath.Text.Trim();
        Port = int.Parse(txtPort.Text.Trim());
        EnableLog = chkEnableLog.Checked;

        // Signal success to the calling form and close the dialog
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

    #endregion

    #region Validation & UI Logic

    /// <summary>
    /// Populates the UI input controls with the currently stored configuration properties.
    /// </summary>
    private void LoadCurrentSettingsToForm()
    {
        txtMaxClients.Text = MaxClient.ToString();
        txtLogPath.Text = LogPath;
        txtPort.Text = Port.ToString();
        chkEnableLog.Checked = EnableLog;

        UpdateLogToggleStyle();
    }

    /// <summary>
    /// Validates all user inputs to ensure they meet network and application requirements.
    /// Displays appropriate error messages and shifts focus to the invalid control if validation fails.
    /// </summary>
    /// <returns>True if all settings are valid; otherwise, false.</returns>
    private bool TryValidateSettings()
    {
        // Validate Maximum Clients (Must be a positive integer)
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

        // Validate Network Port (Must be within the valid TCP port range)
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

        // Validate Log Path (Must not be empty)
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

    /// <summary>
    /// Dynamically updates the visual styling of the logging toggle button based on its state.
    /// </summary>
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

    #endregion
}