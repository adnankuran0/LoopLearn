using LoopLearn.Frontend;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace LoopLearn.Backend.Utils
{
    public static class PageManager
    {
        private static AuthForm? entryForm;

        public static void Initalize(AuthForm EntryForm)
        {
            entryForm = EntryForm;
        }

        public static void LoadPage(UserControl page)
        {
            if (entryForm == null) return;

            entryForm.panelMain.Controls.Clear();
            page.Dock = DockStyle.Fill;
            entryForm.panelMain.Controls.Add(page);
        }

        public static void LoadForm(Form form)
        {
            if (entryForm == null) return;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            entryForm.panelMain.Controls.Clear();
            entryForm.panelMain.Controls.Add(form);
            entryForm.panelMain.Tag = form;
            form.BringToFront();
            form.Show();
        }

    }
}
