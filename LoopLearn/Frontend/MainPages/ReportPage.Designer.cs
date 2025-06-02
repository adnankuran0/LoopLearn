namespace LoopLearn.Frontend
{
    partial class Report
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
            labelCorrectQuestions = new Label();
            labelCorrectPuzzles = new Label();
            btnPrintStats = new Button();
            SuspendLayout();
            // 
            // labelCorrectQuestions
            // 
            labelCorrectQuestions.AutoSize = true;
            labelCorrectQuestions.BackColor = Color.Transparent;
            labelCorrectQuestions.ForeColor = Color.White;
            labelCorrectQuestions.Location = new Point(425, 260);
            labelCorrectQuestions.Name = "labelCorrectQuestions";
            labelCorrectQuestions.Size = new Size(38, 15);
            labelCorrectQuestions.TabIndex = 0;
            labelCorrectQuestions.Text = "label1";
            labelCorrectQuestions.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelCorrectPuzzles
            // 
            labelCorrectPuzzles.AutoSize = true;
            labelCorrectPuzzles.BackColor = Color.Transparent;
            labelCorrectPuzzles.ForeColor = Color.White;
            labelCorrectPuzzles.Location = new Point(425, 295);
            labelCorrectPuzzles.Name = "labelCorrectPuzzles";
            labelCorrectPuzzles.Size = new Size(38, 15);
            labelCorrectPuzzles.TabIndex = 1;
            labelCorrectPuzzles.Text = "label2";
            labelCorrectPuzzles.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPrintStats
            // 
            btnPrintStats.Location = new Point(425, 371);
            btnPrintStats.Name = "btnPrintStats";
            btnPrintStats.Size = new Size(158, 23);
            btnPrintStats.TabIndex = 2;
            btnPrintStats.Text = "Raporu yazdır";
            btnPrintStats.UseVisualStyleBackColor = true;
            btnPrintStats.Click += btnPrintStats_Click;
            // 
            // Report
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.LoginPageBackground;
            Controls.Add(btnPrintStats);
            Controls.Add(labelCorrectPuzzles);
            Controls.Add(labelCorrectQuestions);
            Name = "Report";
            Size = new Size(1039, 676);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelCorrectQuestions;
        private Label labelCorrectPuzzles;
        private Button btnPrintStats;
    }
}
