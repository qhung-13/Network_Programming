using System.ComponentModel;
using System.Windows.Forms;

namespace ChatClient.Forms
{
    [DesignerCategory("Form")]
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            btnSignUp.BackColor = Color.FromArgb(107, 79, 189);
            btnLogin.BackColor = Color.FromArgb(30, 28, 55);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            btnLogin.BackColor = Color.FromArgb(107, 79, 189);
            btnSignUp.BackColor = Color.FromArgb(30, 28, 55);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            btnLogin.BackColor = Color.FromArgb(107, 79, 189);
            btnSignUp.BackColor = Color.FromArgb(30, 28, 55);
        }

        private void lblChatApp_Click(object sender, EventArgs e)
        {

        }
    }
}