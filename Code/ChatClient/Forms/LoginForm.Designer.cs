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
            pnlRight = new Panel();
            pnlFormCard = new Panel();
            lblSubtitle = new Label();
            lblContact = new Label();
            btnConnect = new Button();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            lblPort = new Label();
            lblServerAddress = new Label();
            lblDisplayName = new Label();
            lblStartChatting = new Label();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlFormCard.SuspendLayout();
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
            pnlLeft.Padding = new Padding(24);
            pnlLeft.Size = new Size(270, 480);
            pnlLeft.TabIndex = 0;
            // 
            // lblKetnoi
            // 
            lblKetnoi.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKetnoi.ForeColor = Color.White;
            lblKetnoi.Location = new Point(28, 239);
            lblKetnoi.Name = "lblKetnoi";
            lblKetnoi.Size = new Size(214, 70);
            lblKetnoi.TabIndex = 2;
            lblKetnoi.Text = "Chat and connect with everyone";
            lblKetnoi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblChatApp
            // 
            lblChatApp.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChatApp.ForeColor = Color.White;
            lblChatApp.Location = new Point(24, 174);
            lblChatApp.Name = "lblChatApp";
            lblChatApp.Size = new Size(222, 58);
            lblChatApp.TabIndex = 1;
            lblChatApp.Text = "ChatApp";
            lblChatApp.TextAlign = ContentAlignment.MiddleCenter;
            lblChatApp.Click += lblChatApp_Click;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.White;
            pnlRight.Controls.Add(pnlFormCard);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(270, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(44, 36, 44, 36);
            pnlRight.Size = new Size(610, 480);
            pnlRight.TabIndex = 1;
            // 
            // pnlFormCard
            // 
            pnlFormCard.Anchor = AnchorStyles.None;
            pnlFormCard.BackColor = Color.White;
            pnlFormCard.Controls.Add(lblSubtitle);
            pnlFormCard.Controls.Add(lblContact);
            pnlFormCard.Controls.Add(btnConnect);
            pnlFormCard.Controls.Add(textBox3);
            pnlFormCard.Controls.Add(textBox2);
            pnlFormCard.Controls.Add(textBox1);
            pnlFormCard.Controls.Add(lblPort);
            pnlFormCard.Controls.Add(lblServerAddress);
            pnlFormCard.Controls.Add(lblDisplayName);
            pnlFormCard.Controls.Add(lblStartChatting);
            pnlFormCard.Location = new Point(54, 34);
            pnlFormCard.Name = "pnlFormCard";
            pnlFormCard.Size = new Size(500, 412);
            pnlFormCard.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitle.ForeColor = Color.DimGray;
            lblSubtitle.Location = new Point(34, 52);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(279, 20);
            lblSubtitle.TabIndex = 10;
            lblSubtitle.Text = "Enter your information to join the chat";
            // 
            // lblContact
            // 
            lblContact.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContact.ForeColor = Color.DimGray;
            lblContact.Location = new Point(34, 369);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(432, 25);
            lblContact.TabIndex = 5;
            lblContact.Text = "Don't have a server yet? Contact your administrator.";
            lblContact.TextAlign = ContentAlignment.MiddleCenter;
            lblContact.Click += lblContact_Click;
            // 
            // btnConnect
            // 
            btnConnect.BackColor = Color.Blue;
            btnConnect.Cursor = Cursors.Hand;
            btnConnect.FlatAppearance.BorderSize = 0;
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConnect.ForeColor = Color.White;
            btnConnect.Location = new Point(34, 311);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(432, 44);
            btnConnect.TabIndex = 9;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = false;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(34, 264);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(432, 30);
            textBox3.TabIndex = 8;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(34, 185);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(432, 30);
            textBox2.TabIndex = 7;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(34, 106);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(432, 30);
            textBox1.TabIndex = 6;
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPort.ForeColor = Color.Gray;
            lblPort.Location = new Point(34, 239);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(37, 20);
            lblPort.TabIndex = 4;
            lblPort.Text = "Port";
            lblPort.Click += lblPort_Click;
            // 
            // lblServerAddress
            // 
            lblServerAddress.AutoSize = true;
            lblServerAddress.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblServerAddress.ForeColor = Color.Gray;
            lblServerAddress.Location = new Point(34, 160);
            lblServerAddress.Name = "lblServerAddress";
            lblServerAddress.Size = new Size(139, 20);
            lblServerAddress.TabIndex = 3;
            lblServerAddress.Text = "Server Address (IP)";
            // 
            // lblDisplayName
            // 
            lblDisplayName.AutoSize = true;
            lblDisplayName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDisplayName.ForeColor = Color.Gray;
            lblDisplayName.Location = new Point(34, 81);
            lblDisplayName.Name = "lblDisplayName";
            lblDisplayName.Size = new Size(107, 20);
            lblDisplayName.TabIndex = 2;
            lblDisplayName.Text = "Display Name";
            // 
            // lblStartChatting
            // 
            lblStartChatting.AutoSize = true;
            lblStartChatting.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStartChatting.ForeColor = Color.Blue;
            lblStartChatting.Location = new Point(30, 10);
            lblStartChatting.Name = "lblStartChatting";
            lblStartChatting.Size = new Size(210, 41);
            lblStartChatting.TabIndex = 1;
            lblStartChatting.Text = "Start Chatting";
            lblStartChatting.Click += lblStartChatting_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(880, 480);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChatApp - Login";
            Load += LoginForm_Load;
            pnlLeft.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            pnlFormCard.ResumeLayout(false);
            pnlFormCard.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlLeft;
        private Label lblChatApp;
        private Label lblKetnoi;
        private Panel pnlRight;
        private Panel pnlFormCard;
        private Label lblSubtitle;
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
