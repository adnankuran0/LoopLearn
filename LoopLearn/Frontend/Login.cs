using LoopLearn.Backend.Auth;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var auth = new AuthService();
            bool result = auth.Login(tbxUsername.Text, tbxPassword.Text);

            if (result)
            {
                MessageBox.Show("Giriş başarılı!");
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var auth = new AuthService();
            bool result = auth.Register(tbxUsername.Text,tbxPassword.Text);

            if (result)
            {
                MessageBox.Show("Kayıt başarılı!");
            }
            else
            {
                MessageBox.Show("Bu kullanıcı adı zaten kullanılıyor.");
            }
        }
    }
}
