using LoopLearn.Frontend;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace LoopLearn.Backend.Utils
{
    public static class PageManager
    {
        private static AuthForm? m_ActiveForm;

        public static void Initalize(AuthForm loginForm)
        {
            m_ActiveForm = loginForm;
        }

        public static void LoadPage(UserControl page)
        {
            if (m_ActiveForm == null) return;

            m_ActiveForm.panelMain.Controls.Clear();
            page.Dock = DockStyle.Fill;
            m_ActiveForm.panelMain.Controls.Add(page);
        }

        public static void LoadForm(Form form)
        {
            if (m_ActiveForm == null) return;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            m_ActiveForm.panelMain.Controls.Clear();
            m_ActiveForm.panelMain.Controls.Add(form);
            m_ActiveForm.panelMain.Tag = form;
            form.BringToFront();
            form.Show();
        }

    }
}
