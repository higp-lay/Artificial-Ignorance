using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class UserControl3 : System.Windows.Forms.UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }

        private void UserControl3_Load(object sender, EventArgs e)
        {
            appearance1.Hide();
            analyzersettings1.Hide();
            exitButton.Hide();


            button1.Controls.Add(pictureBox1);
            button2.Controls.Add(pictureBox4);
            button3.Controls.Add(pictureBox2);
            button4.Controls.Add(pictureBox3);
            button5.Controls.Add(pictureBox5);
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox2.BackColor = System.Drawing.Color.Transparent;  
            pictureBox3.BackColor = System.Drawing.Color.Transparent;
            pictureBox4.BackColor = System.Drawing.Color.Transparent;
            pictureBox5.BackColor = System.Drawing.Color.Transparent;



            pictureBox1.Click += (s, a) =>
            {
                button1_Click(s, a);
            };
            pictureBox4.Click += (s, a) =>
            {
                button2_Click_1(s, a);
            };
            pictureBox2.Click += (s, a) =>
            {
                button3_Click(s, a);
            };

            pictureBox3.Click += (s, a) =>
            {
                button4_Click(s, a);
            };
            pictureBox5.Click += (s, a) =>
            {
                button5_Click(s, a);
            };

            changeFont();
            UserControl3_Resize(sender, e);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            analyzersettings1.Hide();
            appearance1.Show();
            appearance1.BringToFront();
            exitButton.Show();
            exitButton.BringToFront();
        }

        private void UserControl3_Resize(object sender, EventArgs e)
        {
            var buttonSize = button1.Size;
            var verticalSpacing = 10;
            button1.Location = new System.Drawing.Point(this.Size.Width / 2 - buttonSize.Width / 2, (int)(this.Size.Height / 2 - buttonSize.Height * 2.5 - verticalSpacing * 2));
            button2.Location = new System.Drawing.Point(this.Size.Width / 2 - buttonSize.Width / 2, button1.Location.Y + buttonSize.Height + verticalSpacing);
            button3.Location = new System.Drawing.Point(this.Size.Width / 2 - buttonSize.Width / 2, button2.Location.Y + buttonSize.Height + verticalSpacing);
            button4.Location = new System.Drawing.Point(this.Size.Width / 2 - buttonSize.Width / 2, button3.Location.Y + buttonSize.Height + verticalSpacing);
            button5.Location = new System.Drawing.Point(this.Size.Width / 2 - buttonSize.Width / 2, button4.Location.Y + buttonSize.Height + verticalSpacing);
            
            // Button 1
            pictureBox1.Location = new System.Drawing.Point(60 - pictureBox1.Size.Width / 2, buttonSize.Height / 2 - pictureBox1.Size.Height / 2);

            // Button 2
            pictureBox4.Location = new System.Drawing.Point(60 - pictureBox1.Size.Width / 2, buttonSize.Height / 2 - pictureBox1.Size.Height / 2);

            // Button 3
            pictureBox2.Location = new System.Drawing.Point(60 - pictureBox1.Size.Width / 2, buttonSize.Height / 2 - pictureBox1.Size.Height / 2);

            // Button 4
            pictureBox3.Location = new System.Drawing.Point(60 - pictureBox1.Size.Width / 2, buttonSize.Height / 2 - pictureBox1.Size.Height / 2);

            // Button 5
            pictureBox5.Location = new System.Drawing.Point(60 - pictureBox1.Size.Width / 2, buttonSize.Height / 2 - pictureBox1.Size.Height / 2);

            exitButton.Location = new System.Drawing.Point(this.Width - 45 - exitButton.Size.Width, 20);

            appearance1.Location = new Point(0, 0);
            analyzersettings1.Location = new Point(0, 0);

            appearance1.Size = this.Size;
            analyzersettings1.Size = this.Size;
        }

        private void appearance1_Resize(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            UserControl3_Load(sender, e);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //var color = System.Drawing.ColorTranslator.FromHtml($"#{Properties.Appearance.Default.BackColor}");
            //button2.BackColor = color;
            appearance1.Hide();
            analyzersettings1.Show();
            analyzersettings1.BringToFront();
            exitButton.Show();
            exitButton.BringToFront();
        }


        private void UserControl3_BackColorChanged(object sender, EventArgs e)
        {
            var color = System.Drawing.ColorTranslator.FromHtml($"#{Properties.Appearance.Default.BackColor}");
            appearance1.BackColor = color;
            analyzersettings1.BackColor = color;
            exitButton.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
            button1.BackColor = color;
            button2.BackColor = color;
            button3.BackColor = color;
            button4.BackColor = color;
            button5.BackColor = color;
        }

        private void appearance1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        public void changeFont()
        {
            exitButton.Font = new Font(Properties.Appearance.Default.FontFamily, 16, FontStyle.Regular);
        }

        private void UserControl3_TabStopChanged(object sender, EventArgs e)
        {
            changeFont();
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, "Appearance", new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Regular), new System.Drawing.Point(200, button1.Height / 2 - 16), Color.Black, TextFormatFlags.NoPrefix);
            TextRenderer.DrawText(e.Graphics, ">", new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Regular), new System.Drawing.Point(button1.Size.Width - 100, button1.Height / 2 - 16), Color.Black, TextFormatFlags.NoPrefix);
        }

        private void button2_Paint(object sender, PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, "Analyzer", new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Regular), new System.Drawing.Point(200, button1.Height / 2 - 16), Color.Black, TextFormatFlags.NoPrefix);
            TextRenderer.DrawText(e.Graphics, ">", new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Regular), new System.Drawing.Point(button1.Size.Width - 100, button1.Height / 2 - 16), Color.Black, TextFormatFlags.NoPrefix);

        }

        private void button3_Paint(object sender, PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, "Privacy & Security", new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Regular), new System.Drawing.Point(200, button1.Height / 2 - 16), Color.Black, TextFormatFlags.NoPrefix);
            TextRenderer.DrawText(e.Graphics, ">", new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Regular), new System.Drawing.Point(button1.Size.Width - 100, button1.Height / 2 - 16), Color.Black, TextFormatFlags.NoPrefix);

        }

        private void button4_Paint(object sender, PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics,"Help & Support", new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Regular), new System.Drawing.Point(200, button1.Height / 2 - 16), Color.Black, TextFormatFlags.NoPrefix);
            TextRenderer.DrawText(e.Graphics, ">", new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Regular), new System.Drawing.Point(button1.Size.Width - 100, button1.Height / 2 - 16), Color.Black, TextFormatFlags.NoPrefix);

        }

        private void button5_Paint(object sender, PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, "About", new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Regular), new System.Drawing.Point(200, button1.Height / 2 - 16), Color.Black, TextFormatFlags.NoPrefix);
            TextRenderer.DrawText(e.Graphics, ">", new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Regular), new System.Drawing.Point(button1.Size.Width - 100, button1.Height / 2 - 16), Color.Black, TextFormatFlags.NoPrefix);
        }

    }
}
