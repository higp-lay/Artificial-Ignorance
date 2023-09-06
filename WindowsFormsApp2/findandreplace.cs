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
        int findIndex = -1;
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
            } else if (findIndex >= a.Length)
            {
                MessageBox.Show("Searching has finished.", "Find & Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                findIndex = -1;
            }
            if(findIndex >= 0)
            {
                form.rtb.SelectionLength = findfindtb.Text.Length;
                form.rtb.SelectionStart = a[findIndex];
                form.rtb.SelectionBackColor = Color.Yellow;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            findIndex = -1;
        }
    }
}
