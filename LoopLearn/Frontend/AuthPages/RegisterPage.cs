using LoopLearn.Backend.Utils;

namespace LoopLearn.Frontend
{
    public partial class RegisterPage : UserControl
    {
        public RegisterPage()
        {
            InitializeComponent();
            cmbSeqQuestion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSeqQuestion.SelectedIndex = 0;
        }
        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            PageManager.LoadPage(new LoginPage());
        }
        private bool AreInputsValid()
        {
            if (string.IsNullOrWhiteSpace(tbxUsername.Text) ||
                string.IsNullOrWhiteSpace(tbxPassword.Text) ||
                string.IsNullOrWhiteSpace(tbxPasswordAgain.Text) ||
                string.IsNullOrWhiteSpace(tbxSeqAnswer.Text))
            {
                ShowWarning("Lütfen boş alan bırakmayınız!");
                return false;
            }

            if (tbxUsername.Text.Length < 3)
            {
                ShowWarning("Kullanıcı adı çok kısa!");
                return false;
            }

            if (tbxPassword.Text.Length < 4)
            {
                ShowWarning("Şifre çok kısa!");
                return false;
            }

            if (tbxPassword.Text != tbxPasswordAgain.Text)
            {
                ShowWarning("Şifreler aynı değil!");
                return false;
            }

            return true;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!AreInputsValid()) return;

            bool registerResult = AuthManager.Instance.Register(
                tbxUsername.Text, 
                tbxPassword.Text, 
                cmbSeqQuestion.SelectedIndex, 
                tbxSeqAnswer.Text);

            if (registerResult)
            {
                MessageBox.Show("Kayıt başarılı!");
            }
            else
            {
                MessageBox.Show("Bu kullanıcı adı zaten kullanılıyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
