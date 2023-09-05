using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class UserControl1 : System.Windows.Forms.UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            this.UserControl1_Resize(sender, e);
            changeFont();
        }

        private void UserControl1_Resize(object sender, EventArgs e)
        {
            label1.Location = new Point(this.Size.Width / 2 - label1.Size.Width / 2, 100);
            label2.Location = new Point(this.Size.Width / 2 - label2.Size.Width / 2, label1.Location.Y + label1.Size.Height + 10);
            pictureBox1.Size = new Size((int)(this.Size.Height / 2.5),(int)(this.Size.Height / 2.5));
            pictureBox1.Location = new Point(this.Size.Width / 2 - pictureBox1.Size.Width / 2, this.Size.Height / 2 - pictureBox1.Size.Height / 2);
        }

        private void UserControl1_BackColorChanged(object sender, EventArgs e)
        {
            var color = System.Drawing.ColorTranslator.FromHtml($"#{Properties.Appearance.Default.BackColor}");
            label1.BackColor = color;
            label2.BackColor = color;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UserControl1_FontChanged(object sender, EventArgs e)
        {
        }

        public void changeFont()
        {
            label1.Font = new Font(Properties.Appearance.Default.FontFamily, 28, FontStyle.Bold);
            label2.Font = new Font(Properties.Appearance.Default.FontFamily, 18, FontStyle.Bold);
        }

        private void UserControl1_TabStopChanged(object sender, EventArgs e)
        {
            changeFont();

        }
    }
}
