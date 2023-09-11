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
using IronPython;
using NetSpell;

using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting.Runtime;
using System.Web.UI.WebControls;
using static IronPython.Modules.PythonRegex;
using NetSpell.SpellChecker.Dictionary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using IronPython.Runtime.Types;
using System.Windows.Documents;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static IronPython.Modules._ast;
using RichTextBoxEx;
using static Community.CsharpSqlite.Sqlite3;
using IronPython.Runtime.Operations;

namespace WindowsFormsApp2
{
    public partial class UserControl2 : System.Windows.Forms.UserControl
    {
        System.Drawing.Size initScreen = new System.Drawing.Size(1936, 1048);
        analyzer analyzer = new analyzer();
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

        private string essayHTML(string essay)
        {
            string l = @"<span style=""border-bottom: 1px dotted #ff0000;padding:1px"">
                <span style=""border-bottom: 1px dotted #ff0000;"">";
            string m = "";
            string r = @" </span>
            </span>";
            string html = "";
            MatchCollection matches = Regex.Matches(essay, @"[\w']+|[.,!?;]");
            Regex rg = new Regex(@"^[a-zA-Z0-9]+$");
            analyzer.changeEssay(essay);
            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                if(rg.IsMatch(match.ToString()))
                {
                    if(match.Index != 0)
                    {
                        html += " ";
                    }
                    if(analyzer.isAWord(match.ToString())) 
                    {
                        html += match.ToString();
                    } else
                    {
                        html += l + match.ToString() + r;
                    }
                } else html += match.ToString();
            }
            return html;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            var color = System.Drawing.ColorTranslator.FromHtml($"#{Properties.Appearance.Default.BackColor}");
            //string path = AppDomain.CurrentDomain.BaseDirectory + "wyk.txt";
            //List<string> lines = File.ReadAllLines(path).ToList();
            analyzer.changeEssay(richTextBox1.Text);
            //MessageBox.Show("Number of Characters: " + analyzer.numberOfCharacters().ToString());
            //MessageBox.Show("Number of Words: " + analyzer.numberOfWords().ToString());
            //MessageBox.Show("Number of Sentences: " + analyzer.numberOfSentences().ToString());
            //MessageBox.Show("Average Length of Sentences: " + analyzer.averageSentenceLength().ToString());
            //MessageBox.Show("Estimated reading time in seconds: " + analyzer.estimatedReadingSeconds().ToString());
            //MessageBox.Show("Estimated speaking time in seconds: " + analyzer.estimatedSpeakingSeconds().ToString());

