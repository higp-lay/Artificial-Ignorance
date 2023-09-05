namespace WindowsFormsApp2
{
    partial class analyzersettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.defaultFont = new System.Windows.Forms.Button();
            this.defaultSize = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.reset = new System.Windows.Forms.Button();
            this.defaultDir = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.showFileDialog = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(104, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 45);
            this.label1.TabIndex = 9;
            this.label1.Text = "Analyzer Settings";
            // 
            // defaultFont
            // 
            this.defaultFont.Enabled = false;
            this.defaultFont.Location = new System.Drawing.Point(83, 114);
            this.defaultFont.Name = "defaultFont";
            this.defaultFont.Size = new System.Drawing.Size(1204, 95);
            this.defaultFont.TabIndex = 10;
            this.defaultFont.UseVisualStyleBackColor = true;
            this.defaultFont.Click += new System.EventHandler(this.theme_Click);
            this.defaultFont.Paint += new System.Windows.Forms.PaintEventHandler(this.defaultFont_Paint);
            // 
            // defaultSize
            // 
            this.defaultSize.Enabled = false;
            this.defaultSize.Location = new System.Drawing.Point(83, 215);
            this.defaultSize.Name = "defaultSize";
            this.defaultSize.Size = new System.Drawing.Size(1204, 95);
            this.defaultSize.TabIndex = 13;
            this.defaultSize.UseVisualStyleBackColor = true;
            this.defaultSize.Paint += new System.Windows.Forms.PaintEventHandler(this.defaultSize_Paint);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("PMingLiU", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(963, 145);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(297, 29);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("PMingLiU", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(1154, 246);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(106, 29);
            this.comboBox2.TabIndex = 17;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            this.comboBox2.TextChanged += new System.EventHandler(this.comboBox2_TextChanged);
            // 
            // reset
            // 
            this.reset.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset.Location = new System.Drawing.Point(83, 514);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(1204, 93);
            this.reset.TabIndex = 18;
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            this.reset.Paint += new System.Windows.Forms.PaintEventHandler(this.reset_Paint);
            // 
            // defaultDir
            // 
            this.defaultDir.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultDir.Location = new System.Drawing.Point(83, 316);
            this.defaultDir.Name = "defaultDir";
            this.defaultDir.Size = new System.Drawing.Size(1204, 93);
            this.defaultDir.TabIndex = 20;
            this.defaultDir.UseVisualStyleBackColor = true;
            this.defaultDir.Click += new System.EventHandler(this.defaultDir_Click);
            this.defaultDir.Paint += new System.Windows.Forms.PaintEventHandler(this.defaultDir_Paint);
            this.defaultDir.MouseDown += new System.Windows.Forms.MouseEventHandler(this.defaultDir_MouseDown);
            this.defaultDir.MouseEnter += new System.EventHandler(this.defaultDir_MouseEnter);
            this.defaultDir.MouseLeave += new System.EventHandler(this.defaultDir_MouseLeave);
            this.defaultDir.MouseUp += new System.Windows.Forms.MouseEventHandler(this.defaultDir_MouseUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(101, 367);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 23);
            this.label8.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.label10.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(923, 329);
            this.label10.MaximumSize = new System.Drawing.Size(700, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 23);
            this.label10.TabIndex = 24;
            this.label10.Text = "C:\\";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // showFileDialog
            // 
            this.showFileDialog.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showFileDialog.Location = new System.Drawing.Point(83, 415);
            this.showFileDialog.Name = "showFileDialog";
            this.showFileDialog.Size = new System.Drawing.Size(1204, 93);
            this.showFileDialog.TabIndex = 25;
            this.showFileDialog.UseVisualStyleBackColor = true;
            this.showFileDialog.Click += new System.EventHandler(this.showFileDialog_Click);
            this.showFileDialog.Paint += new System.Windows.Forms.PaintEventHandler(this.showFileDialog_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Location = new System.Drawing.Point(1211, 441);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // analyzersettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.showFileDialog);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.defaultDir);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.defaultSize);
            this.Controls.Add(this.defaultFont);
            this.Controls.Add(this.label1);
            this.Name = "analyzersettings";
            this.Size = new System.Drawing.Size(1328, 700);
            this.Load += new System.EventHandler(this.analyzersettings_Load);
            this.BackColorChanged += new System.EventHandler(this.analyzersettings_BackColorChanged);
            this.Resize += new System.EventHandler(this.analyzersettings_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button defaultFont;
        private System.Windows.Forms.Button defaultSize;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button defaultDir;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button showFileDialog;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
