﻿namespace LoopLearn.Frontend
{
    partial class PuzzlePage
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
            PuzzleName = new Label();
            SuspendLayout();
            // 
            // PuzzleName
            // 
            PuzzleName.AutoSize = true;
            PuzzleName.BackColor = Color.Transparent;
            PuzzleName.Font = new Font("Arial", 32F, FontStyle.Bold);
            PuzzleName.ForeColor = Color.White;
            PuzzleName.Location = new Point(408, 42);
            PuzzleName.Name = "PuzzleName";
            PuzzleName.Size = new Size(211, 51);
            PuzzleName.TabIndex = 0;
            PuzzleName.Text = "WORDLE";
            // 
            // PuzzlePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.LoginPageBackground;
            Controls.Add(PuzzleName);
            Name = "PuzzlePage";
            Size = new Size(1120, 540);
            Load += PuzzlePage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label PuzzleName;
    }
}