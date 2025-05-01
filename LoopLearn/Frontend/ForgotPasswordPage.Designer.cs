namespace LoopLearn.Frontend
{
    partial class ForgotPasswordPage
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
            btnChangePassword = new Button();
            tbxSeqAnswer = new TextBox();
            lblSeqAnswer = new Label();
            tbxNewPasswordAgain = new TextBox();
            tbxNewPassword = new TextBox();
            tbxUsername = new TextBox();
            cmbSeqQuestion = new ComboBox();
            lblSeqQuestion = new Label();
            lblNewPasswordAgain = new Label();
            lblNewPassword = new Label();
            lblUsername = new Label();
            lblLoopLearn = new Label();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(685, 507);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(54, 23);
            btnLogin.TabIndex = 46;
            btnLogin.Text = "Giriş yap";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblAlrHaveAcc
            // 
            lblAlrHaveAcc.AutoSize = true;
            lblAlrHaveAcc.BackColor = Color.Transparent;
            lblAlrHaveAcc.ForeColor = Color.White;
            lblAlrHaveAcc.Location = new Point(588, 511);
            lblAlrHaveAcc.Name = "lblAlrHaveAcc";
            lblAlrHaveAcc.Size = new Size(91, 15);
            lblAlrHaveAcc.TabIndex = 45;
            lblAlrHaveAcc.Text = "Hesabın var mı?";
            // 
            // btnChangePassword
            // 
            btnChangePassword.Location = new Point(588, 478);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(151, 23);
            btnChangePassword.TabIndex = 44;
            btnChangePassword.Text = "Şifremi değiştir";
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // tbxSeqAnswer
            // 
            tbxSeqAnswer.Location = new Point(588, 371);
            tbxSeqAnswer.MaxLength = 15;
            tbxSeqAnswer.Name = "tbxSeqAnswer";
            tbxSeqAnswer.Size = new Size(151, 23);
            tbxSeqAnswer.TabIndex = 43;
            // 
            // lblSeqAnswer
            // 
            lblSeqAnswer.AutoSize = true;
            lblSeqAnswer.BackColor = Color.Transparent;
            lblSeqAnswer.ForeColor = Color.White;
            lblSeqAnswer.Location = new Point(542, 374);
            lblSeqAnswer.Name = "lblSeqAnswer";
            lblSeqAnswer.Size = new Size(40, 15);
            lblSeqAnswer.TabIndex = 42;
            lblSeqAnswer.Text = "Cevap";
            // 
            // tbxNewPasswordAgain
            // 
            tbxNewPasswordAgain.Location = new Point(588, 429);
            tbxNewPasswordAgain.MaxLength = 10;
            tbxNewPasswordAgain.Name = "tbxNewPasswordAgain";
            tbxNewPasswordAgain.Size = new Size(151, 23);
            tbxNewPasswordAgain.TabIndex = 41;
            // 
            // tbxNewPassword
            // 
            tbxNewPassword.Location = new Point(588, 400);
            tbxNewPassword.MaxLength = 10;
            tbxNewPassword.Name = "tbxNewPassword";
            tbxNewPassword.Size = new Size(151, 23);
            tbxNewPassword.TabIndex = 40;
            // 
            // tbxUsername
            // 
            tbxUsername.Location = new Point(588, 313);
            tbxUsername.MaxLength = 12;
            tbxUsername.Name = "tbxUsername";
            tbxUsername.Size = new Size(151, 23);
            tbxUsername.TabIndex = 39;
            // 
            // cmbSeqQuestion
            // 
            cmbSeqQuestion.FormattingEnabled = true;
            cmbSeqQuestion.Items.AddRange(new object[] { "En sevdiğiniz renk?", "En sevdiğiniz hayvan?", "En sevdiğiniz içecek?" });
            cmbSeqQuestion.Location = new Point(588, 342);
            cmbSeqQuestion.MaxDropDownItems = 3;
            cmbSeqQuestion.Name = "cmbSeqQuestion";
            cmbSeqQuestion.Size = new Size(151, 23);
            cmbSeqQuestion.TabIndex = 38;
            // 
            // lblSeqQuestion
            // 
            lblSeqQuestion.AutoSize = true;
            lblSeqQuestion.BackColor = Color.Transparent;
            lblSeqQuestion.ForeColor = Color.White;
            lblSeqQuestion.Location = new Point(491, 345);
            lblSeqQuestion.Name = "lblSeqQuestion";
            lblSeqQuestion.Size = new Size(91, 15);
            lblSeqQuestion.TabIndex = 37;
            lblSeqQuestion.Text = "Güvenlik sorusu";
            // 
            // lblNewPasswordAgain
            // 
            lblNewPasswordAgain.AutoSize = true;
            lblNewPasswordAgain.BackColor = Color.Transparent;
            lblNewPasswordAgain.ForeColor = Color.White;
            lblNewPasswordAgain.Location = new Point(486, 432);
            lblNewPasswordAgain.Name = "lblNewPasswordAgain";
            lblNewPasswordAgain.Size = new Size(96, 15);
            lblNewPasswordAgain.TabIndex = 36;
            lblNewPasswordAgain.Text = "Yeni Şifre (tekrar)";
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.BackColor = Color.Transparent;
            lblNewPassword.ForeColor = Color.White;
            lblNewPassword.Location = new Point(527, 403);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(55, 15);
            lblNewPassword.TabIndex = 35;
            lblNewPassword.Text = "Yeni Şifre";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(511, 316);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(71, 15);
            lblUsername.TabIndex = 34;
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
            lblLoopLearn.Location = new Point(574, 226);
            lblLoopLearn.Name = "lblLoopLearn";
            lblLoopLearn.Size = new Size(178, 45);
            lblLoopLearn.TabIndex = 33;
            lblLoopLearn.Text = "LoopLearn";
            lblLoopLearn.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ForgotPasswordPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.LoginPageBackground;
            Controls.Add(btnLogin);
            Controls.Add(lblAlrHaveAcc);
            Controls.Add(btnChangePassword);
            Controls.Add(tbxSeqAnswer);
            Controls.Add(lblSeqAnswer);
            Controls.Add(tbxNewPasswordAgain);
            Controls.Add(tbxNewPassword);
            Controls.Add(tbxUsername);
            Controls.Add(cmbSeqQuestion);
            Controls.Add(lblSeqQuestion);
            Controls.Add(lblNewPasswordAgain);
            Controls.Add(lblNewPassword);
            Controls.Add(lblUsername);
            Controls.Add(lblLoopLearn);
            Name = "ForgotPasswordPage";
            Size = new Size(1280, 720);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Label lblAlrHaveAcc;
        private Button btnChangePassword;
        private TextBox tbxSeqAnswer;
        private Label lblSeqAnswer;
        private TextBox tbxNewPasswordAgain;
        private TextBox tbxNewPassword;
        private TextBox tbxUsername;
        private ComboBox cmbSeqQuestion;
        private Label lblSeqQuestion;
        private Label lblNewPasswordAgain;
        private Label lblNewPassword;
        private Label lblUsername;
        private Label lblLoopLearn;
    }
}
