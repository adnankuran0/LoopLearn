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
    public partial class MainForm : Form
    {
        private UserControl activeContent;
        private readonly float originalFontSize;

        public MainForm()
        {
            InitializeComponent();
            originalFontSize = btnAddWord.Font.Size;
        }

        private void ChangeContent(UserControl newContent)
        {
            if (activeContent != null)
            {
                if (activeContent == newContent) return;

                pnlContent.Controls.Remove(activeContent);
                activeContent.Dispose();
            }

            activeContent = newContent;
            newContent.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(newContent);
        }

        private void ResetButtonStyles()
        {
            ResetButton(btnAddWord);
            ResetButton(btnQuiz);
            ResetButton(btnRport);
            ResetButton(btnPuzzle);
            ResetButton(btnMemNail);
            ResetButton(btnSettings);
            ResetButton(btnExit);
        }

        private void ResetButton(Button btn)
        {
            btn.BackColor = Color.Navy;
            btn.Font = new Font(btn.Font.FontFamily, originalFontSize, FontStyle.Regular);
        }

        private void MakeButtonSelected(Button selectedButton)
        {
            ResetButtonStyles();

            float newSize = selectedButton.Font.Size + 2;
            selectedButton.Font = new Font(selectedButton.Font.FontFamily, newSize, FontStyle.Bold);
            selectedButton.BackColor = Color.MediumBlue;
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            MakeButtonSelected(btnAddWord);
            ChangeContent(new AddWord());
        }

        private void btnQuiz_Click(object sender, EventArgs e)
        {
            MakeButtonSelected(btnQuiz);
            ChangeContent(new Quiz());
        }

        private void btnRport_Click(object sender, EventArgs e)
        {
            MakeButtonSelected(btnRport);
            ChangeContent(new Report());

        }

        private void btnPuzzle_Click(object sender, EventArgs e)
        {
            MakeButtonSelected(btnPuzzle);
            ChangeContent(new Puzzle());

        }

        private void btnMemNail_Click(object sender, EventArgs e)
        {
            MakeButtonSelected(btnMemNail);
            ChangeContent(new MemoryNail());

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            MakeButtonSelected(btnSettings);
            ChangeContent(new Settings());

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ChangeContent(new Home());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
            "Çıkmak istediğinizden emin misiniz?",
            "Uygulamadan Çık",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ChangeContent(new Home());
        }
    }
}
