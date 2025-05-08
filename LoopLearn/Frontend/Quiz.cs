using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoopLearn.Backend.Database;
using LoopLearn.Backend.Quiz;

namespace LoopLearn.Frontend
{
    public partial class Quiz : UserControl
    {
        public bool IsQuizStarted;

        private void LoadQuestionToInterface(Question question)
        {
            if (question == null) return;
            LoadImageToPictureBox(question.CorrectWord.picturePath);
            string questionText = Database.GetSampleByWordID(question.CorrectWord.wordID);
            lblQuestion.Text = ReplaceWordWithEllipsis(questionText, question.CorrectWord.engWordName);
            btnA.Text = question.CorrectWord.engWordName;
            btnB.Text = question.WrongWord1.engWordName;
            btnC.Text = question.WrongWord2.engWordName;
            btnD.Text = question.WrongWord3.engWordName;
        }

        private void LoadImageToPictureBox(string relativePath)
        {
            string solutionFolder = Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName;

            string fullImagePath = Path.Combine(solutionFolder, relativePath);

            if (File.Exists(fullImagePath))
            {
                pctPicture.Image = Image.FromFile(fullImagePath);
            }
            else
            {
                MessageBox.Show("Görsel bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetQuestionVisible()
        {
            btnNextQuestion.Visible = true;
            lblQuestion.Visible = true;
            pctPicture.Visible = true;
            btnA.Visible = true;
            btnB.Visible = true;
            btnC.Visible = true;
            btnD.Visible = true;
        }

        public Quiz()
        {
            InitializeComponent();
            Tag = "Puzzle";
            IsQuizStarted = false;
            btnStartQuiz.Visible = true;
        }

        private void btnStartQuiz_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
            "Sınavı başlatmak istediğinizden emin misiniz?",
            "Sınavı başlat",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
            );
            if (result == DialogResult.No) return;

            IsQuizStarted = true;
            btnStartQuiz.Visible = false;
            SetQuestionVisible();
        }

        private void btnNextQuestion_Click(object sender, EventArgs e)
        {
            Question? q = Database.GetQuestionByID(2);
            LoadQuestionToInterface(q);
        }

        private string ReplaceWordWithEllipsis(string text, string wordToReplace)
        {
            string pattern = @"\b" + Regex.Escape(wordToReplace) + @"\b";  

            string modifiedText = Regex.Replace(text, pattern, "...", RegexOptions.IgnoreCase);

            return modifiedText;
        }
    }
}
