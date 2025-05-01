namespace LoopLearn.Frontend
{
    partial class Login
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
            tbxUsername = new TextBox();
            tbxPassword = new TextBox();
            btnRegister = new Button();
            btnLogin = new Button();
            lblLogin = new Label();
            lblUsername = new Label();
            lblPassword = new Label();
            btnForgotPassword = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // tbxUsername
            // 
            tbxUsername.AccessibleName = "tbxUsername";
            tbxUsername.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbxUsername.Location = new Point(572, 287);
            tbxUsername.MaxLength = 12;
            tbxUsername.Name = "tbxUsername";
            tbxUsername.Size = new Size(158, 23);
            tbxUsername.TabIndex = 0;
            tbxUsername.TextChanged += tbxUsername_TextChanged;
            // 
            // tbxPassword
            // 
            tbxPassword.AccessibleName = "tbxPassword";
            tbxPassword.Location = new Point(572, 316);
            tbxPassword.MaxLength = 10;
            tbxPassword.Name = "tbxPassword";
            tbxPassword.Size = new Size(158, 23);
            tbxPassword.TabIndex = 1;
            tbxPassword.UseSystemPasswordChar = true;
            // 
            // btnRegister
            // 
            btnRegister.AccessibleName = "btnRegister";
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.Location = new Point(676, 431);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(54, 23);
            btnRegister.TabIndex = 2;
            btnRegister.Text = "Üye ol";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnLogin
            // 
            btnLogin.AccessibleName = "btnLogin";
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Location = new Point(572, 373);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(160, 23);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Giriş";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblLogin
            // 
            lblLogin.AccessibleName = "lblLogin";
            lblLogin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblLogin.AutoSize = true;
            lblLogin.BackColor = Color.Transparent;
            lblLogin.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblLogin.ForeColor = Color.White;
            lblLogin.Location = new Point(562, 201);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(178, 45);
            lblLogin.TabIndex = 4;
            lblLogin.Text = "LoopLearn";
            lblLogin.TextAlign = ContentAlignment.MiddleCenter;
            lblLogin.Click += label1_Click;
            // 
            // lblUsername
            // 
            lblUsername.AccessibleName = "lblUsername";
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Font = new Font("Segoe UI", 9F);
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(492, 290);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(74, 15);
            lblUsername.TabIndex = 5;
            lblUsername.Text = "Kullanıcı adı:";
            lblUsername.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPassword
            // 
            lblPassword.AccessibleName = "lblPassword";
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI", 9F);
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(533, 319);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(33, 15);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Şifre:";
            lblPassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnForgotPassword
            // 
            btnForgotPassword.AccessibleName = "btnForgotPassword";
            btnForgotPassword.BackColor = Color.Silver;
            btnForgotPassword.BackgroundImageLayout = ImageLayout.None;
            btnForgotPassword.FlatAppearance.BorderSize = 0;
            btnForgotPassword.FlatStyle = FlatStyle.Flat;
            btnForgotPassword.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            btnForgotPassword.Location = new Point(572, 402);
            btnForgotPassword.Name = "btnForgotPassword";
            btnForgotPassword.Size = new Size(160, 23);
            btnForgotPassword.TabIndex = 7;
            btnForgotPassword.Text = "Şifremi unuttum";
            btnForgotPassword.UseVisualStyleBackColor = false;
            btnForgotPassword.Click += btnForgotPassword_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
            label1.Location = new Point(572, 435);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 8;
            label1.Text = "Hesabın yok mu?";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BackgroundImage = Properties.Resources.LoginPageBackground;
            ClientSize = new Size(1264, 681);
            Controls.Add(label1);
            Controls.Add(btnForgotPassword);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(lblLogin);
            Controls.Add(btnLogin);
            Controls.Add(btnRegister);
            Controls.Add(tbxPassword);
            Controls.Add(tbxUsername);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MinimizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoopLearn";
            TopMost = true;
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbxUsername;
        private TextBox tbxPassword;
        private Button btnRegister;
        private Button btnLogin;
        private Label lblLogin;
        private Label lblUsername;
        private Label lblPassword;
        private Button btnForgotPassword;
        private Label label1;
    }
}