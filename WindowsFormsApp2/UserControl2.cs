using IronPdf;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.Web.UI;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Transactions;
using System.Windows.Controls;
using NetSpell;

using System.Web.UI.WebControls;
using NetSpell.SpellChecker.Dictionary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Documents;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using RichTextBoxEx;

namespace WindowsFormsApp2
{
    public partial class UserControl2 : System.Windows.Forms.UserControl
    {
        System.Drawing.Size initScreen = new System.Drawing.Size(1936, 1048);
        public UserControl2()
        {
            InitializeComponent();

        }
        public void changeFont()
        {

            label1.Font = new Font(Properties.Appearance.Default.FontFamily, 24, FontStyle.Bold);
            label2.Font = new Font(Properties.Appearance.Default.FontFamily, 13, FontStyle.Bold);
            wordslabel.Font = new Font(Properties.Appearance.Default.FontFamily, 12, FontStyle.Regular);

            save.Font = new Font(Properties.Appearance.Default.FontFamily, 10, FontStyle.Bold);
            import.Font = new Font(Properties.Appearance.Default.FontFamily, 10, FontStyle.Bold);
            submit.Font = new Font(Properties.Appearance.Default.FontFamily, 10, FontStyle.Bold);

            sizeCombo.Font = new Font(Properties.Appearance.Default.FontFamily, 14, FontStyle.Regular);
        }


