namespace LoopLearn.Frontend
{
    partial class RegisterPage
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
            btnLogin = new Button();
            lblAlrHaveAcc = new Label();
            btnRegister = new Button();
            tbxSeqAnswer = new TextBox();
            lblSeqAnswer = new Label();
            tbxPasswordAgain = new TextBox();
            tbxPassword = new TextBox();
            tbxUsername = new TextBox();
            cmbSeqQuestion = new ComboBox();
            lblSeqQuestion = new Label();
            lblPasswordAgain = new Label();
            lblPassword = new Label();
            lblUsername = new Label();
            lblLoopLearn = new Label();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(673, 505);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(54, 23);
            btnLogin.TabIndex = 32;
            btnLogin.Text = "Giriş yap";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblAlrHaveAcc
            // 
            lblAlrHaveAcc.AutoSize = true;
            lblAlrHaveAcc.BackColor = Color.Transparent;
            lblAlrHaveAcc.ForeColor = Color.White;
            lblAlrHaveAcc.Location = new Point(576, 509);
            lblAlrHaveAcc.Name = "lblAlrHaveAcc";
            lblAlrHaveAcc.Size = new Size(91, 15);
            lblAlrHaveAcc.TabIndex = 31;
            lblAlrHaveAcc.Text = "Hesabın var mı?";
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(576, 476);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(151, 23);
            btnRegister.TabIndex = 30;
            btnRegister.Text = "Üye ol";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // tbxSeqAnswer
            // 
            tbxSeqAnswer.Location = new Point(576, 425);
            tbxSeqAnswer.MaxLength = 15;
            tbxSeqAnswer.Name = "tbxSeqAnswer";
            tbxSeqAnswer.Size = new Size(151, 23);
            tbxSeqAnswer.TabIndex = 29;
            // 
            // lblSeqAnswer
            // 
            lblSeqAnswer.AutoSize = true;
            lblSeqAnswer.BackColor = Color.Transparent;
            lblSeqAnswer.ForeColor = Color.White;
            lblSeqAnswer.Location = new Point(530, 428);
            lblSeqAnswer.Name = "lblSeqAnswer";
            lblSeqAnswer.Size = new Size(40, 15);
            lblSeqAnswer.TabIndex = 28;
            lblSeqAnswer.Text = "Cevap";
            // 
            // tbxPasswordAgain
            // 
            tbxPasswordAgain.Location = new Point(576, 367);
            tbxPasswordAgain.MaxLength = 10;
            tbxPasswordAgain.Name = "tbxPasswordAgain";
            tbxPasswordAgain.Size = new Size(151, 23);
            tbxPasswordAgain.TabIndex = 27;
            // 
            // tbxPassword
            // 
            tbxPassword.Location = new Point(576, 338);
            tbxPassword.MaxLength = 10;
            tbxPassword.Name = "tbxPassword";
            tbxPassword.Size = new Size(151, 23);
            tbxPassword.TabIndex = 26;
            // 
            // tbxUsername
            // 
            tbxUsername.Location = new Point(576, 309);
            tbxUsername.MaxLength = 12;
            tbxUsername.Name = "tbxUsername";
            tbxUsername.Size = new Size(151, 23);
            tbxUsername.TabIndex = 25;
            // 
            // cmbSeqQuestion
            // 
            cmbSeqQuestion.FormattingEnabled = true;
            cmbSeqQuestion.Items.AddRange(new object[] { "En sevdiğiniz renk?", "En sevdiğiniz hayvan?", "En sevdiğiniz içecek?" });
            cmbSeqQuestion.Location = new Point(576, 396);
            cmbSeqQuestion.MaxDropDownItems = 3;
            cmbSeqQuestion.Name = "cmbSeqQuestion";
            cmbSeqQuestion.Size = new Size(151, 23);
            cmbSeqQuestion.TabIndex = 24;
            // 
            // lblSeqQuestion
            // 
            lblSeqQuestion.AutoSize = true;
            lblSeqQuestion.BackColor = Color.Transparent;
            lblSeqQuestion.ForeColor = Color.White;
            lblSeqQuestion.Location = new Point(479, 399);
            lblSeqQuestion.Name = "lblSeqQuestion";
            lblSeqQuestion.Size = new Size(91, 15);
            lblSeqQuestion.TabIndex = 23;
            lblSeqQuestion.Text = "Güvenlik sorusu";
            // 
            // lblPasswordAgain
            // 
            lblPasswordAgain.AutoSize = true;
            lblPasswordAgain.BackColor = Color.Transparent;
            lblPasswordAgain.ForeColor = Color.White;
            lblPasswordAgain.Location = new Point(487, 370);
            lblPasswordAgain.Name = "lblPasswordAgain";
            lblPasswordAgain.Size = new Size(83, 15);
            lblPasswordAgain.TabIndex = 22;
            lblPasswordAgain.Text = "Şifre (yeniden)";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(540, 341);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(30, 15);
            lblPassword.TabIndex = 21;
            lblPassword.Text = "Şifre";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(499, 312);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(71, 15);
            lblUsername.TabIndex = 20;
            lblUsername.Text = "Kullanıcı adı";
            // 
            // lblLoopLearn
            // 
            lblLoopLearn.AccessibleName = "lblLogin";
            lblLoopLearn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblLoopLearn.AutoSize = true;
            lblLoopLearn.BackColor = Color.Transparent;
            lblLoopLearn.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblLoopLearn.ForeColor = Color.White;
            lblLoopLearn.Location = new Point(562, 222);
            lblLoopLearn.Name = "lblLoopLearn";
            lblLoopLearn.Size = new Size(178, 45);
            lblLoopLearn.TabIndex = 19;
            lblLoopLearn.Text = "LoopLearn";
            lblLoopLearn.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RegisterPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.LoginPageBackground;
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
            Name = "RegisterPage";
            Size = new Size(1280, 720);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Label lblAlrHaveAcc;
        private Button btnRegister;
        private TextBox tbxSeqAnswer;
        private Label lblSeqAnswer;
        private TextBox tbxPasswordAgain;
        private TextBox tbxPassword;
        private TextBox tbxUsername;
        private ComboBox cmbSeqQuestion;
        private Label lblSeqQuestion;
        private Label lblPasswordAgain;
        private Label lblPassword;
        private Label lblUsername;
        private Label lblLoopLearn;
    }
}
