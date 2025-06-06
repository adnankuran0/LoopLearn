﻿using LoopLearn.Backend.Utils;

namespace LoopLearn.Frontend
{
    public partial class ForgotPasswordPage : UserControl
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();
            cmbSeqQuestion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSeqQuestion.SelectedIndex = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            PageManager.LoadPage(new LoginPage());
        }

        private bool AreInputsValid()
        {
            if (string.IsNullOrWhiteSpace(tbxUsername.Text) ||
                string.IsNullOrWhiteSpace(tbxNewPassword.Text) ||
                string.IsNullOrWhiteSpace(tbxSeqAnswer.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if(!AreInputsValid()) return;

            if (AuthManager.Instance.UpdatePassword(
                tbxUsername.Text,
                tbxNewPassword.Text,
                cmbSeqQuestion.SelectedIndex,
                tbxSeqAnswer.Text))
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
