namespace WindowsFormsApp2
{
    partial class UserControl2
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl2));
            this.submit = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.import = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.boldButton = new System.Windows.Forms.Button();
            this.italicButton = new System.Windows.Forms.Button();
            this.underlineButton = new System.Windows.Forms.Button();
            this.strikeThroughButton = new System.Windows.Forms.Button();
            this.fullAlign = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.leftAlign = new System.Windows.Forms.Button();
            this.rightAlign = new System.Windows.Forms.Button();
            this.centerAlign = new System.Windows.Forms.Button();
            this.fontCombo = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.sizeCombo = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.wordslabel = new System.Windows.Forms.Label();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // submit
            // 
            this.submit.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.submit.Location = new System.Drawing.Point(1169, 602);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(109, 40);
            this.submit.TabIndex = 3;
            this.submit.Text = "Statistics";
            this.toolTip1.SetToolTip(this.submit, "Click to generate a Report.");
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // import
            // 
            this.import.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.import.Location = new System.Drawing.Point(1169, 540);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(109, 40);
            this.import.TabIndex = 2;
            this.import.Text = "Import";
            this.toolTip1.SetToolTip(this.import, "Click to import a file.");
            this.import.UseVisualStyleBackColor = true;
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // save
            // 
            this.save.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.save.Location = new System.Drawing.Point(1169, 481);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(109, 40);
            this.save.TabIndex = 1;
            this.save.Text = "Save";
            this.toolTip1.SetToolTip(this.save, "Click to save your text.");
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // boldButton
            // 
            this.boldButton.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boldButton.Location = new System.Drawing.Point(34, 654);
            this.boldButton.Name = "boldButton";
            this.boldButton.Size = new System.Drawing.Size(30, 32);
            this.boldButton.TabIndex = 8;
            this.boldButton.Text = "B";
            this.toolTip1.SetToolTip(this.boldButton, "Click to make your text bold.");
            this.boldButton.UseVisualStyleBackColor = true;
            this.boldButton.Click += new System.EventHandler(this.boldButton_Click);
            // 
            // italicButton
            // 
            this.italicButton.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.italicButton.Location = new System.Drawing.Point(64, 654);
            this.italicButton.Name = "italicButton";
            this.italicButton.Size = new System.Drawing.Size(30, 32);
            this.italicButton.TabIndex = 9;
            this.italicButton.Text = "I";
            this.toolTip1.SetToolTip(this.italicButton, "Click to make your text italic.");
            this.italicButton.UseVisualStyleBackColor = true;
            this.italicButton.Click += new System.EventHandler(this.italicButton_Click);
            // 
            // underlineButton
            // 
            this.underlineButton.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.underlineButton.Location = new System.Drawing.Point(95, 654);
            this.underlineButton.Name = "underlineButton";
            this.underlineButton.Size = new System.Drawing.Size(30, 32);
            this.underlineButton.TabIndex = 10;
            this.underlineButton.Text = "U";
            this.toolTip1.SetToolTip(this.underlineButton, "Click to make your text underlined.");
            this.underlineButton.UseVisualStyleBackColor = true;
            this.underlineButton.Click += new System.EventHandler(this.underlineButton_Click);
            // 
            // strikeThroughButton
            // 
            this.strikeThroughButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.strikeThroughButton.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strikeThroughButton.Location = new System.Drawing.Point(127, 654);
            this.strikeThroughButton.Name = "strikeThroughButton";
            this.strikeThroughButton.Size = new System.Drawing.Size(30, 32);
            this.strikeThroughButton.TabIndex = 11;
            this.strikeThroughButton.Text = "S";
            this.toolTip1.SetToolTip(this.strikeThroughButton, "Click to make your text striked through.");
            this.strikeThroughButton.UseMnemonic = false;
            this.strikeThroughButton.UseVisualStyleBackColor = true;
            this.strikeThroughButton.Click += new System.EventHandler(this.strikethrough_Click);
            // 
            // fullAlign
            // 
            this.fullAlign.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fullAlign.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullAlign.Location = new System.Drawing.Point(402, 653);
            this.fullAlign.Name = "fullAlign";
            this.fullAlign.Size = new System.Drawing.Size(30, 32);
            this.fullAlign.TabIndex = 16;
            this.fullAlign.TabStop = false;
            this.fullAlign.Text = "S";
            this.toolTip1.SetToolTip(this.fullAlign, "Click to make your text striked through.");
            this.fullAlign.UseMnemonic = false;
            this.fullAlign.UseVisualStyleBackColor = true;
            this.fullAlign.Visible = false;
            this.fullAlign.Click += new System.EventHandler(this.fullAlign_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::WindowsFormsApp2.Properties.Resources.fontdecrease;
            this.button2.Location = new System.Drawing.Point(560, 653);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 32);
            this.button2.TabIndex = 20;
            this.toolTip1.SetToolTip(this.button2, "Click to decrease your font size. (Ctrl + Shift + <)");
            this.button2.UseMnemonic = false;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::WindowsFormsApp2.Properties.Resources.increasefont3;
            this.button1.Location = new System.Drawing.Point(524, 653);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 32);
            this.button1.TabIndex = 19;
            this.toolTip1.SetToolTip(this.button1, "Click to increase your font size. (Ctrl + Shift + >)");
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // leftAlign
            // 
            this.leftAlign.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.leftAlign.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftAlign.Image = global::WindowsFormsApp2.Properties.Resources.align_left_solid;
            this.leftAlign.Location = new System.Drawing.Point(306, 653);
            this.leftAlign.Name = "leftAlign";
            this.leftAlign.Size = new System.Drawing.Size(30, 32);
            this.leftAlign.TabIndex = 14;
            this.toolTip1.SetToolTip(this.leftAlign, "Click to left align your content. (Ctrl + L)\r\n");
            this.leftAlign.UseMnemonic = false;
            this.leftAlign.UseVisualStyleBackColor = true;
            this.leftAlign.Click += new System.EventHandler(this.leftAlign_Click_1);
            // 
            // rightAlign
            // 
            this.rightAlign.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rightAlign.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightAlign.Image = global::WindowsFormsApp2.Properties.Resources.align_right_solid;
            this.rightAlign.Location = new System.Drawing.Point(370, 653);
            this.rightAlign.Name = "rightAlign";
            this.rightAlign.Size = new System.Drawing.Size(30, 32);
            this.rightAlign.TabIndex = 16;
            this.toolTip1.SetToolTip(this.rightAlign, "Click to right align your content. (Ctrl + R)\r\n");
            this.rightAlign.UseMnemonic = false;
            this.rightAlign.UseVisualStyleBackColor = true;
            this.rightAlign.Click += new System.EventHandler(this.rightAlign_Click);
            // 
            // centerAlign
            // 
            this.centerAlign.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.centerAlign.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.centerAlign.Image = global::WindowsFormsApp2.Properties.Resources.align_center_solid;
            this.centerAlign.Location = new System.Drawing.Point(338, 653);
            this.centerAlign.Name = "centerAlign";
            this.centerAlign.Size = new System.Drawing.Size(30, 32);
            this.centerAlign.TabIndex = 15;
            this.toolTip1.SetToolTip(this.centerAlign, "Click to center align your content. (Ctrl + E)");
            this.centerAlign.UseMnemonic = false;
            this.centerAlign.UseVisualStyleBackColor = true;
            this.centerAlign.Click += new System.EventHandler(this.centerAlign_Click);
            // 
            // fontCombo
            // 
            this.fontCombo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fontCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fontCombo.DropDownWidth = 300;
            this.fontCombo.Font = new System.Drawing.Font("PMingLiU", 16F);
            this.fontCombo.FormattingEnabled = true;
            this.fontCombo.Location = new System.Drawing.Point(163, 654);
            this.fontCombo.Name = "fontCombo";
            this.fontCombo.Size = new System.Drawing.Size(140, 29);
            this.fontCombo.TabIndex = 12;
            this.fontCombo.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.fontCombo_DrawItem);
            this.fontCombo.SelectedIndexChanged += new System.EventHandler(this.fontCombo_SelectedIndexChanged);
            this.fontCombo.SelectedValueChanged += new System.EventHandler(this.fontCombo_SelectedValueChanged);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // sizeCombo
            // 
            this.sizeCombo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.sizeCombo.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeCombo.FormattingEnabled = true;
            this.sizeCombo.Location = new System.Drawing.Point(438, 653);
            this.sizeCombo.Name = "sizeCombo";
            this.sizeCombo.Size = new System.Drawing.Size(66, 34);
            this.sizeCombo.TabIndex = 18;
            this.sizeCombo.SelectedIndexChanged += new System.EventHandler(this.sizeCombo_SelectedIndexChanged);
            this.sizeCombo.TextUpdate += new System.EventHandler(this.sizeCombo_TextUpdate);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1169, 199);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 162);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(1161, 32);
            this.label1.MaximumSize = new System.Drawing.Size(184, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 135);
            this.label1.TabIndex = 21;
            this.label1.Text = "Artificial Ignorance (AI)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(1164, 391);
            this.label2.MaximumSize = new System.Drawing.Size(184, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 50);
            this.label2.TabIndex = 22;
            this.label2.Text = "- A Forefront Text Analyzer";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Times New Roman", 15F);
            this.richTextBox1.Location = new System.Drawing.Point(34, 32);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1090, 620);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.SelectionChanged += new System.EventHandler(this.richTextBox1_SelectionChanged);
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            this.richTextBox1.Enter += new System.EventHandler(this.richTextBox1_Enter);
            this.richTextBox1.Leave += new System.EventHandler(this.richTextBox1_Leave);
            // 
            // wordslabel
            // 
            this.wordslabel.AutoSize = true;
            this.wordslabel.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.wordslabel.Location = new System.Drawing.Point(1072, 667);
            this.wordslabel.Name = "wordslabel";
            this.wordslabel.Size = new System.Drawing.Size(52, 21);
            this.wordslabel.TabIndex = 23;
            this.wordslabel.Text = "label3";
            // 
            // UserControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.wordslabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sizeCombo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.leftAlign);
            this.Controls.Add(this.fullAlign);
            this.Controls.Add(this.rightAlign);
            this.Controls.Add(this.centerAlign);
            this.Controls.Add(this.fontCombo);
            this.Controls.Add(this.strikeThroughButton);
            this.Controls.Add(this.underlineButton);
            this.Controls.Add(this.italicButton);
            this.Controls.Add(this.boldButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.import);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.richTextBox1);
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(1419, 708);
            this.Load += new System.EventHandler(this.UserControl2_Load);
            this.BackColorChanged += new System.EventHandler(this.UserControl2_BackColorChanged);
            this.FontChanged += new System.EventHandler(this.UserControl2_FontChanged);
            this.TabIndexChanged += new System.EventHandler(this.UserControl2_TabIndexChanged);
            this.TabStopChanged += new System.EventHandler(this.UserControl2_TabStopChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserControl2_KeyDown);
            this.Resize += new System.EventHandler(this.UserControl2_Resize);
            this.StyleChanged += new System.EventHandler(this.UserControl2_StyleChanged);
            this.SystemColorsChanged += new System.EventHandler(this.UserControl2_SystemColorsChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button import;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button boldButton;
        private System.Windows.Forms.Button italicButton;
        private System.Windows.Forms.Button underlineButton;
        private System.Windows.Forms.Button strikeThroughButton;
        private System.Windows.Forms.ComboBox fontCombo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Button centerAlign;
        private System.Windows.Forms.Button rightAlign;
        private System.Windows.Forms.Button fullAlign;
        private System.Windows.Forms.Button leftAlign;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox sizeCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label wordslabel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
    }
}
