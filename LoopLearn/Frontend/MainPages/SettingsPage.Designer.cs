namespace LoopLearn.Frontend
{
    partial class SettingsPage
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
            comboBox2 = new ComboBox();
            lblNewWordCount = new Label();
            SuspendLayout();
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(510, 325);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(130, 28);
            comboBox2.TabIndex = 1;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // lblNewWordCount
            // 
            lblNewWordCount.AutoSize = true;
            lblNewWordCount.BackColor = Color.Transparent;
            lblNewWordCount.ForeColor = Color.White;
            lblNewWordCount.Location = new Point(317, 325);
            lblNewWordCount.Name = "lblNewWordCount";
            lblNewWordCount.Size = new Size(172, 20);
            lblNewWordCount.TabIndex = 2;
            lblNewWordCount.Text = "Günlük yeni kelime sayısı";
            // 
            // SettingsPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.LoginPageBackground;
            Controls.Add(lblNewWordCount);
            Controls.Add(comboBox2);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SettingsPage";
            Size = new Size(1187, 901);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboBox2;
        private Label lblNewWordCount;
    }
}
