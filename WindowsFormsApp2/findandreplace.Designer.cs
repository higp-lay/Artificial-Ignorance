namespace WindowsFormsApp2
{
    partial class findandreplace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(findandreplace));
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.find = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.findfindnext = new System.Windows.Forms.Button();
            this.findcancel = new System.Windows.Forms.Button();
            this.findfindtb = new System.Windows.Forms.TextBox();
            this.replace = new System.Windows.Forms.TabPage();
            this.replaceall = new System.Windows.Forms.Button();
            this.replaceone = new System.Windows.Forms.Button();
            this.replacefindnext = new System.Windows.Forms.Button();
            this.replacecancel = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.replacereplacetb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.replacefindtb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.find.SuspendLayout();
            this.replace.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.find);
            this.tabControl1.Controls.Add(this.replace);
            this.tabControl1.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 237);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.TabIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            // 
            // find
            // 
            this.find.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.find.Controls.Add(this.checkBox1);
            this.find.Controls.Add(this.findfindnext);
            this.find.Controls.Add(this.findcancel);
            this.find.Controls.Add(this.findfindtb);
            this.find.Controls.Add(this.label1);
            this.find.Location = new System.Drawing.Point(4, 26);
            this.find.Name = "find";
            this.find.Padding = new System.Windows.Forms.Padding(3);
            this.find.Size = new System.Drawing.Size(752, 207);
            this.find.TabIndex = 0;
            this.find.Text = "Find";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(16, 171);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(124, 24);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Case sensitive";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // findfindnext
            // 
            this.findfindnext.Location = new System.Drawing.Point(546, 169);
            this.findfindnext.Name = "findfindnext";
            this.findfindnext.Size = new System.Drawing.Size(93, 29);
            this.findfindnext.TabIndex = 5;
            this.findfindnext.Text = "Find &Next";
            this.findfindnext.UseVisualStyleBackColor = true;
            this.findfindnext.Click += new System.EventHandler(this.findfindnext_Click);
            // 
            // findcancel
            // 
            this.findcancel.Location = new System.Drawing.Point(647, 169);
            this.findcancel.Name = "findcancel";
            this.findcancel.Size = new System.Drawing.Size(93, 29);
            this.findcancel.TabIndex = 4;
            this.findcancel.Text = "&Cancel";
            this.findcancel.UseVisualStyleBackColor = true;
            this.findcancel.Click += new System.EventHandler(this.findcancel_Click);
            // 
            // findfindtb
            // 
            this.findfindtb.Location = new System.Drawing.Point(126, 11);
            this.findfindtb.Name = "findfindtb";
            this.findfindtb.Size = new System.Drawing.Size(614, 24);
            this.findfindtb.TabIndex = 3;
            this.findfindtb.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // replace
            // 
            this.replace.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.replace.Controls.Add(this.replaceall);
            this.replace.Controls.Add(this.replaceone);
            this.replace.Controls.Add(this.replacefindnext);
            this.replace.Controls.Add(this.replacecancel);
            this.replace.Controls.Add(this.checkBox2);
            this.replace.Controls.Add(this.replacereplacetb);
            this.replace.Controls.Add(this.label3);
            this.replace.Controls.Add(this.replacefindtb);
            this.replace.Controls.Add(this.label2);
            this.replace.Location = new System.Drawing.Point(4, 26);
            this.replace.Name = "replace";
            this.replace.Padding = new System.Windows.Forms.Padding(3);
            this.replace.Size = new System.Drawing.Size(752, 207);
            this.replace.TabIndex = 1;
            this.replace.Text = "Replace";
            // 
            // replaceall
            // 
            this.replaceall.Location = new System.Drawing.Point(445, 169);
            this.replaceall.Name = "replaceall";
            this.replaceall.Size = new System.Drawing.Size(93, 29);
            this.replaceall.TabIndex = 11;
            this.replaceall.Text = "Replace &All";
            this.replaceall.UseVisualStyleBackColor = true;
            this.replaceall.Click += new System.EventHandler(this.replaceall_Click);
            // 
            // replaceone
            // 
            this.replaceone.Location = new System.Drawing.Point(344, 169);
            this.replaceone.Name = "replaceone";
            this.replaceone.Size = new System.Drawing.Size(93, 29);
            this.replaceone.TabIndex = 10;
            this.replaceone.Text = "&Replace";
            this.replaceone.UseVisualStyleBackColor = true;
            this.replaceone.Click += new System.EventHandler(this.replaceone_Click);
            // 
            // replacefindnext
            // 
            this.replacefindnext.Location = new System.Drawing.Point(546, 169);
            this.replacefindnext.Name = "replacefindnext";
            this.replacefindnext.Size = new System.Drawing.Size(93, 29);
            this.replacefindnext.TabIndex = 9;
            this.replacefindnext.Text = "Find &Next";
            this.replacefindnext.UseVisualStyleBackColor = true;
            this.replacefindnext.Click += new System.EventHandler(this.replacefindnext_Click);
            // 
            // replacecancel
            // 
            this.replacecancel.Location = new System.Drawing.Point(647, 169);
            this.replacecancel.Name = "replacecancel";
            this.replacecancel.Size = new System.Drawing.Size(93, 29);
            this.replacecancel.TabIndex = 8;
            this.replacecancel.Text = "&Cancel";
            this.replacecancel.UseVisualStyleBackColor = true;
            this.replacecancel.Click += new System.EventHandler(this.replacecancel_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(16, 171);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(124, 24);
            this.checkBox2.TabIndex = 7;
            this.checkBox2.Text = "Case sensitive";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // replacereplacetb
            // 
            this.replacereplacetb.Location = new System.Drawing.Point(126, 87);
            this.replacereplacetb.Name = "replacereplacetb";
            this.replacereplacetb.Size = new System.Drawing.Size(614, 24);
            this.replacereplacetb.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Replace with:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // replacefindtb
            // 
            this.replacefindtb.Location = new System.Drawing.Point(126, 11);
            this.replacefindtb.Name = "replacefindtb";
            this.replacefindtb.Size = new System.Drawing.Size(614, 24);
            this.replacefindtb.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Find:";
            // 
            // findandreplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(784, 261);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 300);
            this.MinimumSize = new System.Drawing.Size(800, 300);
            this.Name = "findandreplace";
            this.Text = "Find & Replace";
            this.Load += new System.EventHandler(this.findandreplace_Load);
            this.tabControl1.ResumeLayout(false);
            this.find.ResumeLayout(false);
            this.find.PerformLayout();
            this.replace.ResumeLayout(false);
            this.replace.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage find;
        private System.Windows.Forms.TabPage replace;
        private System.Windows.Forms.TextBox replacefindtb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox findfindtb;
        private System.Windows.Forms.TextBox replacereplacetb;
        private System.Windows.Forms.Button findcancel;
        private System.Windows.Forms.Button findfindnext;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button replacefindnext;
        private System.Windows.Forms.Button replacecancel;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button replaceone;
        private System.Windows.Forms.Button replaceall;
    }
}