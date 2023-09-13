using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        const string version = "0.8.0";
        private int selen = -1, sestart = -1;

        public UserControl UC1
        {
            get { return userControl11; }
        }
        public UserControl UC2
        {
            get { return userControl23; }
        }
        public UserControl UC3
        {
            get { return userControl31; }
        }
        public RichTextBox rtb
        {
            get { return userControl23.richTextBox1; }
        }
        public int selectLength
        {
            get { return this.selen; }
            set { this.selen = value; }
        }
        public int selectStart
        {
            get { return this.sestart; }
            set { this.sestart = value; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        //userControl11 --> home
        //userControl23 --> the analyzerS
        private void Home_Click(object sender, EventArgs e)
        {
            // Changing the BackColor of "Home" Button
            Home.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDDDD");
            // Changing the BackColor of "Analyzer" Button
            Analyze.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            // Changing the BackColor of "Settings" Button
            Settings.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            close.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            userControl11.Show();
            userControl23.Hide();
            userControl31.Hide();
            userControl11.BringToFront();
        }

        private void Analyze_Click(object sender, EventArgs e)
        {
            Analyze.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDDDD");
            Home.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            Settings.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            close.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            userControl23.Show();
            userControl11.Hide();
            userControl31.Hide();
            userControl23.BringToFront();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            Settings.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDDDD");
            Home.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            Analyze.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            close.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            userControl31.Show();
            userControl11.Hide();
            userControl23.Hide();
            userControl31.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Properties.Appearance.Default.Reset();
            //Properties.Appearance.Default.Save();

            this.Home_Click(sender, e);
            this.Form1_Resize(sender, e);
            this.Text = "Artificial Ignorance (AI) Text Analyzer " + version;
            versionlabel.Text = "AI " + version + "\r\nBy Hugo Lau\r\n";
            //Analyze.Font = new Font("UD Digi Kyokasho NK-B", 24, FontStyle.Bold);
            Home.Font = new Font(Properties.Appearance.Default.FontFamily, 15, FontStyle.Bold);
            Analyze.Font = new Font(Properties.Appearance.Default.FontFamily, 15, FontStyle.Bold);
            Settings.Font = new Font(Properties.Appearance.Default.FontFamily, 15, FontStyle.Bold);
            versionlabel.Font = new Font(Properties.Appearance.Default.FontFamily, 10, FontStyle.Bold);
            changeTheme();
        }


        private void userControl23_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            //MessageBox.Show();
            var formWidth = control.Size.Width;
            var formHeight = control.Size.Height;
            //panel1.Size = new Size(formWidth/9, panel1.Height);

            userControl11.Location = new Point(200, 0);
            userControl23.Location = new Point(200, 0);
            userControl31.Location = new Point(200, 0);

            userControl11.Size = new Size(this.Width - 200, panel1.Height);
            userControl23.Size = new Size(this.Width - 200, panel1.Height);
            userControl31.Size = new Size(this.Width - 200, panel1.Height);

            Home.Location = new Point(panel1.Size.Width / 2 - Home.Size.Width / 2, 100);
            Analyze.Location = new Point(panel1.Size.Width / 2 - Home.Size.Width / 2, Home.Location.Y + Home.Size.Height + 70);
            Settings.Location = new Point(panel1.Size.Width / 2 - Home.Size.Width / 2, Analyze.Location.Y + Analyze.Size.Height + 70);
            close.Location = new Point(panel1.Size.Width / 2 - Home.Size.Width / 2, Settings.Location.Y + Settings.Size.Height + 70);
            versionlabel.Location = new System.Drawing.Point(10, this.Size.Height - 80);
        }

        private void userControl31_Load(object sender, EventArgs e)
        {

        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        public void changeTheme()
        {
            var color = Properties.Appearance.Default.BackColor;
            userControl11.BackColor = System.Drawing.ColorTranslator.FromHtml($"#{color}");
            userControl23.BackColor = System.Drawing.ColorTranslator.FromHtml($"#{color}");
            userControl31.BackColor = System.Drawing.ColorTranslator.FromHtml($"#{color}");

            var colorx = System.Drawing.ColorTranslator.FromHtml($"#{color}");
            var newcolor = Color.FromArgb(Math.Min(255, Int32.Parse(colorx.R.ToString()) + 62), Math.Min(Int32.Parse(colorx.G.ToString()) + 48, 255), Math.Min(Int32.Parse(colorx.B.ToString()) + 33, 255));
            panel1.BackColor = newcolor;
            versionlabel.BackColor = newcolor;
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void changeFont()
        {
            Home.Font = new Font(Properties.Appearance.Default.FontFamily, 15, FontStyle.Bold);
            Analyze.Font = new Font(Properties.Appearance.Default.FontFamily, 15, FontStyle.Bold);
            Settings.Font = new Font(Properties.Appearance.Default.FontFamily, 15, FontStyle.Bold);
            versionlabel.Font = new Font(Properties.Appearance.Default.FontFamily, 10, FontStyle.Bold);
        }

    }
}
