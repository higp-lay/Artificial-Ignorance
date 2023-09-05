using IronPdf;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.ColorSpaces;
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
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class UserControl2 : UserControl
    {
        public Tuple<double,double> rtbRatio, btnRatio;
        public UserControl2()
        {
            InitializeComponent();
            this.rtbRatio = new Tuple<double,double>((double)richTextBox1.Size.Width / this.Size.Width, (double)richTextBox1.Size.Height / this.Size.Height);
            this.btnRatio = new Tuple<double,double>((double)submit.Size.Width / this.Size.Width, (double)submit.Size.Height / this.Size.Height);
        }

        private void submit_Click(object sender, EventArgs e)
        {
            //string path = AppDomain.CurrentDomain.BaseDirectory + "wyk.txt";
            //List<string> lines = File.ReadAllLines(path).ToList();
            analyzer analyzer = new analyzer(richTextBox1.Text);
            //MessageBox.Show("Number of Characters: " + analyzer.numberOfCharacters().ToString());
            //MessageBox.Show("Number of Words: " + analyzer.numberOfWords().ToString());
            //MessageBox.Show("Number of Sentences: " + analyzer.numberOfSentences().ToString());
            //MessageBox.Show("Average Length of Sentences: " + analyzer.averageSentenceLength().ToString());
            //MessageBox.Show("Estimated reading time in seconds: " + analyzer.estimatedReadingSeconds().ToString());
            //MessageBox.Show("Estimated speaking time in seconds: " + analyzer.estimatedSpeakingSeconds().ToString());

            if(analyzer.essay.Length == 0)
            {
                MessageBox.Show("Your text is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            MatchCollection matches = analyzer.splitToWords();
            Dictionary <string, int> words = new Dictionary<string, int>();
            foreach (Match match in matches)
            {
                string modifiedMatch = match.ToString().ToLower().Trim();
                if (!words.ContainsKey(modifiedMatch)) words[modifiedMatch] = 1;
                else words[modifiedMatch]++;
            }
            /*
            foreach (var kvp in words)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }*/
            var sortedDict = from entry in words orderby entry.Value descending select entry;

            // PDF maker.
            // Reference: https://ironpdf.com/blog/using-ironpdf/csharp-create-pdf-tutorial/
            var pdf = new ChromePdfRenderer();
            string html = "<h1 style=\"text-align:center\">Artificial Ignorance (AI) Text Analyzer</h1>" +
                "<img style=\"margin-left:auto;margin-right:auto;display:block\" width=\"100px\" src=\"" + System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "logo.png") + "\">" +
                "<hr>" +
                "<p>" +
                    analyzer.essay +
                @"</p>
                <hr>
                <p> Number of Characters: " + analyzer.numberOfCharacters().ToString() + "</p>" +
                "<p> Number of Words: " + matches.Count + "</p>" +
                "<p> Number of Sentences: " + analyzer.numberOfSentences().ToString() + "</p>" +
                "<p> Average Length of Sentences: " + Math.Round(analyzer.averageSentenceLength(), 1, MidpointRounding.AwayFromZero).ToString() + "</p>" +
                "<p> Estimated reading time: " + Math.Round(analyzer.estimatedReadingSeconds(), 1, MidpointRounding.AwayFromZero).ToString() + "s</p>" +
                "<p> Estimated speaking time: " + Math.Round(analyzer.estimatedSpeakingSeconds(), 1, MidpointRounding.AwayFromZero).ToString() + "s</p>" +
                "<p> Frequently used words list: </p>" +
                "<ol style=\"font-size:15px\">";

            int cnt = 0;
            foreach(var kvp in sortedDict)
            {
                if (cnt >= 20) break;
                cnt++;
                html += "<li>" + kvp.Key + ": " + kvp.Value + "</p>";
            }
            html += "</ol>";


            PdfDocument doc = pdf.RenderHtmlAsPdf(html);
            doc.SaveAs(@"Report.pdf");
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string source = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Report.pdf"); 
                string path = System.IO.Path.Combine(folderBrowserDialog1.SelectedPath + @"\Report.pdf");
                //MessageBox.Show(source);
                //MessageBox.Show(path);
                try
                {
                    if (!File.Exists(source))
                    {
                        // This statement ensures that the file is created,  
                        // but the handle is not kept.  
                        using (FileStream fs = File.Create(source)) { }
                    }
                    // Ensure that the target does not exist.  
                    if (File.Exists(path))
                        File.Delete(path);
                    // Move the file.  
                    // If file.txt is not found
                    // then an exception will be shown
                    File.Move(source, path);
                    //Console.WriteLine("Moved");
                    if (File.Exists(path))
                    {
                        MessageBox.Show("Report saved in " + folderBrowserDialog1.SelectedPath, "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error occured. Unable to save the report.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void import_Click(object sender, EventArgs e)
        {
            // Icons: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messageboxicon?view=windowsdesktop-7.0&redirectedfrom=MSDN
            MessageBox.Show("We now only support files importing with .txt format", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            //openFileDialog1.Filter = "txt files (*.txt)|*.txt|rtf files (*.rtf)|*.rtf|word files (*.doc,*.docx)|.doc;.docx|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                MessageBox.Show(Path.GetFileName(openFileDialog1.FileName) + " has imported successfully!", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length == 0)
            {
                MessageBox.Show("Your text is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|rtf files (*.rtf)|*.rtf";
            saveFileDialog1.FilterIndex = 1;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                MessageBox.Show("Text has saved successfully as " + Path.GetFileName(saveFileDialog1.FileName), "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            var cnt = richTextBox1.Text.Length;
            if(richTextBox1.Text == "Type, paste, or import your text here." && richTextBox1.ForeColor == System.Drawing.ColorTranslator.FromHtml("#c0c0c0"))
            {
                cnt = 0;
            }
            wordTextBox.Text = cnt.ToString() + " words";
        }

        private void UserControl2_Resize(object sender, EventArgs e)
        {
            var location = this.Location;
            var buttonSize = submit.Size;
            var textBoxSize = textBox1.Size;
            var imageSize = pictureBox1.Size;
            //MessageBox.Show(this.rtbRatio.Item1.ToString());
            richTextBox1.Size = new System.Drawing.Size((int)(this.Size.Width * this.rtbRatio.Item1), (int)(this.Size.Height * this.rtbRatio.Item2));
            //MessageBox.Show(richTextBox1.Size.Height.ToString());
            var rtbSELocation = (X: richTextBox1.Location.X + richTextBox1.Size.Width, Y: richTextBox1.Location.Y + richTextBox1.Size.Height);
            submit.Location = new System.Drawing.Point((rtbSELocation.X + this.Size.Width) / 2 - textBoxSize.Width/2, rtbSELocation.Y - 50);
            import.Location = new System.Drawing.Point((rtbSELocation.X + this.Size.Width) / 2 - textBoxSize.Width / 2, rtbSELocation.Y - 100);
            save.Location = new System.Drawing.Point((rtbSELocation.X + this.Size.Width) / 2 - textBoxSize.Width / 2, rtbSELocation.Y - 150);
            textBox1.Location = new System.Drawing.Point((rtbSELocation.X + this.Size.Width) / 2 - textBoxSize.Width / 2, richTextBox1.Location.Y);
            pictureBox1.Location = new System.Drawing.Point((rtbSELocation.X + this.Size.Width) / 2 - textBoxSize.Width / 2, textBox1.Location.Y + textBox1.Size.Height + 20);
            textBox2.Location = new System.Drawing.Point((rtbSELocation.X + this.Size.Width) / 2 - textBoxSize.Width / 2, pictureBox1.Location.Y + pictureBox1.Size.Height + 20);
            wordTextBox.Location = new System.Drawing.Point(rtbSELocation.X - wordTextBox.Size.Width, rtbSELocation.Y + 10);
            boldButton.Location = new System.Drawing.Point(richTextBox1.Location.X, rtbSELocation.Y);
            italicButton.Location = new System.Drawing.Point(richTextBox1.Location.X + boldButton.Size.Width, rtbSELocation.Y);
            underlineButton.Location = new System.Drawing.Point(italicButton.Location.X + underlineButton.Size.Width, rtbSELocation.Y);
            strikeThroughButton.Location = new System.Drawing.Point(underlineButton.Location.X + strikeThroughButton.Size.Width, rtbSELocation.Y);

            //Console.WriteLine(this.Size.Width - buttonSize.Width);
            //richTextBox1.Size = new System.Drawing.Size(this.Size.Width-buttonSize.Width, (int)(this.Size.Height * this.rtbRatio.Item2));

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "Type, paste, or import your text here.")
            {
                richTextBox1.Text = "";
                richTextBox1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000"); 
            }
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
            var orgStyle = richTextBox1.SelectionFont.Style;
            var orgLength = richTextBox1.SelectionLength;
            var startIndex = richTextBox1.SelectionStart;
            var endIndex = startIndex + richTextBox1.SelectionLength - 1;
            string txt = "";
            richTextBox1.SelectionLength = 1;
            for (int i = startIndex; i <= endIndex; i++)
            {
                richTextBox1.SelectionStart = i;
                if (richTextBox1.SelectionFont.Style.ToString().IndexOf("Bold") != -1 && orgStyle.ToString().IndexOf("Bold") == -1)
                {

                }
                else if (richTextBox1.SelectionFont.Style.ToString().IndexOf("Bold") != -1)
                {
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.Name, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style & ~FontStyle.Bold);
                }
                else
                {
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.Name, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style | FontStyle.Bold);
                }
            }
            richTextBox1.SelectionStart = startIndex;
            richTextBox1.SelectionLength = orgLength;
        }

        private void italicButton_Click(object sender, EventArgs e)
        {
            var orgStyle = richTextBox1.SelectionFont.Style;
            var startIndex = richTextBox1.SelectionStart;
            var orgLength = richTextBox1.SelectionLength;
            var endIndex = startIndex + richTextBox1.SelectionLength - 1;
            string txt = "";
            richTextBox1.SelectionLength = 1;
            for (int i = startIndex; i <= endIndex; i++)
            {
                richTextBox1.SelectionStart = i;
                if (richTextBox1.SelectionFont.Style.ToString().IndexOf("Italic") != -1 && orgStyle.ToString().IndexOf("Italic") == -1)
                {

                }
                else if (richTextBox1.SelectionFont.Style.ToString().IndexOf("Italic") != -1)
                {
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.Name, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style & ~FontStyle.Italic);
                }
                else
                {
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.Name, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style | FontStyle.Italic);
                }
            }
            richTextBox1.SelectionStart = startIndex;
            richTextBox1.SelectionLength = orgLength;
        }

        private void underlineButton_Click(object sender, EventArgs e)
        {
            var orgStyle = richTextBox1.SelectionFont.Style;
            var startIndex = richTextBox1.SelectionStart;
            var endIndex = startIndex + richTextBox1.SelectionLength - 1;
            var orgLength = richTextBox1.SelectionLength;
            string txt = "";
            richTextBox1.SelectionLength = 1;
            for(int i = startIndex; i <= endIndex; i++)
            {
                richTextBox1.SelectionStart = i;
                if (richTextBox1.SelectionFont.Style.ToString().IndexOf("Underline") != -1 && orgStyle.ToString().IndexOf("Underline") == -1)
                {
                    
                } else if(richTextBox1.SelectionFont.Style.ToString().IndexOf("Underline") != -1)
                {
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.Name, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style & ~FontStyle.Underline);
                }
                else
                {
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.Name, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style | FontStyle.Underline);
                }
            }
            richTextBox1.SelectionStart = startIndex;
            richTextBox1.SelectionLength = orgLength;
            //MessageBox.Show(txt);
            /*
            var fontStyle = richTextBox1.SelectionFont.Style.ToString();
            MessageBox.Show(fontStyle);
            MessageBox.Show(fontStyle.IndexOf("Underline").ToString());
            if (fontStyle.IndexOf("Underline") != -1)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.Name, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style & ~ FontStyle.Underline);

            } else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.Name, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style | FontStyle.Underline);
            }
            */
        }

        private void UserControl2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.B)
            {
                MessageBox.Show("Test");
                boldButton_Click(sender, e);
            }
        }

        private void strikethrough_Click(object sender, EventArgs e)
        {
            var orgStyle = richTextBox1.SelectionFont.Style;
            var startIndex = richTextBox1.SelectionStart;
            var endIndex = startIndex + richTextBox1.SelectionLength - 1;
            var orgLength = richTextBox1.SelectionLength;
            string txt = "";
            richTextBox1.SelectionLength = 1;
            for (int i = startIndex; i <= endIndex; i++)
            {
                richTextBox1.SelectionStart = i;
                if (richTextBox1.SelectionFont.Style.ToString().IndexOf("Strikeout") != -1 && orgStyle.ToString().IndexOf("Strikeout") == -1)
                {

                }
                else if (richTextBox1.SelectionFont.Style.ToString().IndexOf("Strikeout") != -1)
                {
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.Name, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style & ~FontStyle.Strikeout);
                }
                else
                {
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.Name, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style | FontStyle.Strikeout);
                }
            }
            richTextBox1.SelectionStart = startIndex;
            richTextBox1.SelectionLength = orgLength;
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            this.UserControl2_Resize(sender, e);
            this.richTextBox1_Leave(sender, e);
            this.richTextBox1_TextChanged(sender, e);
        }
    }


    public class analyzer
    {
        public string essay;
        private const double readingwpm = 238, speakingwpm = 183;
        public analyzer(string essay)
        {
            this.essay = essay;
        }

        public bool isAbbr(int x)
        {
            // Reference: https://en.wikipedia.org/wiki/Title
            // Reference: 
            string[] a = { "Mr", "Ms", "Mx", "Mrs", "Hon", "Fr", "S", "St", "Dr", "Prof", "Doc" };
            for (int i = 0; i < a.Length; i++)
            {
                if (x - a[i].Length >= 0)
                {
                    //MessageBox.Show(essay.Substring(x - a[i].Length, a[i].Length) + ' ' + a[i]);
                    if (essay.Substring(x - a[i].Length, a[i].Length) == a[i]) return true;
                }
            }
            return false;
        }

        public bool isAlphaNumeric(char x)
        {
            return (x >= 'A' && x <= 'Z') || (x >= 'a' && x <= 'z') || (x >= '0' && x <= '9');
        }

        public int numberOfSentences()
        {
            int cnt = 0;
            bool flag = false;
            for (int i = 0; i < essay.Length; i++)
            {
                int tmp = cnt;
                cnt += Convert.ToInt32((essay[i] == '.' && !flag) || ((essay[i] == '!' || essay[i] == '?') && isAlphaNumeric(essay[i - 1])));
                //if (tmp != cnt) MessageBox.Show(i.ToString() + essay[i-1] + essay[i] + essay[i+1]);
                if (essay[i] == '.')
                {
                    flag = true;
                    if (isAbbr(i))
                    {
                        --cnt;
                        //MessageBox.Show("Abbr Detected");
                    }
                }
                else flag ^= flag;
            }

            return cnt;
        }

        public MatchCollection splitToWords()
        {
            string pattern = @"[-\w]+[\s\t\r\n]?";
            MatchCollection matches = Regex.Matches(this.essay, pattern);
            /*
            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
            */
            return matches; 
        }

        public int numberOfWords()
        {
            return splitToWords().Count;
        }

        public int numberOfCharacters()
        {
            return this.essay.Length;
        }

        public double estimatedReadingSeconds()
        {
            return numberOfWords() / readingwpm * 60;
        }
        public double estimatedSpeakingSeconds()
        {
            return numberOfWords() / speakingwpm * 60;
        }

        public double averageSentenceLength()
        {
            return (double)numberOfWords() / numberOfSentences();
        }
    }
}