            if (richTextBox1.Text.Length == 0 || (richTextBox1.Text == "Type, paste, or import your text here." && richTextBox1.ForeColor == System.Drawing.ColorTranslator.FromHtml("#c0c0c0")))
            {
                MessageBox.Show("Your text is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }


            /*
            foreach (var kvp in words)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }*/

            Cursor.Current = Cursors.WaitCursor;
            var dtnp = System.DateTime.Now.ToString("yyyy-MM-dd hhmmss");
            var dtn = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

            Form1 myParent = (Form1)this.Parent;
            var formPopup = new Form();
            formPopup.Icon = myParent.Icon;
            formPopup.Text = $"Report {dtnp}";
            formPopup.MaximumSize = new System.Drawing.Size(600, 600);
            formPopup.MinimumSize = new System.Drawing.Size(600, 600);

            var newcolor = System.Drawing.Color.FromArgb(Math.Min(255, Int32.Parse(color.R.ToString()) + 62), Math.Min(Int32.Parse(color.G.ToString()) + 48, 255), Math.Min(Int32.Parse(color.B.ToString()) + 33, 255));
            formPopup.BackColor = newcolor;

            var panelPopup = new System.Windows.Forms.Panel();
            formPopup.Controls.Add(panelPopup);
            panelPopup.Size = new System.Drawing.Size(600, 510);
            panelPopup.Location = new System.Drawing.Point(0, 0);
            panelPopup.AutoScroll = false;
            panelPopup.HorizontalScroll.Enabled = false;
            panelPopup.HorizontalScroll.Visible = false;
            panelPopup.HorizontalScroll.Maximum = 0;
            panelPopup.AutoScroll = true;
            panelPopup.BackColor = color;

            var closebutton = new System.Windows.Forms.Button();
            formPopup.Controls.Add(closebutton);
            closebutton.Text = "Close";
            closebutton.Font = new Font(Properties.Appearance.Default.FontFamily, 12, FontStyle.Regular);
            closebutton.Size = new System.Drawing.Size(70, 30);
            closebutton.Location = new System.Drawing.Point(formPopup.Size.Width - closebutton.Width - 20, panelPopup.Size.Height + 10);
            closebutton.FlatStyle = FlatStyle.Flat;
            closebutton.Click += (s, a) =>
            {
                formPopup.Close();
            };

            var genpdfbutton = new System.Windows.Forms.Button();
            formPopup.Controls.Add(genpdfbutton);
            genpdfbutton.Text = "Download PDF Report";
            genpdfbutton.Font = new Font(Properties.Appearance.Default.FontFamily, 12, FontStyle.Regular);
            genpdfbutton.Size = new System.Drawing.Size(200, 30);
            genpdfbutton.Location = new System.Drawing.Point(closebutton.Location.X - genpdfbutton.Width - 20, panelPopup.Size.Height + 10);
            genpdfbutton.FlatStyle = FlatStyle.Flat;
            genpdfbutton.Click += (s, a) =>
            {
                generatePDFReport();
            };

            var generalMetrics = new System.Windows.Forms.TextBox();
            
            panelPopup.Controls.Add(generalMetrics);
            generalMetrics.Text = "General Metrics";
            generalMetrics.Font = new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Underline);
            generalMetrics.Location = new System.Drawing.Point(10, 10);
            generalMetrics.Size = new System.Drawing.Size(240, 30);
            generalMetrics.ReadOnly = true;
            generalMetrics.BackColor = color;
            generalMetrics.BorderStyle = System.Windows.Forms.BorderStyle.None;

            var characterl = new System.Windows.Forms.TextBox();
            panelPopup.Controls.Add(characterl);
            characterl.Text = "Characters";
            characterl.Font = new Font(Properties.Appearance.Default.FontFamily, 14, FontStyle.Regular);
            characterl.Size = new System.Drawing.Size(100, 20);
            characterl.ReadOnly = true;
            characterl.BackColor = color;
            characterl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            characterl.Location = new System.Drawing.Point(generalMetrics.Location.X + 10, generalMetrics.Location.Y + generalMetrics.Size.Height + 10);

            var characterr = new System.Windows.Forms.TextBox();
            panelPopup.Controls.Add(characterr);
            characterr.Text = analyzer.characters.ToString();
            characterr.Font = new Font(Properties.Appearance.Default.FontFamily, 14, FontStyle.Regular);
            characterr.AutoSize = true;
            characterr.ReadOnly = true;
            //characterr.Size = new Size(100, 20);
            characterr.BackColor = color;
            characterr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            characterr.Location = new System.Drawing.Point(formPopup.Size.Width / 2 - characterr.Size.Width - 10, characterl.Location.Y);

            var wordl = new System.Windows.Forms.TextBox();
            panelPopup.Controls.Add(wordl);
            wordl.Text = "Words";
            wordl.Font = new Font(Properties.Appearance.Default.FontFamily, 14, FontStyle.Regular);
            wordl.Size = new System.Drawing.Size(100, 20);
            wordl.ReadOnly = true;
            wordl.BackColor = color;
            wordl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            wordl.Location = new System.Drawing.Point(generalMetrics.Location.X + 10, characterl.Location.Y + characterl.Size.Height + 10);

            var wordr = new System.Windows.Forms.TextBox();
            panelPopup.Controls.Add(wordr);
            wordr.Text = analyzer.words.ToString();
            wordr.Font = new Font(Properties.Appearance.Default.FontFamily, 14, FontStyle.Regular);
            //wordr.Size = new Size(100, 20);
            wordr.AutoSize = true;
            wordr.ReadOnly = true;
            wordr.BackColor = color;
            wordr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            wordr.Location = new System.Drawing.Point(formPopup.Size.Width / 2 - wordr.Size.Width - 10, wordl.Location.Y);

            var sentencel = new System.Windows.Forms.TextBox();
            panelPopup.Controls.Add(sentencel);
            sentencel.Text = "Sentences";
            sentencel.Font = new Font(Properties.Appearance.Default.FontFamily, 14, FontStyle.Regular);
            sentencel.Size = new System.Drawing.Size(100, 20);
            sentencel.ReadOnly = true;
            sentencel.BackColor = color;
            sentencel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            sentencel.Location = new System.Drawing.Point(generalMetrics.Location.X + 10, wordl.Location.Y + wordl.Size.Height + 10);

            var sentencer = new System.Windows.Forms.TextBox();
            panelPopup.Controls.Add(sentencer);
            sentencer.Text = analyzer.sentences.ToString();
            sentencer.Font = new Font(Properties.Appearance.Default.FontFamily, 14, FontStyle.Regular);
            //sentencer.Size = new Size(100, 20);
            sentencer.AutoSize = true;
            sentencer.ReadOnly = true;
            sentencer.BackColor = color;
            sentencer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            sentencer.Location = new System.Drawing.Point(formPopup.Size.Width / 2 - sentencer.Size.Width - 10, sentencel.Location.Y);

            var readingl = new System.Windows.Forms.TextBox();
            panelPopup.Controls.Add(readingl);
            readingl.Text = "Reading time";
            readingl.Font = new Font(Properties.Appearance.Default.FontFamily, 14, FontStyle.Regular);
            readingl.Size = new System.Drawing.Size(120, 20);
            readingl.ReadOnly = true;
            readingl.BackColor = color;
            readingl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            readingl.Location = new System.Drawing.Point(formPopup.Size.Width / 2 - 10, characterl.Location.Y);

            var readingr = new System.Windows.Forms.TextBox();
            panelPopup.Controls.Add(readingr);
            readingr.Text = Math.Round(analyzer.readingt, 1, MidpointRounding.AwayFromZero).ToString() + 's';
            readingr.Font = new Font(Properties.Appearance.Default.FontFamily, 14, FontStyle.Regular);
            //readingr.Size = new Size(100, 20);
            readingr.AutoSize = true;
            readingr.ReadOnly = true;
            readingr.BackColor = color;
            readingr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            readingr.Location = new System.Drawing.Point(formPopup.Size.Width - readingr.Size.Width - 10, readingl.Location.Y);

            var readinginfo = new PictureBox();
            panelPopup.Controls.Add(readinginfo);
            readinginfo.Image = System.Drawing.Image.FromFile(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "circle-info-solid.png"));
            readinginfo.Size = new System.Drawing.Size(readingl.Height - 10, readingl.Height - 10);
            readinginfo.Location = new System.Drawing.Point(readingr.Location.X - readinginfo.Size.Width - 20, (readingr.Location.Y + (readingr.Size.Height - readinginfo.Size.Height) / 2));
            readinginfo.SizeMode = PictureBoxSizeMode.StretchImage;
            readinginfo.BringToFront();
            readinginfo.MouseHover += (s, a) =>
            {
                System.Windows.Forms.ToolTip tt = new System.Windows.Forms.ToolTip();
                tt.SetToolTip(readinginfo, "Calculated using the average reading speed of 238 words per minute.");
            };

            
            var speakingl = new System.Windows.Forms.TextBox();
            panelPopup.Controls.Add(speakingl);
            speakingl.Text = "Speaking time";
            speakingl.Font = new Font(Properties.Appearance.Default.FontFamily, 14, FontStyle.Regular);
            speakingl.Size = new System.Drawing.Size(120, 20);
            speakingl.ReadOnly = true;
            speakingl.BackColor = color;
            speakingl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            speakingl.Location = new System.Drawing.Point(formPopup.Size.Width / 2 - 10, wordl.Location.Y);

