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
    public partial class ForgotPasswordPage : UserControl
    {
        private MainForm _mainForm;
        public ForgotPasswordPage(MainForm mainForm)
        {
            InitializeComponent();
            cmbSeqQuestion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSeqQuestion.SelectedIndex = 0;
            _mainForm = mainForm;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _mainForm.LoadPage(new LoginPage(_mainForm));
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            AuthService auth = new AuthService();
            if (auth.UpdatePassword(tbxUsername.Text, tbxNewPassword.Text, cmbSeqQuestion.SelectedIndex, tbxSeqAnswer.Text))
            {
                MessageBox.Show("Şifreniz başarıyla değiştirildi.", "Şifre değişikliği", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Girilen bilgilere ait kullanıcı bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
