using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoopLearn.Frontend
{
    public partial class MainForm : Form
    {
        private UserControl activeContent;
        private readonly float originalFontSize;

        public MainForm()
        {
            InitializeComponent();
            originalFontSize = btnAddWord.Font.Size;
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            btnAddWord.Click += (_, _) => NavigateTo(btnAddWord, new AddWordPage());
            btnQuiz.Click += (_, _) => NavigateTo(btnQuiz, new QuizPage());
            btnRport.Click += (_, _) => NavigateTo(btnRport, new Report());
            btnPuzzle.Click += (_, _) => NavigateTo(btnPuzzle, new PuzzlePage());
            btnMemNail.Click += (_, _) => NavigateTo(btnMemNail, new MemoryNailPage());
            btnSettings.Click += (_, _) => NavigateTo(btnSettings, new SettingsPage());
            btnExit.Click += (_, _) => ConfirmAndExit();
            lblHome.Click += (_, _) => ChangeContent(new HomePage());
        }

        private void NavigateTo(Button button, UserControl content)
        {
            HighlightSelectedButton(button);
            ChangeContent(content);
        }

        private void ChangeContent(UserControl newContent)
        {
            if (IsSameContent(newContent))
                return;

            if (activeContent != null)
            {
                pnlContent.Controls.Remove(activeContent);
                activeContent.Dispose();
            }

            activeContent = newContent;
            newContent.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(newContent);
        }

        private bool IsSameContent(UserControl newContent)
        {
            return activeContent?.Tag != null &&
                   newContent?.Tag != null &&
                   activeContent.Tag.Equals(newContent.Tag);
        }

        private void HighlightSelectedButton(Button selectedButton)
        {
            ResetAllButtons();

            selectedButton.Font = new Font(selectedButton.Font.FontFamily, originalFontSize + 2, FontStyle.Bold);
            selectedButton.BackColor = Color.MediumBlue;
        }

        private void ResetAllButtons()
        {
            Button[] buttons = {
                btnAddWord, btnQuiz, btnRport,
                btnPuzzle, btnMemNail, btnSettings, btnExit
            };

            foreach (var btn in buttons)
            {
                btn.BackColor = Color.Navy;
                btn.Font = new Font(btn.Font.FontFamily, originalFontSize, FontStyle.Regular);
            }
        }

        private void ConfirmAndExit()
        {
            var result = MessageBox.Show(
                "Çıkmak istediğinizden emin misiniz?",
                "Uygulamadan Çık",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ChangeContent(new HomePage());
        }
    }
}