            var speakingr = new System.Windows.Forms.TextBox();
            panelPopup.Controls.Add(speakingr);
            speakingr.Text = Math.Round(analyzer.speakingt, 1, MidpointRounding.AwayFromZero).ToString() + 's';
            speakingr.Font = new Font(Properties.Appearance.Default.FontFamily, 14, FontStyle.Regular);
            //speakingr.Size = new Size(100, 20);
            speakingr.AutoSize = true;
            speakingr.ReadOnly = true;
            speakingr.BackColor = color;
            speakingr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            speakingr.Location = new System.Drawing.Point(formPopup.Size.Width - speakingr.Size.Width - 10, speakingl.Location.Y);

            var speakinginfo = new PictureBox();
            panelPopup.Controls.Add(speakinginfo);
            speakinginfo.Image = System.Drawing.Image.FromFile(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "circle-info-solid.png"));
            speakinginfo.Size = new System.Drawing.Size(speakingl.Height - 10, speakingl.Height - 10);
            speakinginfo.Location = new System.Drawing.Point(speakingr.Location.X - speakinginfo.Size.Width - 20, (speakingr.Location.Y + (speakingr.Size.Height - speakinginfo.Size.Height)/2));
            speakinginfo.SizeMode = PictureBoxSizeMode.StretchImage;
            speakinginfo.BringToFront();
            speakinginfo.MouseHover += (s, a) =>
            {
                System.Windows.Forms.ToolTip tt = new System.Windows.Forms.ToolTip();
                tt.SetToolTip(speakinginfo, "Calculated using the average speaking speed of 183 words per minute.");
            };

