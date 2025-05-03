using LoopLearn.Backend.Auth;
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            PageManager.LoadPage(new LoginPage());
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (tbxUsername.Text == "" || tbxPassword.Text == "" || tbxPasswordAgain.Text == "" || tbxSeqAnswer.Text == "")
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tbxUsername.Text.Length < 3)
            {
                MessageBox.Show("Kullanıcı adı çok kısa!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tbxPassword.Text.Length < 4)
            {
                MessageBox.Show("Şifre çok kısa!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tbxPassword.Text != tbxPasswordAgain.Text)
            {
                MessageBox.Show("Şifreler aynı değil!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var auth = new AuthService();
            bool result = auth.Register(tbxUsername.Text, tbxPassword.Text, cmbSeqQuestion.SelectedIndex, tbxSeqAnswer.Text);

            if (result)
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
