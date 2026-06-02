using System.ComponentModel;
using System.Windows.Forms;

namespace ChatClient.Forms
{
    [DesignerCategory("Form")]
    public partial class ChatForm : Form
    {
        public ChatForm()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pnlUser_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbRooms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pnlInput_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            // Data mau phong chat

        }

        private void lbUsers_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;



            // Nền
            e.Graphics.FillRectangle(
                new SolidBrush(Color.FromArgb(18, 17, 31)), e.Bounds);

            // Avatar tròn
            var colors = new[] {
        Color.FromArgb(83,74,183),   // tím
        Color.FromArgb(15,110,86),   // xanh lá
        Color.FromArgb(186,117,23),  // vàng
        Color.FromArgb(153,53,86)    // hồng
    };
            var avatarColor = colors[e.Index % colors.Length];
            var avatarRect = new Rectangle(e.Bounds.X + 8, e.Bounds.Y + 5, 26, 26);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.FillEllipse(new SolidBrush(avatarColor), avatarRect);

            // Chữ tắt trong avatar


            // Tên

            // Chấm xanh online
            e.Graphics.FillEllipse(Brushes.LimeGreen,
                e.Bounds.Right - 16, e.Bounds.Y + 13, 8, 8);
        }

        private void rtbChat_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblNameOnline_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCreateNewRoom_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCreateNewRoom_Click_1(object sender, EventArgs e)
        {

        }

        private void lblChatRoom_Click(object sender, EventArgs e)
        {

        }
    }
}