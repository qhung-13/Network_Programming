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
            lbRooms.Items.Add("general");
            lbRooms.Items.Add("random");
            lbRooms.Items.Add("gaming");
            lbRooms.Items.Add("study");

            // SplitContainer size
            splitMain.SplitterDistance = 220;
        }

        private void lbUsers_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            var name = lbUsers.Items[e.Index]?.ToString() ?? "";
            var isSelf = name.Contains("(ban)");

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
            var initials = name.Length >= 2 ? name[..2].ToUpper() : name.ToUpper();
            using var initFont = new Font("Segoe UI", 8f, FontStyle.Bold);
            var initSize = e.Graphics.MeasureString(initials, initFont);
            e.Graphics.DrawString(initials, initFont, Brushes.White,
                avatarRect.X + (avatarRect.Width - initSize.Width) / 2,
                avatarRect.Y + (avatarRect.Height - initSize.Height) / 2);

            // Tên
            using var nameFont = new Font("Segoe UI", 9.5f,
                isSelf ? FontStyle.Bold : FontStyle.Regular);
            e.Graphics.DrawString(name, nameFont,
                new SolidBrush(Color.White),
                e.Bounds.X + 42, e.Bounds.Y + 9);

            // Chấm xanh online
            e.Graphics.FillEllipse(Brushes.LimeGreen,
                e.Bounds.Right - 16, e.Bounds.Y + 13, 8, 8);
        }

        private void rtbChat_TextChanged(object sender, EventArgs e)
        {

        }
    }
}