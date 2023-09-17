using IronPdf;
using Microsoft.Win32;
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
using System.IO;

namespace WindowsFormsApp2
{
    public partial class popupform : Form
    {
        string essay;
        analyzer analyzer;
        public popupform(string essay, string dtnp)
        {
            InitializeComponent();
            this.essay = essay;
            this.Text = $"Report {dtnp}";
        }

        private void popupform_Load(object sender, EventArgs e)
        {
            this.analyzer = new analyzer(essay);
            var color = System.Drawing.ColorTranslator.FromHtml($"#{Properties.Appearance.Default.BackColor}");
            var newcolor = System.Drawing.Color.FromArgb(Math.Min(255, Int32.Parse(color.R.ToString()) + 62), Math.Min(Int32.Parse(color.G.ToString()) + 48, 255), Math.Min(Int32.Parse(color.B.ToString()) + 33, 255));
            this.BackColor = newcolor;
            panelPopup.BackColor = color;

            panelPopup.AutoScroll = false;
            panelPopup.HorizontalScroll.Enabled = false;
            panelPopup.HorizontalScroll.Visible = false;
            panelPopup.HorizontalScroll.Maximum = 0;
            panelPopup.AutoScroll = true;

            double rs = analyzer.rs;
            if (rs <= 10.0)
            {
                readabilitynotes.Text = "Your text is extremely difficult to read. Best understood by professionals.";
            }
            else if (rs <= 30.0)
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

            characterr.Text = analyzer.characters.ToString();
            wordr.Text = analyzer.words.ToString();
            sentencer.Text = analyzer.sentences.ToString();
            readingr.Text = $"{analyzer.readingt.ToString("0.0")}s";
            speakingr.Text = $"{analyzer.speakingt.ToString("0.0")}s";
            misspelledr.Text = analyzer.misspelled.ToString();
            charactersperwordr.Text = analyzer.avewordslen.ToString("0.0");
            wordspersentencer.Text = analyzer.avesentenceslen.ToString("0.0");
            readabilityr.Text = rs.ToString("0.0");
            uniquer.Text = $"{analyzer.unique.ToString("0.0")}%";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void genpdfbutton_Click(object sender, EventArgs e)
        {
            generatePDFReport();
        }


        private void generatePDFReport()
        {
            var uc = this.FindForm();
            Cursor.Current = Cursors.WaitCursor;
            MatchCollection matches = analyzer.splitToWords();

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
            var rs = analyzer.rs;
            for (int i = boundary.Length - 1; i >= 0; i--)
            {
                if (rs <= boundary[i]) rsindex--;
                else break;
            }
            var htmlcolor = "#" + Properties.Appearance.Default.BackColor;
            for (int i = 0; i <= boundary.Length; i++)
            {
                var tt = boundary[Math.Min(i, boundary.Length - 1)];
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
                        $"<td> {analyzer.misspelled.ToString()}" + "<td style=\"font-size:12;color:gray\">misspelled words</td>" +
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
                            $"<td> {analyzer.unique.ToString("0.0")}% <a style=\"font-size:12px;color:gray\">unique words</a></td>" +
                    "</tr>" +
                    $"<tr style=\"color:{htmlcolor};font-size:25px;vertical-align: bottom\">" +
                        "<td style=\"font-size:16px;color:#404040\">Frequently used vocabularies (top 10)</td><ol>" +
                    "</tr>";
            int cnt = 0;
            foreach (var kvp in analyzer.wordDict)
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
                saveFileDialog1.Filter = "pdf files (*.pdf)|*.pdf";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.InitialDirectory = Properties.Settings.Default.initialDirectory;
                saveFileDialog1.FileName = $"Report {dtnp}";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = System.IO.Path.Combine(saveFileDialog1.FileName);
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

            doc.SaveAs(path);
            MessageBox.Show("Report saved in " + Path.GetDirectoryName(path), "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Cursor.Current = Cursors.Default;


        }

        private string essayHTML(string essay)
        {
            string l = @"<span style=""border-bottom: 1px dotted #ff0000;padding:1px""><span style=""border-bottom: 1px dotted #ff0000;"">";
            string r = @"</span></span>";
            string html = "";
            MatchCollection matches = Regex.Matches(essay, @"[\w-]+['s]*|[.,!?;]");
            Regex rg = new Regex(@"^[-a-zA-Z0-9]+$");
            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                var ms = match.ToString();
                if (rg.IsMatch(ms))
                {
                    if (match.Index != 0)
                    {
                        html += " ";
                    }
                    bool t;
                    if (analyzer.isAWordDict.ContainsKey(ms))
                    {
                        t = analyzer.isAWordDict[ms];
                    } else
                    {
                        t = analyzer.isAWord(ms);
                    }
                    if (t)
                    {
                        html += ms;
                    }
                    else
                    {
                        html += l + ms + r;
                    }
                }
                else html += ms;
            }
            return html;
        }
    }



    public class analyzer
    {
        public string essay;
        private const double readingwpm = 238, speakingwpm = 183;
        public int characters, words, sentences, misspelled;
        public double avesentenceslen, avewordslen, readingt, speakingt, unique, rs;
        public MatchCollection matches;
        public Dictionary<string, bool> isAWordDict;
        public Dictionary<string, int> syllablesDict;
        public IOrderedEnumerable<KeyValuePair<string, int>> wordDict;

        public analyzer(string essay)
        {
            this.isAWordDict = new Dictionary<string, bool>();
            this.syllablesDict = new Dictionary<string, int>();
            this.wordDict = Enumerable.Empty<KeyValuePair<string, int>>().OrderBy(x => 1);
            this.essay = essay;
            this.matches = splitToWords();
            this.wordDict = createWordDict();
            this.misspelled = mispelledWords();
            this.words = numberOfWords();
            this.sentences = numberOfSentences();
            this.avesentenceslen = averageSentenceLength();
            this.avewordslen = averageWordLength();
            this.readingt = estimatedReadingSeconds();
            this.speakingt = estimatedSpeakingSeconds();
            this.characters = numberOfCharacters();
            this.unique = uniqueWordsPercentage();
            this.rs = readabilityScore();
        }


        public bool isAWord(string s)
        {
            if (isAWordDict.ContainsKey(s)) return isAWordDict[s];
            var oDict = new NetSpell.SpellChecker.Dictionary.WordDictionary();
            oDict.DictionaryFile = "en-US.dic";
            oDict.Initialize();
            var oSpell = new NetSpell.SpellChecker.Spelling();

            oSpell.Dictionary = oDict;
            bool rv = oSpell.TestWord(s);
            isAWordDict.Add(s, rv);
            return rv;
        }

        public int mispelledWords()
        {
            var cnt = 0;
            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                if (!this.isAWord(match.ToString())) cnt++;
            }
            return cnt;
        }
        public int numberOfSyllables()
        {
            int totalcnt = 0;
            string vowels = "aeiouy";
            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                var word = match.ToString().ToLower().Trim();
                if (syllablesDict.ContainsKey(word))
                {
                    totalcnt += syllablesDict[word];
                    continue;
                }
                int cnt = 0;
                if (vowels.Contains(word[0])) cnt++;
                for (int i = 1; i < word.Length; i++)
                {
                    if (vowels.Contains(word[i]) && !vowels.Contains(word[i - 1])) cnt++;
                }
                if (word[word.Length - 1] == 'e') cnt--;
                if (word.Length > 2 && word[word.Length - 2] == 'l' && word[word.Length - 1] == 'e'
                    && !vowels.Contains(word[word.Length - 3])) cnt++;
                if (word.Length > 3 && word[word.Length - 3] == 'l' && word[word.Length - 2] == 'e'
                    && word[word.Length - 1] == 's' && !vowels.Contains(word[word.Length - 4])) cnt++;
                syllablesDict.Add(word, Math.Max(1, cnt));
                totalcnt += Math.Max(1, cnt);
            }
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
            for (int i = 0; i < essay.Length; i++)
            {
                cnt += Convert.ToInt32((essay[i] == '.' || essay[i] == '!' || essay[i] == '?') && i - 1 >= 0 && isAlphaNumeric(essay[i - 1]));
                if (essay[i] == '.' && isAbbr(i)) --cnt;
            }
            cnt += Convert.ToInt32(isAlphaNumeric(essay[essay.Length - 1]));
            return Math.Max(cnt, 1);
        }

        public MatchCollection splitToWords()
        {
            string pattern = @"[-\w]+('s)*";
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
            for (int i = 0; i < this.essay.Length; i++)
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
            return (206.835 - 1.015 * avesentenceslen - 84.6 * numberOfSyllables() / words);
        }

        public IOrderedEnumerable<KeyValuePair<string, int>> createWordDict()
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                string modifiedMatch = match.ToString().ToLower().Trim();
                if (!words.ContainsKey(modifiedMatch)) words[modifiedMatch] = 1;
                else words[modifiedMatch]++;
            }
            var sortedDict = from entry in words orderby entry.Value descending select entry;
            return sortedDict;
        }

        public double uniqueWordsPercentage()
        {
            return ((double)wordDict.Count() / words * 100);
        }
    }

}