            var mispelledl = new System.Windows.Forms.TextBox();
            panelPopup.Controls.Add(mispelledl);
            mispelledl.Text = "Mispelled words";
            mispelledl.Font = new Font(Properties.Appearance.Default.FontFamily, 14, FontStyle.Regular);
            mispelledl.Size = new System.Drawing.Size(150, 20);
            mispelledl.ReadOnly = true;
            mispelledl.BackColor = color;
            mispelledl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            mispelledl.Location = new System.Drawing.Point(formPopup.Size.Width / 2 - 10, sentencel.Location.Y);


            var mispelledr = new System.Windows.Forms.TextBox();
            panelPopup.Controls.Add(mispelledr);
            mispelledr.Text = analyzer.mispelledWords().ToString();
            mispelledr.Font = new Font(Properties.Appearance.Default.FontFamily, 14, FontStyle.Regular);
            //speakingr.Size = new Size(100, 20);
            mispelledr.AutoSize = true;
            mispelledr.ReadOnly = true;
            mispelledr.BackColor = color;
            mispelledr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            mispelledr.Location = new System.Drawing.Point(formPopup.Size.Width - mispelledr.Size.Width - 10, mispelledl.Location.Y);


            var readability = new System.Windows.Forms.TextBox();

            panelPopup.Controls.Add(readability);
            readability.Text = "Readability";
            readability.Font = new Font(Properties.Appearance.Default.FontFamily, 20, FontStyle.Underline);
            readability.Location = new System.Drawing.Point(generalMetrics.Location.X, sentencel.Location.Y + sentencel.Size.Height + 20);
            readability.Size = new System.Drawing.Size(240, 30);
            readability.ReadOnly = true;
            readability.BackColor = color;
            readability.BorderStyle = System.Windows.Forms.BorderStyle.None;

            var charactersperwordl = new System.Windows.Forms.TextBox();
            panelPopup.Controls.Add(charactersperwordl);
            charactersperwordl.Text = "Word length";
            charactersperwordl.Font = new Font(Properties.Appearance.Default.FontFamily, 14, FontStyle.Regular);
            charactersperwordl.Size = new System.Drawing.Size(120, 20);
            charactersperwordl.ReadOnly = true;
            charactersperwordl.BackColor = color;
            charactersperwordl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            charactersperwordl.Location = new System.Drawing.Point(readability.Location.X + 10, readability.Location.Y + readability.Size.Height + 10);

            var charactersperwordr = new System.Windows.Forms.TextBox();
            panelPopup.Controls.Add(charactersperwordr);
            charactersperwordr.Text = Math.Round(analyzer.avewordslen, 1, MidpointRounding.AwayFromZero).ToString();
            charactersperwordr.Font = new Font(Properties.Appearance.Default.FontFamily, 14, FontStyle.Regular);
            //speakingr.Size = new Size(100, 20);
            speakingr.AutoSize = true;
            charactersperwordr.ReadOnly = true;
            charactersperwordr.BackColor = color;
            charactersperwordr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            charactersperwordr.Location = new System.Drawing.Point(formPopup.Size.Width / 2 - charactersperwordr.Size.Width - 10, charactersperwordl.Location.Y);

            var wordspersentencel = new System.Windows.Forms.TextBox();
            panelPopup.Controls.Add(wordspersentencel);
            wordspersentencel.Text = "Sentence length";
            wordspersentencel.Font = new Font(Properties.Appearance.Default.FontFamily, 14, FontStyle.Regular);
            wordspersentencel.Size = new System.Drawing.Size(140, 20);
            wordspersentencel.ReadOnly = true;
            wordspersentencel.BackColor = color;
            wordspersentencel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            wordspersentencel.Location = new System.Drawing.Point(formPopup.Size.Width / 2 - 10, charactersperwordl.Location.Y);

            var wordspersentencer = new System.Windows.Forms.TextBox();
            panelPopup.Controls.Add(wordspersentencer);
            wordspersentencer.Text = Math.Round(analyzer.avesentenceslen, 1, MidpointRounding.AwayFromZero).ToString();
            wordspersentencer.Font = new Font(Properties.Appearance.Default.FontFamily, 14, FontStyle.Regular);
            //speakingr.Size = new Size(100, 20);
            speakingr.AutoSize = true;
            wordspersentencer.ReadOnly = true;
            wordspersentencer.BackColor = color;
            wordspersentencer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            wordspersentencer.Location = new System.Drawing.Point(formPopup.Size.Width - wordspersentencer.Size.Width - 10, wordspersentencel.Location.Y);


