namespace LoopLearn.Frontend
{
    partial class LoginPage
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
            label1 = new Label();
            btnForgotPassword = new Button();
            lblLogin = new Label();
            btnLogin = new Button();
            btnRegister = new Button();
            tbxPassword = new TextBox();
            tbxUsername = new TextBox();
            lblPassword = new Label();
            lblUsername = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
            label1.Location = new Point(563, 456);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 17;
            label1.Text = "Hesabın yok mu?";
            // 
            // btnForgotPassword
            // 
            btnForgotPassword.AccessibleName = "btnForgotPassword";
            btnForgotPassword.BackColor = Color.Silver;
            btnForgotPassword.BackgroundImageLayout = ImageLayout.None;
            btnForgotPassword.FlatAppearance.BorderSize = 0;
            btnForgotPassword.FlatStyle = FlatStyle.Flat;
            btnForgotPassword.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            btnForgotPassword.Location = new Point(563, 423);
            btnForgotPassword.Name = "btnForgotPassword";
            btnForgotPassword.Size = new Size(160, 23);
            btnForgotPassword.TabIndex = 16;
            btnForgotPassword.Text = "Şifremi unuttum";
            btnForgotPassword.UseVisualStyleBackColor = false;
            btnForgotPassword.Click += btnForgotPassword_Click;
            // 
            // lblLogin
            // 
            lblLogin.AccessibleName = "lblLogin";
            lblLogin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblLogin.AutoSize = true;
            lblLogin.BackColor = Color.Transparent;
            lblLogin.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblLogin.ForeColor = Color.White;
            lblLogin.Location = new Point(553, 222);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(178, 45);
            lblLogin.TabIndex = 13;
            lblLogin.Text = "LoopLearn";
            lblLogin.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnLogin
            // 
            btnLogin.AccessibleName = "btnLogin";
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Location = new Point(563, 394);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(160, 23);
            btnLogin.TabIndex = 12;
            btnLogin.Text = "Giriş";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.AccessibleName = "btnRegister";
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.Location = new Point(667, 452);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(56, 23);
            btnRegister.TabIndex = 11;
            btnRegister.Text = "Üye ol";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // tbxPassword
            // 
            tbxPassword.AccessibleName = "tbxPassword";
            tbxPassword.Location = new Point(563, 337);
            tbxPassword.MaxLength = 10;
            tbxPassword.Name = "tbxPassword";
            tbxPassword.Size = new Size(160, 23);
            tbxPassword.TabIndex = 10;
            tbxPassword.UseSystemPasswordChar = true;
            // 
            // tbxUsername
            // 
            tbxUsername.AccessibleName = "tbxUsername";
            tbxUsername.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbxUsername.Location = new Point(563, 308);
            tbxUsername.MaxLength = 12;
            tbxUsername.Name = "tbxUsername";
            tbxUsername.Size = new Size(160, 23);
            tbxUsername.TabIndex = 9;
            // 
            // lblPassword
            // 
            lblPassword.AccessibleName = "lblPassword";
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI", 9F);
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(524, 340);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(33, 15);
            lblPassword.TabIndex = 15;
            lblPassword.Text = "Şifre:";
            lblPassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsername
            // 
            lblUsername.AccessibleName = "lblUsername";
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Font = new Font("Segoe UI", 9F);
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(483, 311);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(74, 15);
            lblUsername.TabIndex = 14;
            lblUsername.Text = "Kullanıcı adı:";
            lblUsername.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.LoginPageBackground;
            Controls.Add(label1);
            Controls.Add(btnForgotPassword);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(lblLogin);
            Controls.Add(btnLogin);
            Controls.Add(btnRegister);
            Controls.Add(tbxPassword);
            Controls.Add(tbxUsername);
            Name = "LoginPage";
            Size = new Size(1280, 720);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnForgotPassword;
        private Label lblLogin;
        private Button btnLogin;
        private Button btnRegister;
        private TextBox tbxPassword;
        private TextBox tbxUsername;
        private Label lblPassword;
        private Label lblUsername;
    }
}
