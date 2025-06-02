using LoopLearn.Backend.Auth;
using LoopLearn.Backend.Database;
using LoopLearn.Backend.Quiz;
using LoopLearn.Backend.Utils;

namespace LoopLearn.Frontend
{
    public partial class LoginPage : UserControl
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private bool AreInputsValid()
        {
            if (string.IsNullOrWhiteSpace(tbxUsername.Text) || string.IsNullOrWhiteSpace(tbxPassword.Text))
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void OnLoginSuccess()
        {
            UserSession.Instance.SetUserData(tbxUsername.Text);
            AuthManager.Instance.Kill(); // Artık gerek kalmadı
            PageManager.LoadForm(new MainForm()); // Ana forma geçiş

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!AreInputsValid()) return;

            bool loginResult = AuthManager.Instance.Login(tbxUsername.Text, tbxPassword.Text);

            if (loginResult)
            {
                OnLoginSuccess();
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