            var readabilityscorel = new System.Windows.Forms.TextBox();
            panelPopup.Controls.Add(readabilityscorel);
            readabilityscorel.Text = "Readability score";
            readabilityscorel.Font = new Font(Properties.Appearance.Default.FontFamily, 14, FontStyle.Regular);
            readabilityscorel.Size = new System.Drawing.Size(200, 20);
            readabilityscorel.ReadOnly = true;
            readabilityscorel.BackColor = color;
            readabilityscorel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            readabilityscorel.Location = new System.Drawing.Point(readability.Location.X + 10, charactersperwordl.Location.Y + charactersperwordl.Size.Height + 10);

            double rs = analyzer.readabilityScore();
            var readabilityscorer = new System.Windows.Forms.TextBox();
            panelPopup.Controls.Add(readabilityscorer);
            readabilityscorer.Text = Math.Round(rs, 1, MidpointRounding.AwayFromZero).ToString();
            readabilityscorer.Font = new Font(Properties.Appearance.Default.FontFamily, 14, FontStyle.Regular);
            //speakingr.Size = new Size(100, 20);
            readabilityscorer.AutoSize = true;
            readabilityscorer.ReadOnly = true;
            readabilityscorer.BackColor = color;
            readabilityscorer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            readabilityscorer.Location = new System.Drawing.Point(formPopup.Size.Width / 2 - readabilityscorer.Size.Width - 10, readabilityscorel.Location.Y);
            readabilityscorer.BringToFront();

            var readabilitynotes = new System.Windows.Forms.TextBox();
            panelPopup.Controls.Add(readabilitynotes);
            readabilitynotes.Multiline = true;
            readabilitynotes.WordWrap = true;
            readabilitynotes.Font = new Font(Properties.Appearance.Default.FontFamily, 12, FontStyle.Regular);
            readabilitynotes.Size = new System.Drawing.Size(580, 100);

            // Reference: https://en.wikipedia.org/wiki/Flesch%E2%80%93Kincaid_readability_tests

            if (rs <= 10.0)
            {
                readabilitynotes.Text = "Your text is extremely difficult to read. Best understood by professionals.";
            } 
            else if(rs <= 30.0)
            {
                readabilitynotes.Text = "Your text is very difficult to read. Understood by university graduates.";
            }
            else if (rs <= 50.0)
            {
                readabilitynotes.Text = "Your text is difficult to read. Understood by college students.";
            }
            else if (rs <= 60.0)
            {
                readabilitynotes.Text = "Your text is fairly difficult to read. Understood by 10th to 12th graders.";
            }
            else if (rs <= 70.0)
            {
                readabilitynotes.Text = "Your text is moderately easy to read. Easily understood by 8th and 9th graders.";
            }
            else if (rs <= 80.0)
            {
                readabilitynotes.Text = "Your text is fairly easy to read. Easily understood by 7th graders.";
            }
            else if (rs <= 90.0)
            {
                readabilitynotes.Text = "Your text is easy to read. Easily understood by 6th graders. Conversational English for consumers.";
            } 
            else
            {
                readabilitynotes.Text = "Your text is very easy to read. Easily understood by 5th graders.";
            }

            //var newnewcolor = Color.FromArgb(Math.Min(255, Int32.Parse(color.R.ToString()) + 31), Math.Min(Int32.Parse(color.G.ToString()) + 15, 255), Math.Max(Int32.Parse(color.B.ToString()) - 2, 0));

            //readabilitynotes.ForeColor = newnewcolor;
            readabilitynotes.ReadOnly = true;
            readabilitynotes.BackColor = color;
            readabilitynotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            readabilitynotes.Location = new System.Drawing.Point(readability.Location.X, readabilityscorel.Location.Y + readabilityscorel.Size.Height + 10);

