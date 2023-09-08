using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Web.ModelBinding;
using Microsoft.Win32;

namespace WindowsFormsApp2
{
    public partial class findandreplace : Form
    {
        int findIndex = -1, replaceIndex = -1;
        Regex r;
        int[] a;
        string essay;

        public findandreplace()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void findcancel_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)this.Owner;
            form.rtb.SelectAll();
            form.rtb.SelectionBackColor = System.Drawing.Color.White;
            form.rtb.DeselectAll();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(findfindtb.Text.Length > 0)
            {
                findcancel.Enabled = true;
                findfindnext.Enabled = true;
            } else
            {
                findcancel.Enabled = false;
                findfindnext.Enabled = false;
            }
        }

        private void findandreplace_Load(object sender, EventArgs e)
        {
            Form1 form = (Form1)this.Owner;
            findcancel.Enabled = false;
            findfindnext.Enabled = false;
            findIndex = -1;
                form.selectLength = form.selectStart = -1;
            form.rtb.TextChanged += (s, a) =>
            {
                if(essay != form.rtb.Text) findIndex = -1;
                essay = form.rtb.Text;
            };
        }

        

        private void findfindnext_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)this.Owner;

            form.rtb.SelectAll();
            form.rtb.SelectionBackColor = System.Drawing.Color.White;
            form.rtb.DeselectAll();

            string findfindtbtext = findfindtb.Text;
            string essaytmp = essay;

            if(!checkBox1.Checked)
            {
                essaytmp = essaytmp.ToLower();
                findfindtbtext = findfindtbtext.ToLower();
            }
            //MessageBox.Show(essaytmp);
            //MessageBox.Show(findfindtbtext);

            r = new Regex(findfindtbtext);
            a = r.Matches(essaytmp).Cast<Match>().Select(m => m.Index).ToArray();
            findIndex++;
            if(a.Length == 0)
            {
                MessageBox.Show("No result found.", "Find & Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            } else if (findIndex >= a.Length)
            {
                MessageBox.Show("Searching has finished.", "Find & Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                findIndex = -1;
                form.selectLength = form.selectStart = -1;
            }
            if(findIndex >= 0)
            {
                form.rtb.SelectionLength = form.selectLength = findfindtb.Text.Length;
                form.rtb.SelectionStart = form.selectStart = a[findIndex];
                form.rtb.SelectionBackColor = Color.Yellow;
            } else
            {
                form.selectLength = form.selectStart = -1;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Form1 form = (Form1)this.Owner;
            findIndex = -1;
            form.selectLength = form.selectStart = -1;
        }

        private void replacecancel_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)this.Owner;
            form.rtb.SelectAll();
            form.rtb.SelectionBackColor = System.Drawing.Color.White;
            form.rtb.DeselectAll();
            this.Close();
        }

        private void replacefindnext_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)this.Owner;

            form.rtb.SelectAll();
            form.rtb.SelectionBackColor = System.Drawing.Color.White;
            form.rtb.DeselectAll();

            string replacefindtbtext = replacefindtb.Text;
            string essaytmp = essay;
            if (!checkBox2.Checked)
            {
                essaytmp = essaytmp.ToLower();
                replacefindtbtext = replacefindtbtext.ToLower();
            }
            //MessageBox.Show(essaytmp);
            //MessageBox.Show(findfindtbtext);

            r = new Regex(replacefindtbtext);
            a = r.Matches(essaytmp).Cast<Match>().Select(m => m.Index).ToArray();
            findIndex++;
            if (a.Length == 0)
            {
                MessageBox.Show("No result found.", "Find & Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (findIndex >= a.Length)
            {
                MessageBox.Show("Searching has finished.", "Find & Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                findIndex = -1;
                form.selectLength = form.selectStart = -1;
            }
            if (findIndex >= 0)
            {
                form.rtb.SelectionLength = form.selectLength = replacefindtb.Text.Length;
                form.rtb.SelectionStart = form.selectStart = a[findIndex];
                form.rtb.SelectionBackColor = Color.Yellow;
            }
            else
            {
                form.selectLength = form.selectStart = -1;
            }
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1 form = (Form1)this.Owner;
            findIndex = -1;
            form.selectLength = form.selectStart = -1;
            findfindtb.Text = "";
            replacefindtb.Text = "";
            replacereplacetb.Text = "";
            form.rtb.SelectAll();
            form.rtb.SelectionBackColor = System.Drawing.Color.White;
            form.rtb.DeselectAll();
        }

        private void replaceall_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)this.Owner;
            string replacefindtbtext = replacefindtb.Text;
            string essaytmp = essay;
            if (!checkBox2.Checked)
            {
                essaytmp = essaytmp.ToLower();
                replacefindtbtext = replacefindtbtext.ToLower();
            }
            r = new Regex(replacefindtbtext);
            a = r.Matches(essaytmp).Cast<Match>().Select(m => m.Index).ToArray();
            for(int i = 0; i < a.Length; i++)
            {
                var index = a[i] + i * (replacereplacetb.Text.Length-replacefindtb.Text.Length);
                form.rtb.Text = essay.Remove(index, replacefindtb.Text.Length).Insert(index, replacereplacetb.Text);
            }
            if(a.Length != 1)
                MessageBox.Show($"{a.Length} replacements are made.", "Find & Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show($"{a.Length} replacement is made.", "Find & Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void replaceone_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)this.Owner;

            form.rtb.SelectAll();
            form.rtb.SelectionBackColor = System.Drawing.Color.White;
            form.rtb.DeselectAll();

            string replacefindtbtext = replacefindtb.Text;
            string essaytmp = essay;
            var tmp = findIndex;

            if (!checkBox2.Checked)
            {
                essaytmp = essaytmp.ToLower();
                replacefindtbtext = replacefindtbtext.ToLower();
            }
            //MessageBox.Show(essaytmp);
            //MessageBox.Show(findfindtbtext);

            r = new Regex(replacefindtbtext);
            a = r.Matches(essaytmp).Cast<Match>().Select(m => m.Index).ToArray();

            if (a.Length == 0)
            {
                MessageBox.Show("No result found.", "Find & Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (findIndex == -1)
            {
                findIndex++;
                form.rtb.SelectionLength = form.selectLength = replacefindtb.Text.Length;
                form.rtb.SelectionStart = form.selectStart = a[findIndex];
                form.rtb.SelectionBackColor = Color.Yellow;
                return;
            }

            try {
                if(essaytmp.Substring(a[findIndex], replacefindtb.Text.Length) == replacefindtb.Text)
                {
                    form.rtb.Text = essay.Remove(a[findIndex], replacefindtb.Text.Length).Insert(a[findIndex],replacereplacetb.Text);
                } 
            } 
            catch (Exception ex)
            {
                MessageBox.Show("End of document has been reached.", "Find & Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                findIndex = -1;
                form.selectLength = form.selectStart = -1;
                return;
            }

            if (findIndex >= a.Length)
            {
                MessageBox.Show("Searching has finished.", "Find & Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                findIndex = -1;
                form.selectLength = form.selectStart = -1;
                return;
            }
            findIndex = tmp;
            if (findIndex >= 0)
            {
                findIndex++;
                if(findIndex < a.Length)
                {
                    form.rtb.SelectionLength = form.selectLength = replacefindtb.Text.Length;
                    form.rtb.SelectionStart = form.selectStart = Math.Max(0, a[findIndex] - replacefindtb.Text.Length + replacereplacetb.Text.Length);
                    form.rtb.SelectionBackColor = Color.Yellow;
                }
            }
            else
            {
                form.selectLength = form.selectStart = -1;
            }
            findIndex--;
        }
    }
}
