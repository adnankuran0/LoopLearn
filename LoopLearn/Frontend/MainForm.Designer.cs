namespace LoopLearn.Frontend
{
    partial class MainForm
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
            panel1 = new Panel();
            btnExit = new Button();
            btnSettings = new Button();
            btnMemNail = new Button();
            btnPuzzle = new Button();
            btnRport = new Button();
            btnQuiz = new Button();
            btnAddWord = new Button();
            panel2 = new Panel();
            pnlContent = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Navy;
            panel1.Controls.Add(btnExit);
            panel1.Controls.Add(btnSettings);
            panel1.Controls.Add(btnMemNail);
            panel1.Controls.Add(btnPuzzle);
            panel1.Controls.Add(btnRport);
            panel1.Controls.Add(btnQuiz);
            panel1.Controls.Add(btnAddWord);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(223, 681);
            panel1.TabIndex = 0;
            // 
            // btnExit
            // 
            btnExit.Dock = DockStyle.Top;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(0, 484);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(223, 64);
            btnExit.TabIndex = 7;
            btnExit.Text = "Çıkış";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnSettings
            // 
            btnSettings.Dock = DockStyle.Top;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.ForeColor = Color.White;
            btnSettings.Location = new Point(0, 420);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(223, 64);
            btnSettings.TabIndex = 6;
            btnSettings.Text = "Ayarlar";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnMemNail
            // 
            btnMemNail.Dock = DockStyle.Top;
            btnMemNail.FlatAppearance.BorderSize = 0;
            btnMemNail.FlatStyle = FlatStyle.Flat;
            btnMemNail.ForeColor = Color.White;
            btnMemNail.Location = new Point(0, 356);
            btnMemNail.Name = "btnMemNail";
            btnMemNail.Size = new Size(223, 64);
            btnMemNail.TabIndex = 5;
            btnMemNail.Text = "Hafıza Çivisi";
            btnMemNail.UseVisualStyleBackColor = true;
            btnMemNail.Click += btnMemNail_Click;
            // 
            // btnPuzzle
            // 
            btnPuzzle.Dock = DockStyle.Top;
            btnPuzzle.FlatAppearance.BorderSize = 0;
            btnPuzzle.FlatStyle = FlatStyle.Flat;
            btnPuzzle.ForeColor = Color.White;
            btnPuzzle.Location = new Point(0, 292);
            btnPuzzle.Name = "btnPuzzle";
            btnPuzzle.Size = new Size(223, 64);
            btnPuzzle.TabIndex = 4;
            btnPuzzle.Text = "Puzzle";
            btnPuzzle.UseVisualStyleBackColor = true;
            btnPuzzle.Click += btnPuzzle_Click;
            // 
            // btnRport
            // 
            btnRport.Dock = DockStyle.Top;
            btnRport.FlatAppearance.BorderSize = 0;
            btnRport.FlatStyle = FlatStyle.Flat;
            btnRport.ForeColor = Color.White;
            btnRport.Location = new Point(0, 228);
            btnRport.Name = "btnRport";
            btnRport.Size = new Size(223, 64);
            btnRport.TabIndex = 3;
            btnRport.Text = "Rapor";
            btnRport.UseVisualStyleBackColor = true;
            btnRport.Click += btnRport_Click;
            // 
            // btnQuiz
            // 
            btnQuiz.Dock = DockStyle.Top;
            btnQuiz.FlatAppearance.BorderSize = 0;
            btnQuiz.FlatStyle = FlatStyle.Flat;
            btnQuiz.ForeColor = Color.White;
            btnQuiz.Location = new Point(0, 164);
            btnQuiz.Name = "btnQuiz";
            btnQuiz.Size = new Size(223, 64);
            btnQuiz.TabIndex = 2;
            btnQuiz.Text = "Sınav";
            btnQuiz.UseVisualStyleBackColor = true;
            btnQuiz.Click += btnQuiz_Click;
            // 
            // btnAddWord
            // 
            btnAddWord.Dock = DockStyle.Top;
            btnAddWord.FlatAppearance.BorderSize = 0;
            btnAddWord.FlatStyle = FlatStyle.Flat;
            btnAddWord.ForeColor = Color.White;
            btnAddWord.Location = new Point(0, 100);
            btnAddWord.Name = "btnAddWord";
            btnAddWord.Size = new Size(223, 64);
            btnAddWord.TabIndex = 1;
            btnAddWord.Text = "Kelime Ekle";
            btnAddWord.UseVisualStyleBackColor = true;
            btnAddWord.Click += btnAddWord_Click;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(223, 100);
            panel2.TabIndex = 0;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.Transparent;
            pnlContent.Dock = DockStyle.Left;
            pnlContent.Location = new Point(223, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1044, 681);
            pnlContent.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.LoginPageBackground;
            ClientSize = new Size(1264, 681);
            Controls.Add(pnlContent);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnAddWord;
        private Panel panel2;
        private Button btnSettings;
        private Button btnMemNail;
        private Button btnPuzzle;
        private Button btnRport;
        private Button btnQuiz;
        private Button btnExit;
        private Panel pnlContent;
    }
}