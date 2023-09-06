namespace WindowsFormsApp2
{
    partial class appearance
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
            this.theme = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.reset = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fontFamilyButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // theme
            // 
            this.theme.Location = new System.Drawing.Point(110, 115);
            this.theme.Name = "theme";
            this.theme.Size = new System.Drawing.Size(1204, 103);
            this.theme.TabIndex = 0;
            this.theme.UseVisualStyleBackColor = true;
            this.theme.Click += new System.EventHandler(this.button1_Click_1);
            this.theme.Paint += new System.Windows.Forms.PaintEventHandler(this.theme_Paint);
            // 
            // reset
            // 
            this.reset.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset.Location = new System.Drawing.Point(110, 334);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(1204, 101);
            this.reset.TabIndex = 3;
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.button2_Click);
            this.reset.Paint += new System.Windows.Forms.PaintEventHandler(this.reset_Paint);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(1204, 135);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(60, 65);
            this.textBox4.TabIndex = 5;
            this.textBox4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.textBox4_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(104, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(340, 45);
            this.label3.TabIndex = 8;
            this.label3.Text = "Appearance Settings";
            // 
            // fontFamilyButton
            // 
            this.fontFamilyButton.Enabled = false;
            this.fontFamilyButton.Location = new System.Drawing.Point(110, 224);
            this.fontFamilyButton.Name = "fontFamilyButton";
            this.fontFamilyButton.Size = new System.Drawing.Size(1204, 103);
            this.fontFamilyButton.TabIndex = 9;
            this.fontFamilyButton.UseVisualStyleBackColor = true;
            this.fontFamilyButton.Click += new System.EventHandler(this.fontFamilyButton_Click);
            this.fontFamilyButton.Paint += new System.Windows.Forms.PaintEventHandler(this.fontFamilyButton_Paint);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("PMingLiU", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(967, 258);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(297, 29);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // appearance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.fontFamilyButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.theme);
            this.Name = "appearance";
            this.Size = new System.Drawing.Size(1328, 758);
            this.Load += new System.EventHandler(this.appearance_Load);
            this.BackColorChanged += new System.EventHandler(this.appearance_BackColorChanged);
            this.TabStopChanged += new System.EventHandler(this.appearance_TabStopChanged);
            this.Resize += new System.EventHandler(this.appearance_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button theme;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button fontFamilyButton;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
