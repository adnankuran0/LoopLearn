﻿namespace LoopLearn.Frontend
{
    partial class QuizPage
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
            btnStartQuiz = new Button();
            lblQuestion = new Label();
            pctPicture = new PictureBox();
            btnA = new Button();
            btnB = new Button();
            btnC = new Button();
            btnD = new Button();
            ((System.ComponentModel.ISupportInitialize)pctPicture).BeginInit();
            SuspendLayout();
            // 
            // btnStartQuiz
            // 
            btnStartQuiz.BackColor = Color.Transparent;
            btnStartQuiz.BackgroundImage = Properties.Resources.LoginPageBackground;
            btnStartQuiz.BackgroundImageLayout = ImageLayout.Stretch;
            btnStartQuiz.FlatAppearance.BorderSize = 0;
            btnStartQuiz.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnStartQuiz.ForeColor = Color.White;
            btnStartQuiz.Location = new Point(398, 310);
            btnStartQuiz.Name = "btnStartQuiz";
            btnStartQuiz.Size = new Size(227, 81);
            btnStartQuiz.TabIndex = 0;
            btnStartQuiz.Text = "Sınavı başlat!";
            btnStartQuiz.UseVisualStyleBackColor = false;
            btnStartQuiz.Click += btnStartQuiz_Click;
            // 
            // lblQuestion
            // 
            lblQuestion.AutoEllipsis = true;
            lblQuestion.BackColor = Color.Transparent;
            lblQuestion.Font = new Font("Segoe UI", 15F);
            lblQuestion.ForeColor = Color.White;
            lblQuestion.Location = new Point(398, 369);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(227, 73);
            lblQuestion.TabIndex = 2;
            lblQuestion.Text = "SORU";
            lblQuestion.TextAlign = ContentAlignment.MiddleCenter;
            lblQuestion.Visible = false;
            // 
            // pctPicture
            // 
            pctPicture.BackColor = Color.Silver;
            pctPicture.Location = new Point(398, 154);
            pctPicture.Name = "pctPicture";
            pctPicture.Size = new Size(227, 201);
            pctPicture.SizeMode = PictureBoxSizeMode.Zoom;
            pctPicture.TabIndex = 5;
            pctPicture.TabStop = false;
            pctPicture.Visible = false;
            // 
            // btnA
            // 
            btnA.Location = new Point(398, 445);
            btnA.Name = "btnA";
            btnA.Size = new Size(109, 23);
            btnA.TabIndex = 6;
            btnA.Text = "A)";
            btnA.UseVisualStyleBackColor = true;
            btnA.Visible = false;
            btnA.Click += btnAnswer_Click;
            // 
            // btnB
            // 
            btnB.Location = new Point(522, 445);
            btnB.Name = "btnB";
            btnB.Size = new Size(103, 23);
            btnB.TabIndex = 7;
            btnB.Text = "B)";
            btnB.UseVisualStyleBackColor = true;
            btnB.Visible = false;
            btnB.Click += btnAnswer_Click;
            // 
            // btnC
            // 
            btnC.Location = new Point(398, 474);
            btnC.Name = "btnC";
            btnC.Size = new Size(109, 23);
            btnC.TabIndex = 8;
            btnC.Text = "C)";
            btnC.UseVisualStyleBackColor = true;
            btnC.Visible = false;
            btnC.Click += btnAnswer_Click;
            // 
            // btnD
            // 
            btnD.Location = new Point(522, 474);
            btnD.Name = "btnD";
            btnD.Size = new Size(103, 23);
            btnD.TabIndex = 9;
            btnD.Text = "D)";
            btnD.UseVisualStyleBackColor = true;
            btnD.Visible = false;
            btnD.Click += btnAnswer_Click;
            // 
            // Quiz
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.LoginPageBackground;
            Controls.Add(btnD);
            Controls.Add(btnC);
            Controls.Add(btnB);
            Controls.Add(btnA);
            Controls.Add(pctPicture);
            Controls.Add(lblQuestion);
            Controls.Add(btnStartQuiz);
            Name = "Quiz";
            Size = new Size(1039, 676);
            ((System.ComponentModel.ISupportInitialize)pctPicture).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnStartQuiz;
        private Label lblQuestion;
        private PictureBox pctPicture;
        private Button btnA;
        private Button btnB;
        private Button btnC;
        private Button btnD;
    }
}
