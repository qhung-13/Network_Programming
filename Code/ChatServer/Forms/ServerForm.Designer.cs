namespace ChatServer.Forms
{
    partial class ServerForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tblToolbar = new TableLayoutPanel();
            btnStart = new Button();
            btnStop = new Button();
            lblStatus = new Label();
            btnClearLog = new Button();
            rtbLog = new RichTextBox();
            tblStats = new TableLayoutPanel();
            lblClients = new Label();
            lblRooms = new Label();
            lblMessages = new Label();
            lblUptime = new Label();
            pnlClients = new Panel();
            flpClients = new FlowLayoutPanel();
            lblClientCount = new Label();
            tblToolbar.SuspendLayout();
            tblStats.SuspendLayout();
            pnlClients.SuspendLayout();
            SuspendLayout();
            // 
            // tblToolbar
            // 
            tblToolbar.BackColor = Color.WhiteSmoke;
            tblToolbar.ColumnCount = 4;
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 47.9591827F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52.0408173F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 182F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 325F));
            tblToolbar.Controls.Add(btnStart, 0, 0);
            tblToolbar.Controls.Add(btnStop, 1, 0);
            tblToolbar.Controls.Add(lblStatus, 3, 0);
            tblToolbar.Controls.Add(btnClearLog, 2, 0);
            tblToolbar.Dock = DockStyle.Top;
            tblToolbar.Location = new Point(0, 0);
            tblToolbar.Name = "tblToolbar";
            tblToolbar.RowCount = 1;
            tblToolbar.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblToolbar.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblToolbar.Size = new Size(778, 45);
            tblToolbar.TabIndex = 0;
            // 
            // btnStart
            // 
            btnStart.BackColor = SystemColors.Window;
            btnStart.Dock = DockStyle.Left;
            btnStart.FlatAppearance.BorderColor = Color.Black;
            btnStart.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStart.ForeColor = Color.Blue;
            btnStart.Location = new Point(3, 3);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(112, 39);
            btnStart.TabIndex = 1;
            btnStart.Text = "▶ Start";
            btnStart.UseVisualStyleBackColor = false;
            // 
            // btnStop
            // 
            btnStop.BackColor = SystemColors.Window;
            btnStop.Dock = DockStyle.Left;
            btnStop.FlatAppearance.BorderColor = Color.Blue;
            btnStop.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStop.ForeColor = Color.Blue;
            btnStop.Location = new Point(132, 3);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(112, 39);
            btnStop.TabIndex = 1;
            btnStop.Text = "■ Stop";
            btnStop.UseVisualStyleBackColor = false;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.ForeColor = Color.LimeGreen;
            lblStatus.Location = new Point(455, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(320, 45);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "● Offline";
            lblStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnClearLog
            // 
            btnClearLog.Dock = DockStyle.Left;
            btnClearLog.FlatAppearance.BorderColor = Color.Black;
            btnClearLog.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClearLog.ForeColor = Color.FromArgb(64, 64, 64);
            btnClearLog.Location = new Point(273, 3);
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new Size(156, 39);
            btnClearLog.TabIndex = 3;
            btnClearLog.Text = "🗑 Delete Log";
            btnClearLog.UseVisualStyleBackColor = true;
            // 
            // rtbLog
            // 
            rtbLog.BackColor = Color.White;
            rtbLog.Dock = DockStyle.Left;
            rtbLog.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbLog.ForeColor = Color.Black;
            rtbLog.Location = new Point(0, 45);
            rtbLog.Name = "rtbLog";
            rtbLog.ReadOnly = true;
            rtbLog.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbLog.Size = new Size(561, 412);
            rtbLog.TabIndex = 2;
            rtbLog.Text = "";
            rtbLog.TextChanged += rtbLog_TextChanged;
            // 
            // tblStats
            // 
            tblStats.BackColor = Color.WhiteSmoke;
            tblStats.ColumnCount = 4;
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48.46154F));
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 51.53846F));
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 202F));
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 185F));
            tblStats.Controls.Add(lblClients, 0, 0);
            tblStats.Controls.Add(lblRooms, 1, 0);
            tblStats.Controls.Add(lblMessages, 2, 0);
            tblStats.Controls.Add(lblUptime, 3, 0);
            tblStats.Dock = DockStyle.Bottom;
            tblStats.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            tblStats.Location = new Point(0, 457);
            tblStats.Name = "tblStats";
            tblStats.RowCount = 1;
            tblStats.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblStats.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblStats.Size = new Size(778, 55);
            tblStats.TabIndex = 0;
            // 
            // lblClients
            // 
            lblClients.AutoSize = true;
            lblClients.Dock = DockStyle.Fill;
            lblClients.ForeColor = Color.Navy;
            lblClients.Location = new Point(3, 0);
            lblClients.Name = "lblClients";
            lblClients.Size = new Size(183, 55);
            lblClients.TabIndex = 0;
            lblClients.Text = "Clients: 0";
            lblClients.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRooms
            // 
            lblRooms.AutoSize = true;
            lblRooms.Dock = DockStyle.Fill;
            lblRooms.ForeColor = Color.Navy;
            lblRooms.Location = new Point(192, 0);
            lblRooms.Name = "lblRooms";
            lblRooms.Size = new Size(195, 55);
            lblRooms.TabIndex = 1;
            lblRooms.Text = "Room: 0";
            lblRooms.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMessages
            // 
            lblMessages.AutoSize = true;
            lblMessages.Dock = DockStyle.Fill;
            lblMessages.ForeColor = Color.Navy;
            lblMessages.Location = new Point(393, 0);
            lblMessages.Name = "lblMessages";
            lblMessages.Size = new Size(196, 55);
            lblMessages.TabIndex = 2;
            lblMessages.Text = "Message: 0";
            lblMessages.TextAlign = ContentAlignment.MiddleCenter;
            lblMessages.Click += lblMessages_Click;
            // 
            // lblUptime
            // 
            lblUptime.AutoSize = true;
            lblUptime.Dock = DockStyle.Fill;
            lblUptime.ForeColor = Color.Navy;
            lblUptime.Location = new Point(595, 0);
            lblUptime.Name = "lblUptime";
            lblUptime.Size = new Size(180, 55);
            lblUptime.TabIndex = 3;
            lblUptime.Text = "Uptime: 00:00";
            lblUptime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlClients
            // 
            pnlClients.BackColor = Color.Blue;
            pnlClients.Controls.Add(flpClients);
            pnlClients.Controls.Add(lblClientCount);
            pnlClients.Dock = DockStyle.Right;
            pnlClients.Location = new Point(558, 45);
            pnlClients.Name = "pnlClients";
            pnlClients.Size = new Size(220, 412);
            pnlClients.TabIndex = 3;
            // 
            // flpClients
            // 
            flpClients.AutoScroll = true;
            flpClients.BackColor = Color.Blue;
            flpClients.Dock = DockStyle.Fill;
            flpClients.FlowDirection = FlowDirection.TopDown;
            flpClients.ForeColor = Color.White;
            flpClients.Location = new Point(0, 25);
            flpClients.Name = "flpClients";
            flpClients.Size = new Size(220, 387);
            flpClients.TabIndex = 1;
            // 
            // lblClientCount
            // 
            lblClientCount.AutoSize = true;
            lblClientCount.Dock = DockStyle.Top;
            lblClientCount.ForeColor = Color.FromArgb(224, 224, 224);
            lblClientCount.Location = new Point(0, 0);
            lblClientCount.Name = "lblClientCount";
            lblClientCount.Size = new Size(115, 25);
            lblClientCount.TabIndex = 0;
            lblClientCount.Text = "CLIENTS — 0";
            lblClientCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(778, 512);
            Controls.Add(pnlClients);
            Controls.Add(rtbLog);
            Controls.Add(tblToolbar);
            Controls.Add(tblStats);
            Name = "ServerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chat Server";
            Load += ServerForm_Load;
            tblToolbar.ResumeLayout(false);
            tblToolbar.PerformLayout();
            tblStats.ResumeLayout(false);
            tblStats.PerformLayout();
            pnlClients.ResumeLayout(false);
            pnlClients.PerformLayout();
            ResumeLayout(false);
        }
        private TableLayoutPanel tblToolbar;
        private Button btnStart;
        private Button btnStop;
        private Label lblStatus;
        private Button btnClearLog;
        private RichTextBox rtbLog;
        private TableLayoutPanel tblStats;
        private Panel pnlClients;
        private Label lblClientCount;
        private FlowLayoutPanel flpClients;
        private Label lblClients;
        private Label lblRooms;
        private Label lblMessages;
        private Label lblUptime;
    }
}