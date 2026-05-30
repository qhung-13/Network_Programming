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
            tableLayoutPanel1 = new TableLayoutPanel();
            btnLogin = new Button();
            btnSignUp = new Button();
            panel1 = new Panel();
            btnKetNoi1 = new Button();
            textBox3 = new TextBox();
            label5 = new Label();
            textBox2 = new TextBox();
            label6 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            btnCreateAccount = new Button();
            textBox8 = new TextBox();
            lblConfirmPassword = new Label();
            textBox7 = new TextBox();
            lblPassword = new Label();
            textBox6 = new TextBox();
            lblEmail = new Label();
            lblFirstName = new Label();
            lblLastName = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            lblAccount = new Label();
            lblCreateAccount = new Label();
            pnlLeft.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(0, 0, 192);
            pnlLeft.Controls.Add(lblKetnoi);
            pnlLeft.Controls.Add(lblChatApp);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(230, 444);
            pnlLeft.TabIndex = 0;
            // 
            // lblKetnoi
            // 
            lblKetnoi.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKetnoi.ForeColor = Color.Silver;
            lblKetnoi.Location = new Point(12, 207);
            lblKetnoi.Name = "lblKetnoi";
            lblKetnoi.Size = new Size(200, 57);
            lblKetnoi.TabIndex = 2;
            lblKetnoi.Text = "Connect and chat with everyone";
            lblKetnoi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblChatApp
            // 
            lblChatApp.AutoSize = true;
            lblChatApp.Font = new Font("Segoe UI Symbol", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChatApp.ForeColor = Color.White;
            lblChatApp.Location = new Point(35, 157);
            lblChatApp.Name = "lblChatApp";
            lblChatApp.Size = new Size(151, 45);
            lblChatApp.TabIndex = 1;
            lblChatApp.Text = "ChatApp";
            lblChatApp.Click += lblChatApp_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnLogin, 0, 0);
            tableLayoutPanel1.Controls.Add(btnSignUp, 1, 0);
            tableLayoutPanel1.Location = new Point(323, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(374, 43);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.Dock = DockStyle.Fill;
            btnLogin.ForeColor = SystemColors.Control;
            btnLogin.Location = new Point(3, 3);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(181, 37);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Log in";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnSignUp
            // 
            btnSignUp.Dock = DockStyle.Fill;
            btnSignUp.ForeColor = SystemColors.ButtonFace;
            btnSignUp.Location = new Point(190, 3);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(181, 37);
            btnSignUp.TabIndex = 1;
            btnSignUp.Text = "Sign Up";
            btnSignUp.UseVisualStyleBackColor = true;
            btnSignUp.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnKetNoi1);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(276, 61);
            panel1.Name = "panel1";
            panel1.Size = new Size(460, 361);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // btnKetNoi1
            // 
            btnKetNoi1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKetNoi1.ForeColor = Color.Navy;
            btnKetNoi1.Location = new Point(129, 288);
            btnKetNoi1.Name = "btnKetNoi1";
            btnKetNoi1.Size = new Size(191, 34);
            btnKetNoi1.TabIndex = 11;
            btnKetNoi1.Text = "Connect";
            btnKetNoi1.UseVisualStyleBackColor = true;
            btnKetNoi1.Click += button1_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(3, 233);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(454, 31);
            textBox3.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ControlDark;
            label5.Location = new Point(3, 205);
            label5.Name = "label5";
            label5.Size = new Size(44, 25);
            label5.TabIndex = 9;
            label5.Text = "Port";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(3, 172);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(454, 31);
            textBox2.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.ButtonShadow;
            label6.Location = new Point(27, 325);
            label6.Name = "label6";
            label6.Size = new Size(394, 25);
            label6.TabIndex = 7;
            label6.Text = "Don't have a server? Contact your administrator.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ButtonShadow;
            label4.Location = new Point(3, 134);
            label4.Name = "label4";
            label4.Size = new Size(161, 25);
            label4.TabIndex = 4;
            label4.Text = "Server Address (IP)";
            label4.Click += label4_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(3, 96);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(454, 31);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlDark;
            label3.Location = new Point(3, 68);
            label3.Name = "label3";
            label3.Size = new Size(91, 25);
            label3.TabIndex = 2;
            label3.Text = "Username";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Font = new Font("SimSun", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlDark;
            label2.Location = new Point(3, 36);
            label2.Name = "label2";
            label2.Size = new Size(305, 18);
            label2.TabIndex = 1;
            label2.Text = "Enter your information to connect";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 9);
            label1.Name = "label1";
            label1.Size = new Size(139, 27);
            label1.TabIndex = 0;
            label1.Text = "Start Chatting";
            label1.Click += label1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnCreateAccount);
            panel2.Controls.Add(textBox8);
            panel2.Controls.Add(lblConfirmPassword);
            panel2.Controls.Add(textBox7);
            panel2.Controls.Add(lblPassword);
            panel2.Controls.Add(textBox6);
            panel2.Controls.Add(lblEmail);
            panel2.Controls.Add(lblFirstName);
            panel2.Controls.Add(lblLastName);
            panel2.Controls.Add(tableLayoutPanel2);
            panel2.Controls.Add(lblAccount);
            panel2.Controls.Add(lblCreateAccount);
            panel2.Location = new Point(276, 61);
            panel2.Name = "panel2";
            panel2.Size = new Size(474, 361);
            panel2.TabIndex = 12;
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateAccount.ForeColor = Color.Navy;
            btnCreateAccount.Location = new Point(126, 317);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(230, 34);
            btnCreateAccount.TabIndex = 11;
            btnCreateAccount.Text = "Create Account";
            btnCreateAccount.UseVisualStyleBackColor = true;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(18, 267);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(443, 31);
            textBox8.TabIndex = 10;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.ForeColor = SystemColors.ButtonShadow;
            lblConfirmPassword.Location = new Point(18, 239);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(156, 25);
            lblConfirmPassword.TabIndex = 9;
            lblConfirmPassword.Text = "Confirm Password";
            lblConfirmPassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(18, 205);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(443, 31);
            textBox7.TabIndex = 8;
            textBox7.TextChanged += textBox7_TextChanged;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.ForeColor = SystemColors.ButtonShadow;
            lblPassword.Location = new Point(21, 178);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(260, 25);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Password (At least 8 characters)";
            lblPassword.Click += lblPassword_Click;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(18, 145);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(443, 31);
            textBox6.TabIndex = 6;
            textBox6.TextChanged += textBox6_TextChanged;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.ForeColor = SystemColors.ButtonShadow;
            lblEmail.Location = new Point(18, 117);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(54, 25);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Email";
            lblEmail.Click += label7_Click;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.ForeColor = SystemColors.ButtonShadow;
            lblFirstName.Location = new Point(18, 47);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(97, 25);
            lblFirstName.TabIndex = 4;
            lblFirstName.Text = "First Name";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.ForeColor = SystemColors.ButtonShadow;
            lblLastName.Location = new Point(234, 47);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(95, 25);
            lblLastName.TabIndex = 3;
            lblLastName.Text = "Last Name";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(textBox4, 0, 0);
            tableLayoutPanel2.Controls.Add(textBox5, 1, 0);
            tableLayoutPanel2.Location = new Point(18, 75);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(442, 45);
            tableLayoutPanel2.TabIndex = 2;
            tableLayoutPanel2.Paint += tableLayoutPanel2_Paint;
            // 
            // textBox4
            // 
            textBox4.Dock = DockStyle.Fill;
            textBox4.Location = new Point(3, 3);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(215, 31);
            textBox4.TabIndex = 0;
            // 
            // textBox5
            // 
            textBox5.Dock = DockStyle.Fill;
            textBox5.Location = new Point(224, 3);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(215, 31);
            textBox5.TabIndex = 1;
            // 
            // lblAccount
            // 
            lblAccount.AutoSize = true;
            lblAccount.ForeColor = SystemColors.ButtonShadow;
            lblAccount.Location = new Point(18, 22);
            lblAccount.Name = "lblAccount";
            lblAccount.Size = new Size(302, 25);
            lblAccount.TabIndex = 1;
            lblAccount.Text = "Create an account to save your chats";
            lblAccount.UseWaitCursor = true;
            // 
            // lblCreateAccount
            // 
            lblCreateAccount.AutoSize = true;
            lblCreateAccount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCreateAccount.Location = new Point(18, 0);
            lblCreateAccount.Name = "lblCreateAccount";
            lblCreateAccount.Size = new Size(143, 25);
            lblCreateAccount.TabIndex = 0;
            lblCreateAccount.Text = "Create Account";
            // 
            // LoginForm
            // 
            ClientSize = new Size(778, 444);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pnlLeft);
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += LoginForm_Load;
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }
        private Panel pnlLeft;
        private Label lblChatApp;
        private Label lblKetnoi;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnLogin;
        private Button btnSignUp;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label6;
        private Button btnKetNoi1;
        private TextBox textBox3;
        private Label label5;
        private Panel panel2;
        private Label lblAccount;
        private Label lblCreateAccount;
        private Label lblFirstName;
        private Label lblLastName;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private Label lblEmail;
        private TextBox textBox7;
        private Label lblPassword;
        private Label lblConfirmPassword;
        private TextBox textBox8;
        private Button btnCreateAccount;
    }
}