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
            button1 = new Button();
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
            tblToolbar.ColumnCount = 5;
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 47.9591827F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52.0408173F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 285F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 122F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblToolbar.Controls.Add(button1, 4, 0);
            tblToolbar.Controls.Add(btnStart, 0, 0);
            tblToolbar.Controls.Add(btnStop, 1, 0);
            tblToolbar.Controls.Add(lblStatus, 3, 0);
            tblToolbar.Controls.Add(btnClearLog, 2, 0);
            tblToolbar.Dock = DockStyle.Top;
            tblToolbar.Location = new Point(0, 0);
            tblToolbar.Margin = new Padding(2);
            tblToolbar.Name = "tblToolbar";
            tblToolbar.RowCount = 1;
            tblToolbar.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblToolbar.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblToolbar.Size = new Size(622, 36);
            tblToolbar.TabIndex = 0;
            tblToolbar.Paint += tblToolbar_Paint;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Window;
            button1.Dock = DockStyle.Left;
            button1.FlatAppearance.BorderColor = Color.Blue;
            button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Blue;
            button1.Location = new Point(603, 2);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(17, 32);
            button1.TabIndex = 4;
            button1.Text = "■ Stop";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnSetting_Click_1;
            // 
            // btnStart
            // 
            btnStart.BackColor = SystemColors.Window;
            btnStart.Dock = DockStyle.Left;
            btnStart.FlatAppearance.BorderColor = Color.Black;
            btnStart.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStart.ForeColor = Color.Blue;
            btnStart.Location = new Point(2, 2);
            btnStart.Margin = new Padding(2);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(89, 32);
            btnStart.TabIndex = 1;
            btnStart.Text = "▶ Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.BackColor = SystemColors.Window;
            btnStop.Dock = DockStyle.Left;
            btnStop.FlatAppearance.BorderColor = Color.Blue;
            btnStop.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStop.ForeColor = Color.Blue;
            btnStop.Location = new Point(95, 2);
            btnStop.Margin = new Padding(2);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(90, 32);
            btnStop.TabIndex = 1;
            btnStop.Text = "■ Stop";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.ForeColor = Color.LimeGreen;
            lblStatus.Location = new Point(481, 0);
            lblStatus.Margin = new Padding(2, 0, 2, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(118, 36);
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
            btnClearLog.Location = new Point(196, 2);
            btnClearLog.Margin = new Padding(2);
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new Size(125, 32);
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
            rtbLog.Location = new Point(0, 36);
            rtbLog.Margin = new Padding(2);
            rtbLog.Name = "rtbLog";
            rtbLog.ReadOnly = true;
            rtbLog.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbLog.Size = new Size(450, 330);
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
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 162F));
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 149F));
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblStats.Controls.Add(lblClients, 0, 0);
            tblStats.Controls.Add(lblRooms, 1, 0);
            tblStats.Controls.Add(lblMessages, 2, 0);
            tblStats.Controls.Add(lblUptime, 3, 0);
            tblStats.Dock = DockStyle.Bottom;
            tblStats.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            tblStats.Location = new Point(0, 366);
            tblStats.Margin = new Padding(2);
            tblStats.Name = "tblStats";
            tblStats.RowCount = 1;
            tblStats.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblStats.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblStats.Size = new Size(622, 44);
            tblStats.TabIndex = 0;
            // 
            // lblClients
            // 
            lblClients.AutoSize = true;
            lblClients.Dock = DockStyle.Fill;
            lblClients.ForeColor = Color.Navy;
            lblClients.Location = new Point(2, 0);
            lblClients.Margin = new Padding(2, 0, 2, 0);
            lblClients.Name = "lblClients";
            lblClients.Size = new Size(146, 44);
            lblClients.TabIndex = 0;
            lblClients.Text = "Clients: 0";
            lblClients.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRooms
            // 
            lblRooms.AutoSize = true;
            lblRooms.Dock = DockStyle.Fill;
            lblRooms.ForeColor = Color.Navy;
            lblRooms.Location = new Point(152, 0);
            lblRooms.Margin = new Padding(2, 0, 2, 0);
            lblRooms.Name = "lblRooms";
            lblRooms.Size = new Size(156, 44);
            lblRooms.TabIndex = 1;
            lblRooms.Text = "Room: 0";
            lblRooms.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMessages
            // 
            lblMessages.AutoSize = true;
            lblMessages.Dock = DockStyle.Fill;
            lblMessages.ForeColor = Color.Navy;
            lblMessages.Location = new Point(312, 0);
            lblMessages.Margin = new Padding(2, 0, 2, 0);
            lblMessages.Name = "lblMessages";
            lblMessages.Size = new Size(158, 44);
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
            lblUptime.Location = new Point(474, 0);
            lblUptime.Margin = new Padding(2, 0, 2, 0);
            lblUptime.Name = "lblUptime";
            lblUptime.Size = new Size(146, 44);
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
            pnlClients.Location = new Point(446, 36);
            pnlClients.Margin = new Padding(2);
            pnlClients.Name = "pnlClients";
            pnlClients.Size = new Size(176, 330);
            pnlClients.TabIndex = 3;
            // 
            // flpClients
            // 
            flpClients.AutoScroll = true;
            flpClients.BackColor = Color.Blue;
            flpClients.Dock = DockStyle.Fill;
            flpClients.FlowDirection = FlowDirection.TopDown;
            flpClients.ForeColor = Color.White;
            flpClients.Location = new Point(0, 20);
            flpClients.Margin = new Padding(2);
            flpClients.Name = "flpClients";
            flpClients.Size = new Size(176, 310);
            flpClients.TabIndex = 1;
            // 
            // lblClientCount
            // 
            lblClientCount.AutoSize = true;
            lblClientCount.Dock = DockStyle.Top;
            lblClientCount.ForeColor = Color.FromArgb(224, 224, 224);
            lblClientCount.Location = new Point(0, 0);
            lblClientCount.Margin = new Padding(2, 0, 2, 0);
            lblClientCount.Name = "lblClientCount";
            lblClientCount.Size = new Size(95, 20);
            lblClientCount.TabIndex = 0;
            lblClientCount.Text = "CLIENTS — 0";
            lblClientCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(622, 410);
            Controls.Add(pnlClients);
            Controls.Add(rtbLog);
            Controls.Add(tblToolbar);
            Controls.Add(tblStats);
            Margin = new Padding(2);
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
        private Button button1;
    }
}