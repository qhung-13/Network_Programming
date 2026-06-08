namespace ChatClient.Forms
{
    partial class LoginForm
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
            pnlLeft = new Panel();
            lblKetnoi = new Label();
            lblChatApp = new Label();
            lblStartChatting = new Label();
            lblDisplayName = new Label();
            lblServerAddress = new Label();
            lblPort = new Label();
            lblContact = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            btnConnect = new Button();
            pnlLeft.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.Blue;
            pnlLeft.Controls.Add(lblKetnoi);
            pnlLeft.Controls.Add(lblChatApp);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(230, 445);
            pnlLeft.TabIndex = 0;
            // 
            // lblKetnoi
            // 
            lblKetnoi.Anchor = AnchorStyles.None;
            lblKetnoi.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKetnoi.ForeColor = Color.White;
            lblKetnoi.Location = new Point(12, 218);
            lblKetnoi.Name = "lblKetnoi";
            lblKetnoi.Size = new Size(200, 57);
            lblKetnoi.TabIndex = 2;
            lblKetnoi.Text = "Chat and Connect with Everyone";
            lblKetnoi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblChatApp
            // 
            lblChatApp.Anchor = AnchorStyles.None;
            lblChatApp.AutoSize = true;
            lblChatApp.Font = new Font("Segoe UI Symbol", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChatApp.ForeColor = Color.White;
            lblChatApp.Location = new Point(28, 170);
            lblChatApp.Name = "lblChatApp";
            lblChatApp.Size = new Size(164, 48);
            lblChatApp.TabIndex = 1;
            lblChatApp.Text = "ChatApp";
            lblChatApp.Click += lblChatApp_Click;
            // 
            // lblStartChatting
            // 
            lblStartChatting.AutoSize = true;
            lblStartChatting.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStartChatting.ForeColor = Color.Blue;
            lblStartChatting.Location = new Point(285, 23);
            lblStartChatting.Name = "lblStartChatting";
            lblStartChatting.Size = new Size(202, 38);
            lblStartChatting.TabIndex = 1;
            lblStartChatting.Text = "Start Chatting";
            lblStartChatting.Click += lblStartChatting_Click;
            // 
            // lblDisplayName
            // 
            lblDisplayName.AutoSize = true;
            lblDisplayName.Location = new Point(285, 85);
            lblDisplayName.Name = "lblDisplayName";
            lblDisplayName.Size = new Size(122, 25);
            lblDisplayName.TabIndex = 2;
            lblDisplayName.Text = "Display Name";
            // 
            // lblServerAddress
            // 
            lblServerAddress.AutoSize = true;
            lblServerAddress.Location = new Point(285, 156);
            lblServerAddress.Name = "lblServerAddress";
            lblServerAddress.Size = new Size(161, 25);
            lblServerAddress.TabIndex = 3;
            lblServerAddress.Text = "Server Address (IP)";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(285, 234);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(44, 25);
            lblPort.TabIndex = 4;
            lblPort.Text = "Port";
            lblPort.Click += lblPort_Click;
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Location = new Point(323, 386);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(423, 25);
            lblContact.TabIndex = 5;
            lblContact.Text = "Don�t have a server yet? Contact your administrator.";
            lblContact.Click += lblContact_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(285, 113);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(501, 31);
            textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(285, 187);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(501, 31);
            textBox2.TabIndex = 7;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(285, 262);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(501, 31);
            textBox3.TabIndex = 8;
            // 
            // btnConnect
            // 
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConnect.ForeColor = Color.Blue;
            btnConnect.Location = new Point(464, 336);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(140, 36);
            btnConnect.TabIndex = 9;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            ClientSize = new Size(842, 445);
            Controls.Add(btnConnect);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(lblContact);
            Controls.Add(lblPort);
            Controls.Add(lblServerAddress);
            Controls.Add(lblDisplayName);
            Controls.Add(lblStartChatting);
            Controls.Add(pnlLeft);
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += LoginForm_Load;
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private Panel pnlLeft;
        private Label lblChatApp;
        private Label lblKetnoi;
        private Label lblStartChatting;
        private Label lblDisplayName;
        private Label lblServerAddress;
        private Label lblPort;
        private Label lblContact;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button btnConnect;
    }
}