            Cursor.Current = Cursors.Default;
            formPopup.Show(this);
        }

        private void generatePDFReport()
        {
            Cursor.Current = Cursors.WaitCursor;
            analyzer.changeEssay(richTextBox1.Text);
            MatchCollection matches = analyzer.splitToWords();
            Dictionary<string, int> words = new Dictionary<string, int>();
            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                string modifiedMatch = match.ToString().ToLower().Trim();
                if (!words.ContainsKey(modifiedMatch)) words[modifiedMatch] = 1;
                else words[modifiedMatch]++;
            }

            var sortedDict = from entry in words orderby entry.Value descending select entry;


            var dtnp = System.DateTime.Now.ToString("yyyy-MM-dd HHmmss");
            var dtn = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            // PDF maker.
            // Reference: https://ironpdf.com/blog/using-ironpdf/csharp-create-pdf-tutorial/
            var pdf = new ChromePdfRenderer
            {
                RenderingOptions =
                {
                    HtmlFooter = new HtmlHeaderFooter()
                    {

                        MaxHeight = 15, // millimeters
                        HtmlFragment = "<p style=\"text-align:right;font-family:'Comic Sans MS';color:gray\">{page}</p>",
                        DrawDividerLine = true
                    },
                    HtmlHeader = new HtmlHeaderFooter()
                    {
                        HtmlFragment = $"<p style=\"text-align:right;font-family:'Comic Sans MS';color:gray\">Report generated on {dtn}</p>"
                    }
                }
            };
            string tmphtml = "";
            string[] notes =
            {
                "Your text is extremely difficult to read. Best understood by professionals.",
                "Your text is very difficult to read. Understood by university graduates.",
                "Your text is difficult to read. Understood by college students.",
                "Your text is fairly difficult to read. Understood by 10th to 12th graders.",
                "Your text is moderately easy to read. Easily understood by 8th and 9th graders.",
                "Your text is fairly easy to read. Easily understood by 7th graders.",
                "Your text is easy to read. Easily understood by 6th graders. Conversational English for consumers.",
                "Your text is very easy to read. Easily understood by 5th graders.",
            };
            double[] boundary =
            {
                10.0, 30.0, 50.0, 60.0, 70.0, 80.0, 90.0
            };
            var rsindex = boundary.Length;
            var rs = analyzer.readabilityScore();
            for (int i = boundary.Length-1; i >= 0; i--)
            {
                if (rs <= boundary[i]) rsindex--;
                else break;
            }
            var htmlcolor = "#" + Properties.Appearance.Default.BackColor;
            for(int i = 0; i <= boundary.Length; i++)
            {
                var tt = boundary[Math.Min(i, boundary.Length-1)];
                var sign = "&le;";
                if (i == boundary.Length) sign = "&gt;";
                string color = "white";
                if (rsindex == i) color = "green";
                tmphtml += $"<tr bgcolor=\"{color}\">" +
                    $"<td style=\"font-size:12px;text-align:center;border:1px solid black;\">{sign} {tt.ToString("0.0")}</td><td style=\"font-size:12px;border:1px solid black;\">{notes[i]}</td>" +
                    "</tr>";
            }
            string html = 
                $"<div style=\"font-family:'Comic Sans MS';\"><h1 style=\"text-align:center\">Artificial Ignorance (AI) <br>Text Analyzer</h1>" +
                "<img style=\"margin-left:auto;margin-right:auto;display:block\" width=\"100px\" src=\"" + System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "logo.png") + "\">" +
                "<hr>" +
                "<p>" +
                    essayHTML(analyzer.essay) +
                $@"</p>
                <hr>" +
                "<h2>General Metrics</h2>" +
                "<table style=\"padding: 5px;margin:0px auto;width:100%;border:1px solid white\">" +
                    $"<tr style=\"color:{htmlcolor};font-size:25px;vertical-align: bottom\">" +
                        $"<td> {analyzer.characters.ToString()}</td>" + "<td style=\"font-size:12;color:gray\">characters</td>" +
                        $"<td> {matches.Count}" + "<td style=\"font-size:12;color:gray\">words</td>" +
                        $"<td> {analyzer.sentences.ToString()}" + "<td style=\"font-size:12;color:gray\">sentences</td>" +
                    "</tr>" +
                    $"<tr style=\"color:{htmlcolor};font-size:25px;vertical-align: bottom\">" +
                        $"<td> {analyzer.readingt.ToString("0.0")}s</td>" + "<td style=\"font-size:12;color:gray\">reading time</td>" +
                        $"<td> {analyzer.speakingt.ToString("0.0")}s</td>" + "<td style=\"font-size:12;color:gray\">speaking time</td>" +
                        $"<td> {analyzer.mispelledWords().ToString()}" + "<td style=\"font-size:12;color:gray\">mispelled words</td>" +
                    $@"</tr>
                </table>" +
                "<hr><h2>Readability</h2>" +
                "<table style=\"padding:5px;margin:0px auto;width:100%;border: 1px solid white\">" +
                    $"<tr style=\"color:{htmlcolor};font-size:25px;vertical-align: bottom\">" +
                            $"<td> {analyzer.avewordslen.ToString("0.0")}</td>" + "<td style=\"font-size:12px;color:gray\">character per word</td>" +
                            $"<td> {analyzer.avesentenceslen.ToString("0.0")}" + "<td style=\"font-size:12px;color:gray\">word per sentence</td>" +
                            $"<td> {rs.ToString("0.0")}" + "<td style=\"font-size:12;color:gray\">readability score</td>" +
                        "</tr>" +
                "</table>" +
                "<table style=\"padding;5px;margin:0px auto;width:80%;border:1px solid black;border-collapse:collapse;font-size:10>" +
                    "<tr style=\"vertical-align: bottom;\">" +
                        "<td style=\"font-size:12px;border:1px solid black;text-align:center\">Readability Score</td><td style=\"font-size:12px;border:1px solid black;\">Description</td>" +
                    "</tr>" + tmphtml +
                "</table>" +
                "<hr>" +
                "<h2>Vocabulary</h2>" +
                "<table style=\"padding:5px;margin:0px auto;width:100%;border: 1px solid white\">" +
                    $"<tr style=\"color:{htmlcolor};font-size:25px;vertical-align: bottom\">" +
                            $"<td> {((double)sortedDict.Count() / analyzer.words * 100).ToString("0.0")}% <a style=\"font-size:12px;color:gray\">unique words</a></td>" +
                    "</tr>" +
                    $"<tr style=\"color:{htmlcolor};font-size:25px;vertical-align: bottom\">" +
                        "<td style=\"font-size:16px;color:#404040\">Frequently used vocabularies (top 10)</td>" +
                    "</tr>";
            int cnt = 0;
            foreach (var kvp in sortedDict)
            {
                if (cnt >= 10) break;
                cnt++;
                html += $"<tr><td style=\"color:{htmlcolor}\"><li>" + kvp.Key + ": " + kvp.Value + "</li></td></tr>";
            }
            html += "</ol></table></div>";


            PdfDocument doc = pdf.RenderHtmlAsPdf(html);
            string source = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Report.pdf");
            string path = "";
            Cursor.Current = Cursors.Default;
            if (Properties.Settings.Default.showFolderDialog)
            {
                saveFileDialog2.Filter = "pdf files (*.pdf)|*.pdf";
                saveFileDialog2.FilterIndex = 1;
                saveFileDialog2.InitialDirectory = Properties.Settings.Default.initialDirectory;
                saveFileDialog2.FileName = $"Report {dtnp}";
                if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    path = System.IO.Path.Combine(saveFileDialog2.FileName);
                    //MessageBox.Show(path);
                }
            }
            else
            {
                path = Properties.Settings.Default.initialDirectory + $@"\Report {dtnp}";

                var tt = 1;
                while (File.Exists(path))
                {
                    path = System.IO.Path.ChangeExtension(path, null) + $" ({tt})";
                    tt++;
                }

                path += ".pdf";
            }
            Cursor.Current = Cursors.WaitCursor;

            var x = 1;
            while (File.Exists(path))
            {
                path = System.IO.Path.ChangeExtension(path, null) + $" ({x})";
                x++;
            }
            //MessageBox.Show(source);
            //MessageBox.Show(path);

            doc.SaveAs(path);
            MessageBox.Show("Report saved in " + Path.GetDirectoryName(path), "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Cursor.Current = Cursors.Default;

            //try
            //{
            //    if (!File.Exists(source))
            //    {
            //        // This statement ensures that the file is created,  
            //        // but the handle is not kept.  
            //        using (FileStream fs = File.Create(source)) { }
            //    }
            //    // Ensure that the target does not exist.  
            //    if (File.Exists(path))
            //        File.Delete(path);
            //    // Move the file.  
            //    // If file.txt is not found
            //    // then an exception will be shown
            //    File.Move(source, path);
            //    //Console.WriteLine("Moved");
            //    if (File.Exists(path))
            //    {
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error occured. Unable to save the report.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //catch (IOException ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}

        }

        private void import_Click(object sender, EventArgs e)
        {
            // Icons: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messageboxicon?view=windowsdesktop-7.0&redirectedfrom=MSDN
            MessageBox.Show("We now only support files importing with .txt and .rtf format", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            openFileDialog1.Filter = "rtf files (*.rtf)|*.rtf|txt files (*.txt)|*.txt";
            //openFileDialog1.Filter = "txt files (*.txt)|*.txt|rtf files (*.rtf)|*.rtf|word files (*.doc,*.docx)|.doc;.docx|All files (*.*)|*.*";
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
                if (Path.GetExtension(saveFileDialog1.FileName).ToLower() != ".txt")
                {
                    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                    MessageBox.Show("Text has saved successfully as " + Path.GetFileName(saveFileDialog1.FileName), "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    MessageBox.Show("Text has saved successfully as " + Path.GetFileName(saveFileDialog1.FileName), "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            analyzer.changeEssay(richTextBox1.Text);
            var cnt = analyzer.numberOfWords();
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

    public class analyzer
    {
        public string essay;
        private const double readingwpm = 238, speakingwpm = 183;
        public int characters, words, sentences;
        public double avesentenceslen, avewordslen, readingt, speakingt;

        public analyzer()
        {

        }

        public void changeEssay(string essay)
        {
            this.essay = essay;
            this.words = numberOfWords();
            this.sentences = numberOfSentences();
            this.avesentenceslen = averageSentenceLength();
            this.avewordslen = averageWordLength();
            this.readingt = estimatedReadingSeconds();
            this.speakingt = estimatedSpeakingSeconds();
            this.characters = numberOfCharacters();
        }

        public bool isAWord(string s)
        {
            var oDict = new NetSpell.SpellChecker.Dictionary.WordDictionary();
            oDict.DictionaryFile = "en-US.dic";
            oDict.Initialize();
            var oSpell = new NetSpell.SpellChecker.Spelling();

            oSpell.Dictionary = oDict;
            return oSpell.TestWord(s);
        }

        public int mispelledWords()
        {
            var cnt = 0;
            MatchCollection matches = Regex.Matches(essay, @"[\w']+|[.,!?;]");
            Regex rg = new Regex(@"^[a-zA-Z0-9]+$");

            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                if (rg.IsMatch(match.ToString()))
                {
                    if (!this.isAWord(match.ToString()))
                    {
                        //MessageBox.Show(match.ToString());
                        cnt++;
                    }
                }
            }
            return cnt;
        }
        public int numberOfSyllables()
        {
            int totalcnt = 0;
            string vowels = "aeiouy";
            foreach(System.Text.RegularExpressions.Match match in splitToWords())
            {
                int cnt = 0;
                var word = match.ToString().ToLower().strip();
                if (vowels.Contains(word[0])) cnt++;
                for(int i = 1; i < word.Length; i++)
                {
                    if (vowels.Contains(word[i]) && !vowels.Contains(word[i - 1])) cnt++;
                }
                if (word[word.Length - 1] == 'e') cnt--;
                if (word.Length > 2 && word[word.Length - 2] == 'l' && word[word.Length - 1] == 'e' && !vowels.Contains(word[word.Length - 3])) cnt++;
                //MessageBox.Show(word + ' ' + cnt.ToString());
                totalcnt += Math.Max(1, cnt);
            }
            MessageBox.Show(totalcnt.ToString());
            return totalcnt;
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
            if (essay.Length == 0) return 0;
            int cnt = 0;
            bool flag = false;
            for (int i = 0; i < essay.Length; i++)
            {
                Console.WriteLine($"{i} {cnt}");
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
            cnt += Convert.ToInt32(isAlphaNumeric(essay[essay.Length - 1]));
            return Math.Max(cnt, 1);
        }

        public MatchCollection splitToWords()
        {
            string pattern = @"[-\w]+[\s\t\r\n]?('s)*";
            MatchCollection matches = Regex.Matches(this.essay, pattern);
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
            return words / readingwpm * 60;
        }
        public double estimatedSpeakingSeconds()
        {
            return words / speakingwpm * 60;
        }

        public double averageSentenceLength()
        {
            return (double)words / sentences;
        }

        public double averageWordLength()
        {
            int cnt = 0;
            for(int i = 0; i < this.essay.Length; i++)
            {
                if ((essay[i] >= 'A' && essay[i] <= 'Z') || (essay[i] >= 'a' && essay[i] <= 'z') || (essay[i] >= '0' && essay[i] <= '9'))
                {
                    cnt++;
                }
            }
            return cnt / (double)words;
        }
        

        public double readabilityScore()
        {
            //MessageBox.Show(words.ToString());
            return (206.835 - 1.015 * avesentenceslen - 84.6 * numberOfSyllables() / words);
        }

        
    }
    
}
