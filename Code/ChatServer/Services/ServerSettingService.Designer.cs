namespace ChatServer.Forms
{
    partial class ServerSettingService
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblDisplayName = new Label();
            textBox1 = new TextBox();
            lblServerAddress = new Label();
            textBox2 = new TextBox();
            lblPort = new Label();
            textBox3 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            checkBox1 = new CheckBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblDisplayName
            // 
            lblDisplayName.AutoSize = true;
            lblDisplayName.Location = new Point(35, 60);
            lblDisplayName.Name = "lblDisplayName";
            lblDisplayName.Size = new Size(79, 20);
            lblDisplayName.TabIndex = 3;
            lblDisplayName.Text = "Max Client";
            lblDisplayName.Click += lblMaxClient_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(35, 83);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(241, 27);
            textBox1.TabIndex = 7;
            textBox1.TextChanged += tbMaxClient_TextChanged;
            // 
            // lblServerAddress
            // 
            lblServerAddress.Location = new Point(35, 135);
            lblServerAddress.Name = "lblServerAddress";
            lblServerAddress.Size = new Size(133, 20);
            lblServerAddress.TabIndex = 8;
            lblServerAddress.Text = "Log Path";
            lblServerAddress.Click += lblLogPath_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(35, 158);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(541, 27);
            textBox2.TabIndex = 9;
            textBox2.TextChanged += tbLogPath_TextChanged;
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(35, 215);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(35, 20);
            lblPort.TabIndex = 10;
            lblPort.Text = "Port";
            lblPort.Click += lblPort_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(35, 238);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(541, 27);
            textBox3.TabIndex = 11;
            textBox3.TextChanged += tbPort_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(436, 359);
            button1.Name = "button1";
            button1.Size = new Size(140, 60);
            button1.TabIndex = 12;
            button1.Text = "SAVE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnSave_Click;
            // 
            // button2
            // 
            button2.Location = new Point(28, 359);
            button2.Name = "button2";
            button2.Size = new Size(140, 60);
            button2.TabIndex = 13;
            button2.Text = "EXIT";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnExit_Click;
            // 
            // checkBox1
            // 
            checkBox1.Appearance = Appearance.Button;
            checkBox1.Font = new Font("Segoe UI", 9F);
            checkBox1.Location = new Point(149, 283);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(41, 43);
            checkBox1.TabIndex = 15;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label1
            // 
            label1.Location = new Point(35, 294);
            label1.Name = "label1";
            label1.Size = new Size(99, 25);
            label1.TabIndex = 14;
            label1.Text = "Log";
            label1.Click += lbLog_Click;
            // 
            // ServerSettingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(664, 450);
            ControlBox = false;
            Controls.Add(checkBox1);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(lblPort);
            Controls.Add(textBox2);
            Controls.Add(lblServerAddress);
            Controls.Add(textBox1);
            Controls.Add(lblDisplayName);
            Name = "ServerSettingService";
            Text = "ServerSettingService";
            Load += ServerSettingForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label lblDisplayName;
        private TextBox textBox2;
        private Label lblServerAddress;
        private Label lblPort;
        private TextBox textBox3;
        private Button button1;
        private Button button2;
        private CheckBox checkBox1;
        private Label label1;
    }
}