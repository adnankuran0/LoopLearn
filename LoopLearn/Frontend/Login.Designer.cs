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
            SuspendLayout();
            // 
            // tbxUsername
            // 
            tbxUsername.AccessibleName = "tbxUsername";
            tbxUsername.Location = new Point(512, 270);
            tbxUsername.MaxLength = 10;
            tbxUsername.Name = "tbxUsername";
            tbxUsername.Size = new Size(156, 23);
            tbxUsername.TabIndex = 0;
            tbxUsername.TextChanged += tbxUsername_TextChanged;
            // 
            // tbxPassword
            // 
            tbxPassword.AccessibleName = "tbxPassword";
            tbxPassword.Location = new Point(510, 308);
            tbxPassword.MaxLength = 10;
            tbxPassword.Name = "tbxPassword";
            tbxPassword.Size = new Size(156, 23);
            tbxPassword.TabIndex = 1;
            tbxPassword.UseSystemPasswordChar = true;
            // 
            // btnRegister
            // 
            btnRegister.AccessibleName = "btnRegister";
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.Location = new Point(593, 350);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(75, 23);
            btnRegister.TabIndex = 2;
            btnRegister.Text = "Üye ol";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnLogin
            // 
            btnLogin.AccessibleName = "btnLogin";
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Location = new Point(512, 350);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Giriş";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblLogin
            // 
            lblLogin.AccessibleName = "lblLogin";
            lblLogin.AutoSize = true;
            lblLogin.BackColor = Color.Transparent;
            lblLogin.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblLogin.ForeColor = Color.White;
            lblLogin.Location = new Point(500, 208);
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
            lblUsername.Location = new Point(432, 278);
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
            lblPassword.Location = new Point(471, 316);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(33, 15);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Şifre:";
            lblPassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnForgotPassword
            // 
            btnForgotPassword.AccessibleName = "btnForgotPassword";
            btnForgotPassword.BackColor = Color.Transparent;
            btnForgotPassword.Cursor = Cursors.Hand;
            btnForgotPassword.FlatAppearance.BorderSize = 0;
            btnForgotPassword.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            btnForgotPassword.Location = new Point(512, 379);
            btnForgotPassword.Name = "btnForgotPassword";
            btnForgotPassword.Size = new Size(154, 23);
            btnForgotPassword.TabIndex = 7;
            btnForgotPassword.Text = "Şifremi unuttum";
            btnForgotPassword.UseVisualStyleBackColor = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BackgroundImage = Properties.Resources.LoginPageBackground;
            ClientSize = new Size(1264, 681);
            Controls.Add(btnForgotPassword);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(lblLogin);
            Controls.Add(btnLogin);
            Controls.Add(btnRegister);
            Controls.Add(tbxPassword);
            Controls.Add(tbxUsername);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Login";
            Text = "LoopLearn";
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
    }
}