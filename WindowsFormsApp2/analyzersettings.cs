using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Properties;
using Xceed.Wpf.AvalonDock.Themes;

namespace WindowsFormsApp2
{
    public partial class analyzersettings : UserControl
    {
        public analyzersettings()
        {
            InitializeComponent();
        }
        int initThisWidth, initButtonWidth = 1000;

        private void analyzersettings_Load(object sender, EventArgs e)
        {
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox1.DrawItem += new DrawItemEventHandler(fontCombo_DrawItem);
            initThisWidth = this.Size.Width;
            label10.Text = Properties.Settings.Default.initialDirectory;
            //MessageBox.Show(initThisWidth.ToString());
            label1.Font = new Font(Properties.Appearance.Default.FontFamily, 24, FontStyle.Bold | FontStyle.Underline);
            comboBox2.Font = new Font(Properties.Appearance.Default.FontFamily, 14, FontStyle.Regular);

            //

            if (Settings.Default.Properties["initialDirectory"].DefaultValue.ToString() == Properties.Settings.Default.initialDirectory)
            {
                pictureBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#e3e3e3");
                showFileDialog.Enabled = false;
            } else
            {
                pictureBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fdfdfd");
                showFileDialog.Enabled = true;
            }
            showFileDialog.Refresh();

            if(Properties.Settings.Default.showFolderDialog)
            {
                pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "square-checked-regular.png");
            } else 
            {
                pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "square-unchecked-regular.png");
            }



            label10.Click += (s, a) =>
            {
                defaultDir_Click(s, a);
            };
            label10.MouseEnter += (s, a) =>
            {
                defaultDir_MouseEnter(s, a);
            };
            label10.MouseLeave += (s, a) =>
            {
                defaultDir_MouseLeave(s, a);
            };
            label10.MouseDown += (s, a) =>
            {
                defaultDir_MouseDown(s, a);
            };
            label10.MouseUp += (s, a) =>
            {
                defaultDir_MouseUp(s, a);
            };


            pictureBox1.Click += (s, a) =>
            {
                if (showFileDialog.Enabled)
                    showFileDialog_Click(s, a);
            };

