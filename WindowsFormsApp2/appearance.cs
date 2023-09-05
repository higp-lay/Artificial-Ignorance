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

            label1.Font = new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Regular);
            label2.Font = new Font(Properties.Appearance.Default.FontFamily, 12, FontStyle.Regular);
            label3.Font = new Font(Properties.Appearance.Default.FontFamily, 24, FontStyle.Bold | FontStyle.Underline);
            label4.Font = new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Regular);
            label5.Font = new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Regular);

            label1.Click += (s, a) =>
            {
                button1_Click_1(s, a);
            };
            label1.MouseEnter += (s, a) =>
            {
                theme_MouseEnter(s, a);
                theme.BackColor = System.Drawing.ColorTranslator.FromHtml($"#e0eef9"); ;
            };
            label1.MouseLeave += (s, a) =>
            {
                theme_MouseLeave(s, a);
                theme.BackColor = System.Drawing.ColorTranslator.FromHtml($"#fdfdfd");
            };
            label1.MouseDown += (s, a) =>
            {
                theme_MouseDown(s, a);
                theme.BackColor = System.Drawing.ColorTranslator.FromHtml($"#cde4f8"); ;
            };
            label1.MouseUp += (s, a) =>
            {
                theme_MouseUp(s, a);
                theme.BackColor = System.Drawing.ColorTranslator.FromHtml($"#e0eef9"); ;
            };

            label2.Click += (s, a) =>
            {
                button1_Click_1(s, a);
            };
            label2.MouseEnter += (s, a) =>
            {
                theme_MouseEnter(s, a);
                theme.BackColor = System.Drawing.ColorTranslator.FromHtml($"#e0eef9"); ;
            };
            label2.MouseLeave += (s, a) =>
            {
                theme_MouseLeave(s, a);
                theme.BackColor = System.Drawing.ColorTranslator.FromHtml($"#fdfdfd");
            };
            label2.MouseDown += (s, a) =>
            {
                theme_MouseDown(s, a);
                theme.BackColor = System.Drawing.ColorTranslator.FromHtml($"#cde4f8"); ;
            };
            label2.MouseUp += (s, a) =>
            {
                theme_MouseUp(s, a);
                theme.BackColor = System.Drawing.ColorTranslator.FromHtml($"#e0eef9"); ;
            };

            label5.Click += (s, a) =>
            {
                button2_Click(s, a);
            };
            label5.MouseEnter += (s, a) =>
            {
                reset_MouseEnter(s, a);
                reset.BackColor = System.Drawing.ColorTranslator.FromHtml($"#e0eef9"); ;
            };
            label5.MouseLeave += (s, a) =>
            {
                reset_MouseLeave(s, a);
                reset.BackColor = System.Drawing.ColorTranslator.FromHtml($"#fdfdfd");
            };
            label5.MouseDown += (s, a) =>
            {
                reset_MouseDown(s, a);
                reset.BackColor = System.Drawing.ColorTranslator.FromHtml($"#cde4f8"); ;
            };
            label5.MouseUp += (s, a) =>
            {
                reset_MouseUp(s, a);
                reset.BackColor = System.Drawing.ColorTranslator.FromHtml($"#e0eef9"); ;
            };
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
                label2.Text = $"#{Properties.Appearance.Default.BackColor}";
                textBox4.BackColor = System.Drawing.ColorTranslator.FromHtml($"#{Properties.Appearance.Default.BackColor}");

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

        private void theme_MouseEnter(object sender, EventArgs e)
        {
            label1.BackColor = System.Drawing.ColorTranslator.FromHtml($"#e0eef9");
            label2.BackColor = System.Drawing.ColorTranslator.FromHtml($"#e0eef9");
        }

        private void theme_MouseDown(object sender, MouseEventArgs e)
        {
            label1.BackColor = System.Drawing.ColorTranslator.FromHtml($"#cde4f8");
            label2.BackColor = System.Drawing.ColorTranslator.FromHtml($"#cde4f8");
        }

        private void theme_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = System.Drawing.ColorTranslator.FromHtml($"#fdfdfd");
            label2.BackColor = System.Drawing.ColorTranslator.FromHtml($"#fdfdfd");
        }

        private void theme_MouseUp(object sender, MouseEventArgs e)
        {
            label1.BackColor = System.Drawing.ColorTranslator.FromHtml($"#e0eef9");
            label2.BackColor = System.Drawing.ColorTranslator.FromHtml($"#e0eef9");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1 form1 = (Form1)this.FindForm();
            Properties.Appearance.Default.FontFamily = comboBox1.SelectedItem.ToString();
            Properties.Appearance.Default.Save();
            
            label1.Font = new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Regular);
            label2.Font = new Font(Properties.Appearance.Default.FontFamily, 12, FontStyle.Regular);
            label3.Font = new Font(Properties.Appearance.Default.FontFamily, 24, FontStyle.Bold | FontStyle.Underline);
            label4.Font = new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Regular);
            label5.Font = new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Regular);

            form1.UC1.TabStop = !form1.UC1.TabStop;
            form1.UC2.TabStop = !form1.UC2.TabStop;
            form1.UC3.TabStop = !form1.UC3.TabStop;
            form1.changeFont();


        }

        private void appearance_TabStopChanged(object sender, EventArgs e)
        {

        }

        private void reset_MouseDown(object sender, MouseEventArgs e)
        {
            label5.BackColor = System.Drawing.ColorTranslator.FromHtml($"#cde4f8");
        }

        private void reset_MouseEnter(object sender, EventArgs e)
        {
            label5.BackColor = System.Drawing.ColorTranslator.FromHtml($"#e0eef9");
        }

        private void reset_MouseLeave(object sender, EventArgs e)
        {
            label5.BackColor = System.Drawing.ColorTranslator.FromHtml($"#fdfdfd");
        }

        private void reset_MouseUp(object sender, MouseEventArgs e)
        {
            label5.BackColor = System.Drawing.ColorTranslator.FromHtml($"#e0eef9");
        }

        private void appearance_BackColorChanged(object sender, EventArgs e)
        {
            var color = System.Drawing.ColorTranslator.FromHtml($"#{Properties.Appearance.Default.BackColor}");
            label3.BackColor = color;
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

            label1.Location = new Point(theme.Location.X + 15, theme.Location.Y + 10);
            label2.Location = new Point(label1.Location.X, label1.Location.Y + label1.Size.Height + 5);
            label2.Text = $"#{Properties.Appearance.Default.BackColor}";
            textBox4.BackColor = color;
            textBox4.Location = new Point(theme.Location.X + theme.Size.Width - textBox4.Size.Width - (theme.Size.Height - textBox4.Size.Height) / 2, theme.Location.Y + (theme.Size.Height - textBox4.Size.Height)/2);
        
            label4.Location = new Point(fontFamilyButton.Location.X + 15, fontFamilyButton.Location.Y + 10);
            comboBox1.Location = new Point(fontFamilyButton.Location.X + fontFamilyButton.Size.Width - comboBox1.Size.Width - (theme.Size.Height - textBox4.Size.Height) / 2, fontFamilyButton.Location.Y + (fontFamilyButton.Size.Height - comboBox1.Size.Height) / 2);

            label5.Location = new Point(reset.Location.X + 15, reset.Location.Y + 10);
        }
    }
}
