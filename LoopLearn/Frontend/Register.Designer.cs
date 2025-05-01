namespace LoopLearn.Frontend
{
    partial class Register
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
            lblLoopLearn = new Label();
            lblUsername = new Label();
            lblPassword = new Label();
            lblPasswordAgain = new Label();
            lblSeqQuestion = new Label();
            cmbSeqQuestion = new ComboBox();
            tbxUsername = new TextBox();
            tbxPassword = new TextBox();
            tbxPasswordAgain = new TextBox();
            lblSeqAnswer = new Label();
            tbxSeqAnswer = new TextBox();
            btnRegister = new Button();
            lblAlrHaveAcc = new Label();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // lblLoopLearn
            // 
            lblLoopLearn.AccessibleName = "lblLogin";
            lblLoopLearn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblLoopLearn.AutoSize = true;
            lblLoopLearn.BackColor = Color.Transparent;
            lblLoopLearn.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblLoopLearn.ForeColor = Color.White;
            lblLoopLearn.Location = new Point(563, 201);
            lblLoopLearn.Name = "lblLoopLearn";
            lblLoopLearn.Size = new Size(178, 45);
            lblLoopLearn.TabIndex = 5;
            lblLoopLearn.Text = "LoopLearn";
            lblLoopLearn.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(500, 291);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(71, 15);
            lblUsername.TabIndex = 6;
            lblUsername.Text = "Kullanıcı adı";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(541, 320);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(30, 15);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Şifre";
            // 
            // lblPasswordAgain
            // 
            lblPasswordAgain.AutoSize = true;
            lblPasswordAgain.BackColor = Color.Transparent;
            lblPasswordAgain.ForeColor = Color.White;
            lblPasswordAgain.Location = new Point(488, 349);
            lblPasswordAgain.Name = "lblPasswordAgain";
            lblPasswordAgain.Size = new Size(83, 15);
            lblPasswordAgain.TabIndex = 8;
            lblPasswordAgain.Text = "Şifre (yeniden)";
            // 
            // lblSeqQuestion
            // 
            lblSeqQuestion.AutoSize = true;
            lblSeqQuestion.BackColor = Color.Transparent;
            lblSeqQuestion.ForeColor = Color.White;
            lblSeqQuestion.Location = new Point(480, 378);
            lblSeqQuestion.Name = "lblSeqQuestion";
            lblSeqQuestion.Size = new Size(91, 15);
            lblSeqQuestion.TabIndex = 9;
            lblSeqQuestion.Text = "Güvenlik sorusu";
            // 
            // cmbSeqQuestion
            // 
            cmbSeqQuestion.FormattingEnabled = true;
            cmbSeqQuestion.Items.AddRange(new object[] { "En sevdiğiniz renk?", "En sevdiğiniz hayvan?", "En sevdiğiniz içecek?" });
            cmbSeqQuestion.Location = new Point(577, 375);
            cmbSeqQuestion.MaxDropDownItems = 3;
            cmbSeqQuestion.Name = "cmbSeqQuestion";
            cmbSeqQuestion.Size = new Size(151, 23);
            cmbSeqQuestion.TabIndex = 10;
            // 
            // tbxUsername
            // 
            tbxUsername.Location = new Point(577, 288);
            tbxUsername.MaxLength = 12;
            tbxUsername.Name = "tbxUsername";
            tbxUsername.Size = new Size(151, 23);
            tbxUsername.TabIndex = 11;
            // 
            // tbxPassword
            // 
            tbxPassword.Location = new Point(577, 317);
            tbxPassword.MaxLength = 10;
            tbxPassword.Name = "tbxPassword";
            tbxPassword.Size = new Size(151, 23);
            tbxPassword.TabIndex = 12;
            // 
            // tbxPasswordAgain
            // 
            tbxPasswordAgain.Location = new Point(577, 346);
            tbxPasswordAgain.MaxLength = 10;
            tbxPasswordAgain.Name = "tbxPasswordAgain";
            tbxPasswordAgain.Size = new Size(151, 23);
            tbxPasswordAgain.TabIndex = 13;
            // 
            // lblSeqAnswer
            // 
            lblSeqAnswer.AutoSize = true;
            lblSeqAnswer.BackColor = Color.Transparent;
            lblSeqAnswer.ForeColor = Color.White;
            lblSeqAnswer.Location = new Point(531, 407);
            lblSeqAnswer.Name = "lblSeqAnswer";
            lblSeqAnswer.Size = new Size(40, 15);
            lblSeqAnswer.TabIndex = 14;
            lblSeqAnswer.Text = "Cevap";
            // 
            // tbxSeqAnswer
            // 
            tbxSeqAnswer.Location = new Point(577, 404);
            tbxSeqAnswer.MaxLength = 15;
            tbxSeqAnswer.Name = "tbxSeqAnswer";
            tbxSeqAnswer.Size = new Size(151, 23);
            tbxSeqAnswer.TabIndex = 15;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(577, 455);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(151, 23);
            btnRegister.TabIndex = 16;
            btnRegister.Text = "Üye ol";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblAlrHaveAcc
            // 
            lblAlrHaveAcc.AutoSize = true;
            lblAlrHaveAcc.BackColor = Color.Transparent;
            lblAlrHaveAcc.ForeColor = Color.White;
            lblAlrHaveAcc.Location = new Point(577, 488);
            lblAlrHaveAcc.Name = "lblAlrHaveAcc";
            lblAlrHaveAcc.Size = new Size(91, 15);
            lblAlrHaveAcc.TabIndex = 17;
            lblAlrHaveAcc.Text = "Hesabın var mı?";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(674, 484);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(54, 23);
            btnLogin.TabIndex = 18;
            btnLogin.Text = "Giriş yap";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.LoginPageBackground;
            ClientSize = new Size(1264, 681);
            Controls.Add(btnLogin);
            Controls.Add(lblAlrHaveAcc);
            Controls.Add(btnRegister);
            Controls.Add(tbxSeqAnswer);
            Controls.Add(lblSeqAnswer);
            Controls.Add(tbxPasswordAgain);
            Controls.Add(tbxPassword);
            Controls.Add(tbxUsername);
            Controls.Add(cmbSeqQuestion);
            Controls.Add(lblSeqQuestion);
            Controls.Add(lblPasswordAgain);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(lblLoopLearn);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MinimizeBox = false;
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoopLearn";
            TopMost = true;
            Load += Register_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLoopLearn;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblPasswordAgain;
        private Label lblSeqQuestion;
        private ComboBox cmbSeqQuestion;
        private TextBox tbxUsername;
        private TextBox tbxPassword;
        private TextBox tbxPasswordAgain;
        private Label lblSeqAnswer;
        private TextBox tbxSeqAnswer;
        private Button btnRegister;
        private Label lblAlrHaveAcc;
        private Button btnLogin;
    }
}