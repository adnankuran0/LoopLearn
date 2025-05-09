using System.Data;
using System.Text.RegularExpressions;
using LoopLearn.Backend.Database;
using LoopLearn.Backend.ExamManager;
using LoopLearn.Backend.Quiz;

namespace LoopLearn.Frontend
{
    public partial class Quiz : UserControl
    {
        private bool isQuizActive;
        private Question currentQuestion;
        private Exam exam;
        private readonly Random random = new Random();

        public Quiz()
        {
            InitializeComponent();
            Tag = "Quiz";
            isQuizActive = false;
            btnStartQuiz.Visible = true;
        }

        private void btnStartQuiz_Click(object sender, EventArgs e)
        {
            if (!ConfirmQuizStart()) return;

            isQuizActive = true;
            btnStartQuiz.Visible = false;
            exam = ExamManager.CreateExam(10);
            ShowQuestionUI();
            LoadNextQuestion();
        }

        private bool ConfirmQuizStart()
        {
            var result = MessageBox.Show(
                "Sınavı başlatmak istediğinizden emin misiniz?",
                "Sınavı başlat",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            if (!(sender is Button clickedButton)) return;

            bool isCorrect = clickedButton.Text.Equals(
                currentQuestion.CorrectWord.engWordName,
                StringComparison.OrdinalIgnoreCase);

            DatabaseManager.UpdateQuestionAfterAnswer(currentQuestion.questionID, isCorrect);
            ShowAnswerFeedback(isCorrect);

            LoadNextQuestion();
        }

        private void ShowAnswerFeedback(bool isCorrect)
        {
            string message = isCorrect ? "Tebrikler! Doğru cevap." : "Maalesef yanlış cevap.";
            MessageBoxIcon icon = isCorrect ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show(message, "Bilgi", MessageBoxButtons.OK, icon);
        }

        private void LoadNextQuestion()
        {
            currentQuestion = exam.GetNextQuestion();

            if (currentQuestion != null)
            {
                DisplayQuestion(currentQuestion);
            }
            else
            {
                EndQuiz();
            }
        }

        private void DisplayQuestion(Question question)
        {
            LoadQuestionImage(question.CorrectWord.picturePath);
            string questionText = DatabaseManager.GetSampleByWordID(question.CorrectWord.wordID);
            lblQuestion.Text = ReplaceWordWithEllipsis(questionText, question.CorrectWord.engWordName);

            List<string> answers = GetShuffledAnswers(question);
            ConfigureAnswerButtons(answers);
        }

        private List<string> GetShuffledAnswers(Question question)
        {
            var answers = new List<string>
            {
                question.CorrectWord.engWordName,
                question.WrongWord1.engWordName,
                question.WrongWord2.engWordName,
                question.WrongWord3.engWordName
            };
            return answers.OrderBy(_ => random.Next()).ToList();
        }

        private void ConfigureAnswerButtons(List<string> answers)
        {
            btnA.Text = answers[0];
            btnB.Text = answers[1];
            btnC.Text = answers[2];
            btnD.Text = answers[3];
        }

        private void LoadQuestionImage(string relativePath)
        {
            try
            {
                string fullImagePath = GetFullImagePath(relativePath);
                if (File.Exists(fullImagePath))
                {
                    pctPicture.Image?.Dispose(); // Dispose previous image to prevent memory leaks
                    pctPicture.Image = Image.FromFile(fullImagePath);
                }
                else
                {
                    ShowError("Görsel bulunamadı!");
                }
            }
            catch (Exception ex)
            {
                ShowError($"Görsel yüklenirken hata oluştu: {ex.Message}");
            }
        }

        private string GetFullImagePath(string relativePath)
        {
            string solutionFolder = Directory.GetParent(Application.StartupPath)?.Parent?.Parent?.Parent?.FullName;
            return Path.Combine(solutionFolder ?? string.Empty, relativePath);
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowQuestionUI()
        {
            SetControlsVisibility(true);
        }

        private void HideQuestionUI()
        {
            SetControlsVisibility(false);
        }

        private void SetControlsVisibility(bool isVisible)
        {
            lblQuestion.Visible = isVisible;
            pctPicture.Visible = isVisible;
            btnA.Visible = isVisible;
            btnB.Visible = isVisible;
            btnC.Visible = isVisible;
            btnD.Visible = isVisible;
        }

        private void EndQuiz()
        {
            HideQuestionUI();
            isQuizActive = false;
            MessageBox.Show("Tüm soruları tamamladınız!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string ReplaceWordWithEllipsis(string text, string wordToReplace)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(wordToReplace))
                return text;

            string pattern = Regex.Escape(wordToReplace);
            return Regex.Replace(text, pattern, "...", RegexOptions.IgnoreCase);
        }

    }
}
