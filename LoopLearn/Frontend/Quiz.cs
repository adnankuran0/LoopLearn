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
using LoopLearn.Backend.ExamManager;
using LoopLearn.Backend.Quiz;

namespace LoopLearn.Frontend
{
    public partial class Quiz : UserControl
    {
        public bool IsQuizActive;
        private Question CurrentQuestion;
        private Exam exam;
        private void LoadQuestionToInterface(Question question)
        {
            if (question == null) return;

            LoadImageToPictureBox(question.CorrectWord.picturePath);
            string questionText = Database.GetSampleByWordID(question.CorrectWord.wordID);
            lblQuestion.Text = ReplaceWordWithEllipsis(questionText, question.CorrectWord.engWordName);

            CurrentQuestion = question;

            List<string> answers = new List<string>
            {
                question.CorrectWord.engWordName,
                question.WrongWord1.engWordName,
                question.WrongWord2.engWordName,
                question.WrongWord3.engWordName
            };

            Random rnd = new Random();
            answers = answers.OrderBy(x => rnd.Next()).ToList();

            btnA.Text = answers[0];
            btnB.Text = answers[1];
            btnC.Text = answers[2];
            btnD.Text = answers[3];
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

        private void SetQuestionUnvisible()
        {
            btnNextQuestion.Visible = false;
            lblQuestion.Visible = false;
            pctPicture.Visible = false;
            btnA.Visible = false;
            btnB.Visible = false;
            btnC.Visible = false;
            btnD.Visible = false;
        }

        public Quiz()
        {
            InitializeComponent();
            Tag = "Quiz";
            IsQuizActive = false;
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

            IsQuizActive = true;
            btnStartQuiz.Visible = false;
            exam = ExamManager.CreateExam(10);

            SetQuestionVisible();
            LoadNextQuestion();
        }

        private void btnNextQuestion_Click(object sender, EventArgs e)
        {

            
        }

        private void LoadNextQuestion()
        {
            Question? q = exam.GetNextQuestion();
            CurrentQuestion = q;

            if (q != null)
            {
                LoadQuestionToInterface(q);
            }
            else
            {
                SetQuestionUnvisible();
                IsQuizActive = false;
                MessageBox.Show("Tüm soruları tamamladınız!");
            }
        }

        private string ReplaceWordWithEllipsis(string text, string wordToReplace)
        {
            string pattern = Regex.Escape(wordToReplace);
            string modifiedText = Regex.Replace(text, pattern, "...", RegexOptions.IgnoreCase);

            return modifiedText;
        }
        private void btnAnswer_Click(object sender, EventArgs e)
        {
            Button? clickedButton = sender as Button;
            if (clickedButton == null) return;

            if (clickedButton.Text.Equals(CurrentQuestion.CorrectWord.engWordName, StringComparison.OrdinalIgnoreCase))
            {

                Database.UpdateQuestionAfterAnswer(CurrentQuestion.questionID, true);
                MessageBox.Show("Tebrikler! Doğru cevap.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Database.UpdateQuestionAfterAnswer(CurrentQuestion.questionID, false);
                MessageBox.Show("Maalesef yanlış cevap.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadNextQuestion();
        }

        private void pctPicture_Click(object sender, EventArgs e)
        {

        }
    }
}
