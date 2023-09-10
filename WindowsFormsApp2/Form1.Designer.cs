using Grpc.Core;
using System.Drawing;

namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.close = new System.Windows.Forms.Button();
            this.versionlabel = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.Analyze = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.Button();
            this.Home = new System.Windows.Forms.Button();
            this.userControl22 = new WindowsFormsApp2.UserControl2();
            this.homeToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.userControl11 = new WindowsFormsApp2.UserControl1();
            this.userControl31 = new WindowsFormsApp2.UserControl3();
            this.userControl12 = new WindowsFormsApp2.UserControl1();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.close);
            this.panel1.Controls.Add(this.versionlabel);
            this.panel1.Controls.Add(this.splitter2);
            this.panel1.Controls.Add(this.Analyze);
            this.panel1.Controls.Add(this.Settings);
            this.panel1.Controls.Add(this.Home);
            this.panel1.Name = "panel1";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // close
            // 
            resources.ApplyResources(this.close, "close");
            this.close.Name = "close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // versionlabel
            // 
            resources.ApplyResources(this.versionlabel, "versionlabel");
            this.versionlabel.Name = "versionlabel";
            // 
            // splitter2
            // 
            resources.ApplyResources(this.splitter2, "splitter2");
            this.splitter2.Name = "splitter2";
            this.splitter2.TabStop = false;
            // 
            // Analyze
            // 
            resources.ApplyResources(this.Analyze, "Analyze");
            this.Analyze.Name = "Analyze";
            this.Analyze.UseVisualStyleBackColor = true;
            this.Analyze.Click += new System.EventHandler(this.Analyze_Click);
            // 
            // Settings
            // 
            resources.ApplyResources(this.Settings, "Settings");
            this.Settings.Name = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // Home
            // 
            resources.ApplyResources(this.Home, "Home");
            this.Home.Name = "Home";
            this.homeToolTip.SetToolTip(this.Home, resources.GetString("Home.ToolTip"));
            this.Home.UseVisualStyleBackColor = true;
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // userControl22
            // 
            this.userControl22.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.userControl22, "userControl22");
            this.userControl22.Name = "userControl22";
            // 
            // userControl11
            // 
            resources.ApplyResources(this.userControl11, "userControl11");
            this.userControl11.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.userControl11.Name = "userControl11";
            this.userControl11.Load += new System.EventHandler(this.userControl11_Load);
            // 
            // userControl31
            // 
            this.userControl31.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.userControl31, "userControl31");
            this.userControl31.Name = "userControl31";
            this.userControl31.Load += new System.EventHandler(this.userControl31_Load);
            // 
            // userControl12
            // 
            this.userControl12.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.userControl12, "userControl12");
            this.userControl12.Name = "userControl12";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userControl22);
            this.Controls.Add(this.userControl12);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.userControl31);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.Button Home;
        private System.Windows.Forms.Button Analyze;
        private UserControl1 userControl11;
        private UserControl2 userControl21;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ToolTip homeToolTip;
        private UserControl3 userControl31;
        private System.Windows.Forms.Label versionlabel;
        private System.Windows.Forms.Button close;
        private UserControl2 userControl22;
        private UserControl1 userControl12;
    }
}

