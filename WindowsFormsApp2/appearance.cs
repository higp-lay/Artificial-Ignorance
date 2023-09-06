using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp2
{
    public partial class appearance : UserControl
    {
        public appearance()
        {
            InitializeComponent();
        }
        int initThisWidth, initButtonWidth = 1000;
        
        private void appearance_Load(object sender, EventArgs e)
        {
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox1.DrawItem += new DrawItemEventHandler(fontCombo_DrawItem);

            textBox4.Enabled = false;
            initThisWidth = this.Width;
            appearance_Resize(sender, e);
            initializeFontCombo();

            label3.Font = new Font(Properties.Appearance.Default.FontFamily, 24, FontStyle.Bold | FontStyle.Underline);
            
        }

        private void initializeFontCombo()
        {
            comboBox1.Items.Clear();

            List<string> fonts = new List<string>();

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                comboBox1.Items.Add(font.Name);
            }

            comboBox1.SelectedItem = Properties.Appearance.Default.FontFamily;
        }

        private void fontCombo_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;
            Brush brush = Brushes.Black;
            string text = comboBox1.Items[e.Index].ToString();
            Font font = new Font(text, 16);

            //MessageBox.Show(text);

            e.Graphics.DrawString(text, font, brush, e.Bounds);
        }




        private void button1_Click_1(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Form1 form1 = (Form1)this.FindForm();
                var color = (colorDialog1.Color.ToArgb() & 0x00FFFFFF).ToString("X6");
                Properties.Appearance.Default.BackColor = color;
                Properties.Appearance.Default.Save();
                form1.changeTheme();
                label3.BackColor = System.Drawing.ColorTranslator.FromHtml($"#{Properties.Appearance.Default.BackColor}");
                textBox4.BackColor = System.Drawing.ColorTranslator.FromHtml($"#{Properties.Appearance.Default.BackColor}");
                theme.Refresh();
                // Default: 99B4D1
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = (Form1)this.FindForm();
            Properties.Appearance.Default.Reset();
            Properties.Appearance.Default.Save();
            form1.changeTheme();
            form1.changeFont();
            label3.BackColor = System.Drawing.ColorTranslator.FromHtml($"#{Properties.Appearance.Default.BackColor}");
            textBox4.BackColor = System.Drawing.ColorTranslator.FromHtml($"#{Properties.Appearance.Default.BackColor}");

            comboBox1.SelectedItem = Properties.Appearance.Default.FontFamily;

            form1.UC1.TabStop = !form1.UC1.TabStop;
            form1.UC2.TabStop = !form1.UC2.TabStop;
            form1.UC3.TabStop = !form1.UC3.TabStop;
        }

        private void textBox4_MouseUp(object sender, MouseEventArgs e)
        {
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1 form1 = (Form1)this.FindForm();
            Properties.Appearance.Default.FontFamily = comboBox1.SelectedItem.ToString();
            Properties.Appearance.Default.Save();
            
            label3.Font = new Font(Properties.Appearance.Default.FontFamily, 24, FontStyle.Bold | FontStyle.Underline);

            form1.UC1.TabStop = !form1.UC1.TabStop;
            form1.UC2.TabStop = !form1.UC2.TabStop;
            form1.UC3.TabStop = !form1.UC3.TabStop;
            form1.changeFont();
            reset.Refresh();
            theme.Refresh();
            fontFamilyButton.Refresh();


        }

        private void appearance_TabStopChanged(object sender, EventArgs e)
        {

        }

        private void reset_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void reset_MouseEnter(object sender, EventArgs e)
        {

        }

        private void reset_MouseLeave(object sender, EventArgs e)
        {

        }

        private void reset_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void appearance_BackColorChanged(object sender, EventArgs e)
        {
            var color = System.Drawing.ColorTranslator.FromHtml($"#{Properties.Appearance.Default.BackColor}");
            label3.BackColor = color;
        }

        private void theme_Paint(object sender, PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, "Theme", new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Regular), new Point(15, 10), Color.Black, TextFormatFlags.NoPrefix);
            TextRenderer.DrawText(e.Graphics, $"#{Properties.Appearance.Default.BackColor}", new Font(Properties.Appearance.Default.FontFamily, 12, FontStyle.Regular), new Point(15, 53), Color.Black, TextFormatFlags.NoPrefix);
        }

        private void fontFamilyButton_Paint(object sender, PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, "Font", new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Regular), new Point(15, 10), Color.Black, TextFormatFlags.NoPrefix);
        }

        private void reset_Paint(object sender, PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, "Reset Appearance Settings", new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Regular), new Point(15, 10), Color.Black, TextFormatFlags.NoPrefix);

        }

        private void fontFamilyButton_Click(object sender, EventArgs e)
        {

        }

        private void appearance_Resize(object sender, EventArgs e)
        {            
            var color = System.Drawing.ColorTranslator.FromHtml($"#{Properties.Appearance.Default.BackColor}");
            label3.BackColor = color;
            theme.Location = new Point(label3.Location.X, label3.Location.Y + label3.Height + 20);
            theme.Size = new Size(initButtonWidth - (initThisWidth - this.Size.Width), theme.Size.Height);
            fontFamilyButton.Location = new Point(theme.Location.X, theme.Location.Y + theme.Size.Height + 5);
            fontFamilyButton.Size = theme.Size;
            reset.Size = theme.Size;
            reset.Location = new Point(theme.Location.X, fontFamilyButton.Location.Y + fontFamilyButton.Size.Height + 5);

            textBox4.BackColor = color;
            textBox4.Location = new Point(theme.Location.X + theme.Size.Width - textBox4.Size.Width - (theme.Size.Height - textBox4.Size.Height) / 2, theme.Location.Y + (theme.Size.Height - textBox4.Size.Height)/2);
        
            comboBox1.Location = new Point(fontFamilyButton.Location.X + fontFamilyButton.Size.Width - comboBox1.Size.Width - (theme.Size.Height - textBox4.Size.Height) / 2, fontFamilyButton.Location.Y + (fontFamilyButton.Size.Height - comboBox1.Size.Height) / 2);

        }
    }
}