        private void submit_Click(object sender, EventArgs e)
        {
            var color = System.Drawing.ColorTranslator.FromHtml($"#{Properties.Appearance.Default.BackColor}");

            if (richTextBox1.Text.Length == 0 || (richTextBox1.Text == "Type, paste, or import your text here." && richTextBox1.ForeColor == System.Drawing.ColorTranslator.FromHtml("#c0c0c0")))
            {
                MessageBox.Show("Your text is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            var dtnp = System.DateTime.Now.ToString("yyyy-MM-dd hhmmss");
            var dtn = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

            popupform popupform = new popupform(richTextBox1.Text, dtnp);
            popupform.Show();
        }


        private void import_Click(object sender, EventArgs e)
        {
            // Icons: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messageboxicon?view=windowsdesktop-7.0&redirectedfrom=MSDN
            MessageBox.Show("We now only support files importing with .txt and .rtf format", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            openFileDialog1.Filter = "rtf files (*.rtf)|*.rtf|txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(openFileDialog1.FileName).ToLower() != ".txt")
                {
                    richTextBox1.Rtf = File.ReadAllText(openFileDialog1.FileName);
                } else
                {
                    richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                }
                MessageBox.Show(Path.GetFileName(openFileDialog1.FileName) + " has imported successfully!", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                richTextBox1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length == 0 || (richTextBox1.Text == "Type, paste, or import your text here." && richTextBox1.ForeColor == System.Drawing.ColorTranslator.FromHtml("#c0c0c0")))
            {
                MessageBox.Show("Your text is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            MessageBox.Show("Please save your file as .rtf format if you want to preserve your text styles.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            saveFileDialog1.Filter = "rtf files (*.rtf)|*.rtf|txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.InitialDirectory = Properties.Settings.Default.initialDirectory;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(saveFileDialog1.FileName).ToLower() == ".rtf")
                {
                    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                    MessageBox.Show("Text has saved successfully as " + Path.GetFileName(saveFileDialog1.FileName), "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else if (Path.GetExtension(saveFileDialog1.FileName).ToLower() == ".txt")
                {
                    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    MessageBox.Show("Text has saved successfully as " + Path.GetFileName(saveFileDialog1.FileName), "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"[-\w]+('s)*";
            MatchCollection matches = Regex.Matches(richTextBox1.Text, pattern);
            var cnt = matches.Count;
            if (richTextBox1.Text == "Type, paste, or import your text here." && richTextBox1.ForeColor == System.Drawing.ColorTranslator.FromHtml("#c0c0c0"))
            {
                cnt = 0;
            }
            wordslabel.Text = cnt.ToString() + " word";
            if (cnt != 1) wordslabel.Text += "s";
        }

        private void UserControl2_Resize(object sender, EventArgs e)
        {
            var location = this.Location;
            var buttonSize = submit.Size;
            var textBoxSize = label1.Size;
            var imageSize = pictureBox1.Size;

            //MessageBox.Show(this.rtbRatio.Item1.ToString());
            richTextBox1.Size = new System.Drawing.Size(1600 + (this.Size.Width-initScreen.Width), 950 + (this.Size.Height-initScreen.Height));
            //MessageBox.Show(richTextBox1.Size.Height.ToString());
            var rtbSELocation = (X: richTextBox1.Location.X + richTextBox1.Size.Width, Y: richTextBox1.Location.Y + richTextBox1.Size.Height);
            submit.Location = new System.Drawing.Point((rtbSELocation.X + this.Size.Width) / 2 - textBoxSize.Width / 2, rtbSELocation.Y - 50);
            import.Location = new System.Drawing.Point((rtbSELocation.X + this.Size.Width) / 2 - textBoxSize.Width / 2, rtbSELocation.Y - 100);
            save.Location = new System.Drawing.Point((rtbSELocation.X + this.Size.Width) / 2 - textBoxSize.Width / 2, rtbSELocation.Y - 150);
            find.Location = new System.Drawing.Point((rtbSELocation.X + this.Size.Width) / 2 - textBoxSize.Width / 2, rtbSELocation.Y - 200);
            label1.Location = new System.Drawing.Point((rtbSELocation.X + this.Size.Width) / 2 - textBoxSize.Width / 2, richTextBox1.Location.Y);
            pictureBox1.Location = new System.Drawing.Point((rtbSELocation.X + this.Size.Width) / 2 - textBoxSize.Width / 2, label1.Location.Y + label1.Size.Height + 20);
            label2.Location = new System.Drawing.Point((rtbSELocation.X + this.Size.Width) / 2 - textBoxSize.Width / 2, pictureBox1.Location.Y + pictureBox1.Size.Height + 20);
            wordslabel.Location = new System.Drawing.Point(rtbSELocation.X - wordslabel.Size.Width, rtbSELocation.Y + 10);
            boldButton.Location = new System.Drawing.Point(richTextBox1.Location.X, rtbSELocation.Y);
            italicButton.Location = new System.Drawing.Point(richTextBox1.Location.X + boldButton.Size.Width, rtbSELocation.Y);
            underlineButton.Location = new System.Drawing.Point(italicButton.Location.X + underlineButton.Size.Width, rtbSELocation.Y);
            strikeThroughButton.Location = new System.Drawing.Point(underlineButton.Location.X + strikeThroughButton.Size.Width, rtbSELocation.Y);
            fontCombo.Location = new System.Drawing.Point(strikeThroughButton.Location.X + strikeThroughButton.Size.Width + 10, rtbSELocation.Y);
            leftAlign.Location = new System.Drawing.Point(fontCombo.Location.X + fontCombo.Size.Width + 10, rtbSELocation.Y);
            centerAlign.Location = new System.Drawing.Point(leftAlign.Location.X + leftAlign.Size.Width, rtbSELocation.Y);
            rightAlign.Location = new System.Drawing.Point(centerAlign.Location.X + centerAlign.Size.Width, rtbSELocation.Y);
            sizeCombo.Location = new System.Drawing.Point(rightAlign.Location.X + rightAlign.Size.Width + 10, rtbSELocation.Y);
            button1.Location = new System.Drawing.Point(sizeCombo.Location.X + sizeCombo.Size.Width, rtbSELocation.Y);
            button2.Location = new System.Drawing.Point(button1.Location.X + button1.Size.Width, rtbSELocation.Y);

            //Console.WriteLine(this.Size.Width - buttonSize.Width);
            //richTextBox1.Size = new System.Drawing.Size(this.Size.Width-buttonSize.Width, (int)(this.Size.Height * this.rtbRatio.Item2));

        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "Type, paste, or import your text here.")
            {
                richTextBox1.Text = "";
                richTextBox1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
            }

            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = System.Drawing.Color.White;
            richTextBox1.DeselectAll();
        }

        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                richTextBox1.Text = "Type, paste, or import your text here.";
                richTextBox1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#c0c0c0");
            }
            this.richTextBox1_TextChanged(sender, e);
        }

        private void boldButton_Click(object sender, EventArgs e)
        {
            changeFontStyle(FontStyle.Bold, "Bold", "");
        }

        private void italicButton_Click(object sender, EventArgs e)
        {
            changeFontStyle(FontStyle.Italic, "Italic", "");
        }

        private void underlineButton_Click(object sender, EventArgs e)
        {
            changeFontStyle(FontStyle.Underline, "Underline", "");
        }


        private void strikethrough_Click(object sender, EventArgs e)
        {
            changeFontStyle(FontStyle.Strikeout, "Strikeout", "");
        }

        private void fontCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont is null) return;
            var startIndex = richTextBox1.SelectionStart;
            var endIndex = startIndex + richTextBox1.SelectionLength - 1;
            var orgLength = richTextBox1.SelectionLength;
            richTextBox1.SelectionLength = 1;
            for (int i = startIndex; i <= endIndex; i++)
            {
                richTextBox1.SelectionStart = i;
                richTextBox1.SelectionFont = new Font(fontCombo.SelectedItem.ToString(), richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
            }
            richTextBox1.SelectionStart = startIndex;
            richTextBox1.SelectionLength = orgLength;
        }

        private void changeFontStyle(FontStyle x, string s, string f)
        {
            var orgStyle = richTextBox1.SelectionFont.Style;
            var startIndex = richTextBox1.SelectionStart;
            var endIndex = startIndex + richTextBox1.SelectionLength - 1;
            var orgLength = richTextBox1.SelectionLength;
            richTextBox1.SelectionLength = 1;
            Cursor.Current = Cursors.WaitCursor;
            for (int i = startIndex; i <= endIndex; i++)
            {
                richTextBox1.SelectionStart = i;
                if(f == "") {
                    if (richTextBox1.SelectionFont.Style.ToString().IndexOf(s) != -1 && orgStyle.ToString().IndexOf(s) != -1)
                    {
                        richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.Name, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style & ~x);
                    }
                    else if (richTextBox1.SelectionFont.Style.ToString().IndexOf(s) == -1)
                    {
                        richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.Name, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style | x);
                    }
                } else
                {
                    richTextBox1.SelectionFont = new Font(f, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
                }

            }
            Cursor.Current = Cursors.Default;
            richTextBox1.SelectionStart = startIndex;
            richTextBox1.SelectionLength = orgLength;
            //richTextBox1.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#9bcaef");
        }


        private Dictionary<string, bool> shouldLightUp(int startIndex, int length)
        {
            Dictionary<string, bool> d = new Dictionary<string, bool>();
            string[] styles = { "Bold", "Italic", "Underline", "Strikeout" };
            
            foreach(var style in styles)
            {
                d[style] = true;
            }
            richTextBox1.SelectionLength = 1;
            for(int i = startIndex; i < startIndex + length; i++)
            {
                richTextBox1.SelectionStart = startIndex;
                foreach(var style in styles)
                {
                    d[style] &= richTextBox1.SelectionFont.Style.ToString().IndexOf(style) != -1;
                }
            }
            richTextBox1.SelectionStart = startIndex;
            richTextBox1.SelectionLength = length;
            return d;
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont is null)
                fontCombo.SelectedIndex = -1;
            else {
                //fontCombo.SelectedIndex = fontCombo.FindStringExact(richTextBox1.SelectionFont.Name.ToString());
            }

            //MessageBox.Show(richTextBox1.SelectionFont.ToString());
        /*
            //MessageBox.Show(richTextBox1.SelectionStart.ToString() + ' ' + richTextBox1.SelectionLength.ToString());
            Dictionary<string, bool> d = shouldLightUp(richTextBox1.SelectionStart, richTextBox1.SelectionLength);
            if (richTextBox1.SelectionLength == 0) return;
            if (d["Bold"])
                boldButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#d3d3d3");
            else
                boldButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");

            if (d["Strikeout"])
                italicButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#d3d3d3");
            else
                italicButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");

            if (d["Underline"])
                underlineButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#d3d3d3");
            else
                underlineButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");

            if (d["Strikeout"])
                strikeThroughButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#d3d3d3");
            else
                strikeThroughButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
        */
        }

        private void UserControl2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.B:
                        MessageBox.Show("test");
                        break;

                    default:
                        break;
                }
            }
        }

        private void initializeFontCombo(object sender, EventArgs e)
        {

            fontCombo.Items.Clear();

            List<string> fonts = new List<string>();

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                fontCombo.Items.Add(font.Name);
            }

            fontCombo.SelectedItem = Properties.Settings.Default.fontFamily;
        }

