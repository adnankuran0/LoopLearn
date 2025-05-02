using LoopLearn.Backend.Auth;
using LoopLearn.Backend.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoopLearn.Frontend
{
    public partial class LoginPage : UserControl
    {

        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbxUsername.Text == "" || tbxPassword.Text == "")
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var auth = new AuthService();
            bool result = auth.Login(tbxUsername.Text, tbxPassword.Text);

            if (result)
            {
                MessageBox.Show("Giriş başarılı!");
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            PageManager.LoadPage(new RegisterPage());
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            PageManager.LoadPage(new ForgotPasswordPage());
        }
    }
}
