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

        public MainForm()
        {
            InitializeComponent();
        }

        private void ResetButtonStyles()
        {
            btnAddWord.BackColor = Color.DarkBlue;
            btnQuiz.BackColor = Color.DarkBlue;
            btnRport.BackColor = Color.DarkBlue;
            btnPuzzle.BackColor = Color.DarkBlue;
            btnMemNail.BackColor = Color.DarkBlue;
            btnSettings.BackColor = Color.DarkBlue;
            btnExit.BackColor = Color.DarkBlue;
            btnAddWord.Font = new Font(btnAddWord.Font, FontStyle.Regular);
            btnQuiz.Font = new Font(btnQuiz.Font, FontStyle.Regular);
            btnRport.Font = new Font(btnRport.Font, FontStyle.Regular);
            btnPuzzle.Font = new Font(btnPuzzle.Font, FontStyle.Regular);
            btnMemNail.Font = new Font(btnMemNail.Font, FontStyle.Regular);
            btnSettings.Font = new Font(btnSettings.Font, FontStyle.Regular);
            btnExit.Font = new Font(btnSettings.Font, FontStyle.Regular);
        }

        private void MakeButtonSelected(Button selectedButton)
        {
            ResetButtonStyles();
            selectedButton.Font = new Font(selectedButton.Font, FontStyle.Bold);
            selectedButton.BackColor = Color.Blue;
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            MakeButtonSelected(btnAddWord);
        }

        private void btnQuiz_Click(object sender, EventArgs e)
        {
            MakeButtonSelected(btnQuiz);
        }

        private void btnRport_Click(object sender, EventArgs e)
        {
            MakeButtonSelected(btnRport);
        }

        private void btnPuzzle_Click(object sender, EventArgs e)
        {
            MakeButtonSelected(btnPuzzle);
        }

        private void btnMemNail_Click(object sender, EventArgs e)
        {
            MakeButtonSelected(btnMemNail);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            MakeButtonSelected(btnSettings);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
