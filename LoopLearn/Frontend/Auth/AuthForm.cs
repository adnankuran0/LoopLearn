

namespace LoopLearn.Frontend
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        public void LoadPage(UserControl page)
        {
            panelMain.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panelMain.Controls.Add(page);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadPage(new LoginPage());
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


    }
}
