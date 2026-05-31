namespace ChatClient.Forms
{
    partial class ClientSettingForm
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
            SuspendLayout();
            // 
            // lblDisplayName
            // 
            lblDisplayName.AutoSize = true;
            lblDisplayName.Location = new Point(35, 60);
            lblDisplayName.Name = "lblDisplayName";
            lblDisplayName.Size = new Size(102, 20);
            lblDisplayName.TabIndex = 3;
            lblDisplayName.Text = "Display Name";
            lblDisplayName.Click += lblDisplayName_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(35, 83);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(501, 27);
            textBox1.TabIndex = 7;
            textBox1.TextChanged += tbDisplayName_TextChanged;
            // 
            // lblServerAddress
            // 
            lblServerAddress.AutoSize = true;
            lblServerAddress.Location = new Point(35, 135);
            lblServerAddress.Name = "lblServerAddress";
            lblServerAddress.Size = new Size(133, 20);
            lblServerAddress.TabIndex = 8;
            lblServerAddress.Text = "Server Address (IP)";
            lblServerAddress.Click += lblServerAddress_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(35, 158);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(501, 27);
            textBox2.TabIndex = 9;
            textBox2.TextChanged += tbServerAddress_TextChanged;
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
            textBox3.Size = new Size(501, 27);
            textBox3.TabIndex = 11;
            textBox3.TextChanged += tbPort_TextChanged;
            // 
            // ClientSettingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(664, 450);
            Controls.Add(textBox3);
            Controls.Add(lblPort);
            Controls.Add(textBox2);
            Controls.Add(lblServerAddress);
            Controls.Add(textBox1);
            Controls.Add(lblDisplayName);
            Name = "ClientSettingForm";
            Text = "ClientSettingForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label lblDisplayName;
        private Label label1;
        private TextBox textBox2;
        private Label lblServerAddress;
        private Label lblPort;
        private TextBox textBox3;
    }
}