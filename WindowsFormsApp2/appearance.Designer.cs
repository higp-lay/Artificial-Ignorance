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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fontFamilyButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // theme
            // 
            this.theme.Location = new System.Drawing.Point(110, 106);
            this.theme.Name = "theme";
            this.theme.Size = new System.Drawing.Size(1204, 95);
            this.theme.TabIndex = 0;
            this.theme.UseVisualStyleBackColor = true;
            this.theme.Click += new System.EventHandler(this.button1_Click_1);
            this.theme.MouseDown += new System.Windows.Forms.MouseEventHandler(this.theme_MouseDown);
            this.theme.MouseEnter += new System.EventHandler(this.theme_MouseEnter);
            this.theme.MouseLeave += new System.EventHandler(this.theme_MouseLeave);
            this.theme.MouseUp += new System.Windows.Forms.MouseEventHandler(this.theme_MouseUp);
            // 
            // reset
            // 
            this.reset.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset.Location = new System.Drawing.Point(110, 308);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(1204, 93);
            this.reset.TabIndex = 3;
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.button2_Click);
            this.reset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.reset_MouseDown);
            this.reset.MouseEnter += new System.EventHandler(this.reset_MouseEnter);
            this.reset.MouseLeave += new System.EventHandler(this.reset_MouseLeave);
            this.reset.MouseUp += new System.Windows.Forms.MouseEventHandler(this.reset_MouseUp);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(1204, 125);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(60, 60);
            this.textBox4.TabIndex = 5;
            this.textBox4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.textBox4_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 38);
            this.label1.TabIndex = 6;
            this.label1.Text = "Theme";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(128, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(104, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(340, 45);
            this.label3.TabIndex = 8;
            this.label3.Text = "Appearance Settings";
            // 
            // fontFamilyButton
            // 
            this.fontFamilyButton.Enabled = false;
            this.fontFamilyButton.Location = new System.Drawing.Point(110, 207);
            this.fontFamilyButton.Name = "fontFamilyButton";
            this.fontFamilyButton.Size = new System.Drawing.Size(1204, 95);
            this.fontFamilyButton.TabIndex = 9;
            this.fontFamilyButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(125, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 38);
            this.label4.TabIndex = 10;
            this.label4.Text = "Font";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("PMingLiU", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(967, 238);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(297, 29);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Window;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(125, 319);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(362, 38);
            this.label5.TabIndex = 12;
            this.label5.Text = "Reset Appearance Settings";
            // 
            // appearance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fontFamilyButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.theme);
            this.Name = "appearance";
            this.Size = new System.Drawing.Size(1328, 700);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button fontFamilyButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
    }
}