        // 80 90 100 110 120 ...
        int[] size = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
        int selectedSize;
        private void initializeSizeCombo(object sender, EventArgs e)
        {

            sizeCombo.Items.Clear();

            foreach (int x in this.size)
            {
                sizeCombo.Items.Add(x);
            }

            sizeCombo.SelectedItem = Properties.Settings.Default.fontSize;
            this.selectedSize = sizeCombo.SelectedIndex;
        }


        private void fontCombo_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;
            Brush brush = Brushes.Black;
            string text = fontCombo.Items[e.Index].ToString();
            Font font = new Font(text, 16);

            //MessageBox.Show(text);

            e.Graphics.DrawString(text, font, brush, e.Bounds);
        }

        private void fontCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont is null) return;
            //MessageBox.Show(fontCombo.SelectedItem.ToString());
            FontStyle x = new FontStyle();
            changeFontStyle(x, "", fontCombo.SelectedItem.ToString());
        }


        private void centerAlign_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void rightAlign_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void fullAlign_Click(object sender, EventArgs e)
        {
            //richTextBox1.SelectionAlignment = HorizontalAlignment.Justify;
        }

        private void leftAlign_Click_1(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void wordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedSize++;
            //MessageBox.Show(selectedSize.ToString());
            if (selectedSize >= 0 && selectedSize < size.Length)
            {
                sizeCombo.SelectedIndex = selectedSize;
                sizeCombo.Text = size[selectedSize].ToString();
            } else if(selectedSize >= size.Length)
            {
                sizeCombo.Text = ((selectedSize - 16) * 10 + 80).ToString();
            } else
            {
                selectedSize = Math.Max(-7, selectedSize);
                sizeCombo.Text = (8 + selectedSize).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedSize--;
            if (selectedSize >= 0 && selectedSize < size.Length)
            {
                sizeCombo.SelectedIndex = selectedSize;
            } else if (selectedSize >= size.Length)
            {
                sizeCombo.Text = ((selectedSize - 16) * 10 + 80).ToString();
            } else
            {
                selectedSize = Math.Max(-7, selectedSize);
                sizeCombo.Text = (8 + selectedSize).ToString();
            }
        }

        private void sizeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            sizeCombo_TextUpdate(sender, e);
        }

        private void sizeCombo_TextUpdate(object sender, EventArgs e)
        {
            if(Regex.IsMatch(sizeCombo.Text, @"^\d+$")) {
                if (Convert.ToInt32(sizeCombo.Text) <= 1000)
                {
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.Name, Int32.Parse(sizeCombo.Text), richTextBox1.SelectionFont.Style);
                } else
                {
                    sizeCombo.SelectedItem = Properties.Settings.Default.fontSize;
                    this.selectedSize = sizeCombo.SelectedIndex;
                }
            } else
            {
                sizeCombo.SelectedItem = Properties.Settings.Default.fontSize;
                this.selectedSize = sizeCombo.SelectedIndex;
            }
        }

        private void UserControl2_StyleChanged(object sender, EventArgs e)
        {
        }

        private void UserControl2_SystemColorsChanged(object sender, EventArgs e)
        {
        }

        private void UserControl2_BackColorChanged(object sender, EventArgs e)
        {
            var color = System.Drawing.ColorTranslator.FromHtml($"#{Properties.Appearance.Default.BackColor}");
            label1.BackColor = color;
            label2.BackColor = color;
            wordslabel.BackColor = color;
            
        }

        private void UserControl2_FontChanged(object sender, EventArgs e)
        {
            //label1.Font = new Font(Properties.Settings.Default.fontFamily, 24, FontStyle.Bold);
            //label2.Font = new Font(Properties.Settings.Default.fontFamily, 13, FontStyle.Bold);
            //find.Font = save.Font = import.Font = submit.Font = new Font(Properties.Settings.Default.fontFamily, 10, FontStyle.Regular);
            //wordslabel.Font = new Font(Properties.Settings.Default.fontFamily, 13, FontStyle.Bold);
        }

        private void UserControl2_TabStopChanged(object sender, EventArgs e)
        {
            changeFont();

        }

        private void UserControl2_TabIndexChanged(object sender, EventArgs e)
        {
            fontCombo.SelectedItem = Properties.Settings.Default.fontFamily;
            sizeCombo.Text = Properties.Settings.Default.fontSize.ToString();
            if (richTextBox1.Text.Length == 0 || (richTextBox1.Text == "Type, paste, or import your text here." && richTextBox1.ForeColor == System.Drawing.ColorTranslator.FromHtml("#c0c0c0")))
            {
                richTextBox1.Font = new Font(Properties.Settings.Default.fontFamily, Properties.Settings.Default.fontSize, FontStyle.Regular);
            }
        }
        private void UserControl2_Load(object sender, EventArgs e)
        {

            fontCombo.DrawMode = DrawMode.OwnerDrawFixed;
            fontCombo.DrawItem += new DrawItemEventHandler(fontCombo_DrawItem);

            //richTextBox1.SpellCheck.IsEnabled = true;

            //System.Windows.Forms.Integration.ElementHost elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            //System.Windows.Controls.RichTextBox richTextBox2 = new System.Windows.Controls.RichTextBox();
            ////richTextBox2.SpellCheck.IsEnabled = true;
            //elementHost1.Child = richTextBox2;
            //this.Controls.Add(elementHost1);

            changeFont();

            this.UserControl2_Resize(sender, e);
            this.richTextBox1_Leave(sender, e);
            this.richTextBox1_TextChanged(sender, e);
            this.initializeFontCombo(sender, e);
            this.initializeSizeCombo(sender, e);

            var color = System.Drawing.ColorTranslator.FromHtml($"#{Properties.Appearance.Default.BackColor}");
            label1.BackColor = color;
            label2.BackColor = color;
            wordslabel.BackColor = color;
        }

        private void find_Click(object sender, EventArgs e)
        {
            findandreplace findandreplace1 = new findandreplace();
            var color = System.Drawing.ColorTranslator.FromHtml($"#{Properties.Appearance.Default.BackColor}");
            findandreplace1.BackColor = color;
            findandreplace1.Show(this);

            string essay = richTextBox1.Text;
            for(int i = 0; i < essay.Length; i++)
            {

            }
        }

        private void richTextBox1_MouseEnter(object sender, EventArgs e)
        {
            Form1 form = (Form1)this.FindForm();
            if(form.selectLength != -1 && form.selectStart != -1)
            {
                richTextBox1.SelectionLength = form.selectLength;
                richTextBox1.SelectionStart = form.selectStart;
            }
        }
    }

    public class ActionToCallEvent : EventArgs
    {
        private ActionToCallEvent() { }
    }
}
