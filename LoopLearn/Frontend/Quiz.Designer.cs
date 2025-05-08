namespace LoopLearn.Frontend
{
    partial class Quiz
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
            btnNextQuestion = new Button();
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
            btnStartQuiz.Location = new Point(398, 310);
            btnStartQuiz.Name = "btnStartQuiz";
            btnStartQuiz.Size = new Size(227, 81);
            btnStartQuiz.TabIndex = 0;
            btnStartQuiz.Text = "Sınavı başlat";
            btnStartQuiz.UseVisualStyleBackColor = true;
            btnStartQuiz.Click += btnStartQuiz_Click;
            // 
            // btnNextQuestion
            // 
            btnNextQuestion.Location = new Point(398, 502);
            btnNextQuestion.Name = "btnNextQuestion";
            btnNextQuestion.Size = new Size(227, 23);
            btnNextQuestion.TabIndex = 1;
            btnNextQuestion.Text = "Sonraki Soru";
            btnNextQuestion.UseVisualStyleBackColor = true;
            btnNextQuestion.Visible = false;
            btnNextQuestion.Click += btnNextQuestion_Click;
            // 
            // lblQuestion
            // 
            lblQuestion.AutoEllipsis = true;
            lblQuestion.BackColor = Color.Transparent;
            lblQuestion.Font = new Font("Segoe UI", 15F);
            lblQuestion.ForeColor = Color.White;
            lblQuestion.Location = new Point(398, 358);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(227, 84);
            lblQuestion.TabIndex = 2;
            lblQuestion.Text = "BURASI SORU OLAYI";
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
            btnA.Size = new Size(106, 23);
            btnA.TabIndex = 6;
            btnA.Text = "A)";
            btnA.UseVisualStyleBackColor = true;
            btnA.Visible = false;
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
            // 
            // btnC
            // 
            btnC.Location = new Point(398, 474);
            btnC.Name = "btnC";
            btnC.Size = new Size(106, 23);
            btnC.TabIndex = 8;
            btnC.Text = "C)";
            btnC.UseVisualStyleBackColor = true;
            btnC.Visible = false;
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
            Controls.Add(btnNextQuestion);
            Controls.Add(btnStartQuiz);
            Name = "Quiz";
            Size = new Size(1039, 676);
            ((System.ComponentModel.ISupportInitialize)pctPicture).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnStartQuiz;
        private Button btnNextQuestion;
        private Label lblQuestion;
        private PictureBox pctPicture;
        private Button btnA;
        private Button btnB;
        private Button btnC;
        private Button btnD;
    }
}