            analyzersettings_Resize(sender, e);
            initializeFontCombo();
            initializeSizeCombo();
        }

        private void analyzersettings_Resize(object sender, EventArgs e)
        {
            var color = System.Drawing.ColorTranslator.FromHtml($"#{Properties.Appearance.Default.BackColor}");
            label1.BackColor = color;
            
            defaultFont.Location = new Point(label1.Location.X, label1.Location.Y + label1.Height + 20);
            defaultFont.Size = new Size(initButtonWidth - (initThisWidth - this.Size.Width), defaultFont.Size.Height);
            defaultSize.Location = new Point(defaultFont.Location.X, defaultFont.Location.Y + defaultFont.Size.Height + 5);
            defaultDir.Location = new Point(defaultFont.Location.X, defaultSize.Location.Y + defaultSize.Size.Height + 5);
            showFileDialog.Location = new Point(defaultFont.Location.X, defaultDir.Location.Y + defaultDir.Size.Height + 5);
            reset.Location = new Point(defaultFont.Location.X, showFileDialog.Location.Y + showFileDialog.Size.Height + 5);
            defaultSize.Size = reset.Size = defaultDir.Size = showFileDialog.Size = defaultFont.Size;

            pictureBox1.Location = new Point(showFileDialog.Location.X + showFileDialog.Size.Width - pictureBox1.Size.Width - (showFileDialog.Size.Height - pictureBox1.Size.Height) / 2, showFileDialog.Location.Y + (defaultFont.Size.Height - comboBox1.Size.Height) / 2); ;

            comboBox1.Location = new Point(defaultFont.Location.X + defaultFont.Size.Width - comboBox1.Size.Width - (defaultFont.Size.Height - comboBox1.Size.Height) / 2, defaultFont.Location.Y + (defaultFont.Size.Height - comboBox1.Size.Height) / 2);
            comboBox2.Location = new Point(defaultSize.Location.X + defaultSize.Size.Width - comboBox2.Size.Width - (defaultFont.Size.Height - comboBox1.Size.Height) / 2, defaultSize.Location.Y + (defaultFont.Size.Height - comboBox2.Size.Height) / 2);

            label10.Location = new Point(defaultDir.Location.X + defaultDir.Size.Width - label10.Size.Width - (defaultFont.Size.Height - comboBox1.Size.Height) / 2, defaultDir.Location.Y + (defaultDir.Size.Height-label10.Size.Height)/2);
            label10.BringToFront();
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

        private void initializeFontCombo()
        {
            comboBox1.Items.Clear();

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                comboBox1.Items.Add(font.Name);
            }

            comboBox1.SelectedItem = Properties.Settings.Default.fontFamily;
        }

        private void theme_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.fontFamily = comboBox1.SelectedItem.ToString();
            Properties.Settings.Default.Save();
            Form1 form1 = (Form1)this.FindForm();
            
            if (form1.UC2.TabIndex == 1) form1.UC2.TabIndex = 0;
            else form1.UC2.TabIndex = 1;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        int[] size = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void initializeSizeCombo()
        {

            comboBox2.Items.Clear();

            foreach (int x in this.size)
            {
                comboBox2.Items.Add(x);
            }

            comboBox2.Text = Properties.Settings.Default.fontSize.ToString();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            Form1 form1 = (Form1)this.FindForm();
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();

            comboBox1.SelectedItem = Properties.Settings.Default.fontFamily;
            comboBox2.Text = Properties.Settings.Default.fontSize.ToString();

            label10.Text = Properties.Settings.Default.initialDirectory;
            analyzersettings_Resize(sender, e);

            if (form1.UC2.TabIndex == 1) form1.UC2.TabIndex = 0;
            else form1.UC2.TabIndex = 1;

            if (Settings.Default.Properties["initialDirectory"].DefaultValue.ToString() == Properties.Settings.Default.initialDirectory)
            {
                showFileDialog.BackColor = System.Drawing.ColorTranslator.FromHtml("#e3e3e3");
                pictureBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#e3e3e3");
                showFileDialog.Enabled = false;
            }
            else
            {
                showFileDialog.BackColor = System.Drawing.ColorTranslator.FromHtml("#fdfdfd");
                pictureBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fdfdfd");
                showFileDialog.Enabled = true;
            }
            showFileDialog.Refresh();

            if (Properties.Settings.Default.showFolderDialog)
            {
                pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"\..\..\bin\Debug\square-checked-regular.png");
            }
            else
            {
                pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"\..\..\bin\Debug\square-unchecked-regular.png");
            }
        }

        private void defaultDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.initialDirectory = folderBrowserDialog1.SelectedPath.ToString();
                Properties.Settings.Default.Save();
                label10.Text = Properties.Settings.Default.initialDirectory;
                analyzersettings_Resize(sender, e);
                showFileDialog.Refresh();
            }
            
        }

        private void defaultDir_MouseDown(object sender, MouseEventArgs e)
        {
            label10.BackColor = System.Drawing.ColorTranslator.FromHtml($"#cde4f8");
        }

        private void defaultDir_MouseEnter(object sender, EventArgs e)
        {
            label10.BackColor = System.Drawing.ColorTranslator.FromHtml($"#e0eef9");
        }

        private void defaultDir_MouseUp(object sender, MouseEventArgs e)
        {
            label10.BackColor = System.Drawing.ColorTranslator.FromHtml($"#e0eef9");
        }

        private void defaultDir_MouseLeave(object sender, EventArgs e)
        {
            label10.BackColor = System.Drawing.ColorTranslator.FromHtml($"#fdfdfd");
        }

        private void showFileDialog_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.showFolderDialog = !Properties.Settings.Default.showFolderDialog;
            Properties.Settings.Default.Save();
            if (Properties.Settings.Default.showFolderDialog)
            {
                pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"\..\..\bin\Debug\square-checked-regular.png");
            }
            else
            {
                pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"\..\..\bin\Debug\square-unchecked-regular.png");
            }
            showFileDialog.Refresh();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void defaultFont_Paint(object sender, PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, "Default Font", new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Regular), new Point(15, 10), Color.Black, TextFormatFlags.NoPrefix);
            TextRenderer.DrawText(e.Graphics, "Initial font in editing area after startup of the app.", new Font(Properties.Appearance.Default.FontFamily, 12, FontStyle.Regular), new Point(15, 53), Color.Black, TextFormatFlags.NoPrefix);

        }

        private void defaultSize_Paint(object sender, PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, "Default Font Size", new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Regular), new Point(15, 10), Color.Black, TextFormatFlags.NoPrefix);
            TextRenderer.DrawText(e.Graphics, "Initial font size in editing area after startup of the app.", new Font(Properties.Appearance.Default.FontFamily, 12, FontStyle.Regular), new Point(15, 53), Color.Black, TextFormatFlags.NoPrefix);

        }

        private void defaultDir_Paint(object sender, PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, "Document Saving Location", new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Regular), new Point(15, 10), Color.Black, TextFormatFlags.NoPrefix);
            TextRenderer.DrawText(e.Graphics, "Folder that your saved documents will be saved in.", new Font(Properties.Appearance.Default.FontFamily, 12, FontStyle.Regular), new Point(15, 53), Color.Black, TextFormatFlags.NoPrefix);
            //TextRenderer.DrawText(e.Graphics, "Folder that your saved documents will be saved in.", new Font(Properties.Appearance.Default.FontFamily, 12, FontStyle.Regular), new Point(defaultDir.Size.Width - label10.Size.Width - 32, 20), Color.Black, TextFormatFlags.NoPrefix);
        }

        private void showFileDialog_Paint(object sender, PaintEventArgs e)
        {
            string text;
            if (Settings.Default.Properties["initialDirectory"].DefaultValue.ToString() == Properties.Settings.Default.initialDirectory)
            {
                showFileDialog.Enabled = false;
                text = "Define a path in the setting above to enable this setting.";
            }
            else
            {
                showFileDialog.Enabled = true;
                text = "When unchecked, no dialogs pop up for path definition. Instead, files automatically save in the path defined in the setting above.";
            }
            TextRenderer.DrawText(e.Graphics, "Show File Dialog", new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Regular), new Point(15, 10), Color.Black, TextFormatFlags.NoPrefix);
            TextRenderer.DrawText(e.Graphics, text, new Font(Properties.Appearance.Default.FontFamily, 12, FontStyle.Regular), new Point(15, 53), Color.Black, TextFormatFlags.NoPrefix);
        }

        private void reset_Paint(object sender, PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, "Reset Analyzer Settings", new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Regular), new Point(15, 10), Color.Black, TextFormatFlags.NoPrefix);

        }

        private void analyzersettings_BackColorChanged(object sender, EventArgs e)
        {
            var color = System.Drawing.ColorTranslator.FromHtml($"#{Properties.Appearance.Default.BackColor}");
            label1.BackColor = color;
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(comboBox2.Text, @"^\d+$"))
            {
                if (Convert.ToInt32(comboBox2.Text) <= 1000)
                {
                    Properties.Settings.Default.fontSize = Convert.ToInt32(comboBox2.Text);
                    Properties.Settings.Default.Save();
                    Form1 form1 = (Form1)this.FindForm();
                    if (form1.UC2.TabIndex == 1) form1.UC2.TabIndex = 0;
                    else form1.UC2.TabIndex = 1;
                }
                else
                {
                    comboBox2.Text = Settings.Default.Properties["fontSize"].DefaultValue.ToString();
                }
            }
            else
            {
                comboBox2.Text = Settings.Default.Properties["fontSize"].DefaultValue.ToString();
            }
        }

    }
}
