using LoopLearn.Backend.Database;
using LoopLearn.Backend.Quiz;

namespace LoopLearn.Frontend
{
    public partial class QuizPage : UserControl
    {
        private Exam exam;
        bool isQuizActive;

        public QuizPage()
        {
            InitializeComponent();
            Tag = "Quiz";
            isQuizActive = false;
            btnStartQuiz.Visible = true;
        }

        private void StartQuiz(int dailyNewCount)
        {
            if (!ConfirmQuizStart()) return;

            isQuizActive = true;
            btnStartQuiz.Visible = false;
            exam = new Exam(dailyNewCount);
            ShowQuestionUI();
            LoadNextQuestion();
        }

        private void btnStartQuiz_Click(object sender, EventArgs e)
        {
            StartQuiz(Properties.Settings.Default.DailyNewWordCount);
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

            bool isAnswerCorrect = exam.currentQuestion.SubmitAnswer(clickedButton.Text);
            ShowAnswerFeedback(isAnswerCorrect);

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
            exam.currentQuestion = exam.GetNextQuestion();

            if (exam.currentQuestion != null)
            {
                DisplayQuestion(exam.currentQuestion);
            }
            else
            {
                EndQuiz();
            }
        }

        private void DisplayQuestion(Question question)
        {
            LoadQuestionImage(question.correctWord.picturePath);
            string questionText = DatabaseService.Instance.questionRepository.GetSampleByWordID(question.correctWord.wordID);
            lblQuestion.Text = exam.currentQuestion.sampleSentence;

            List<string> answers = exam.currentQuestion.GetShuffledAnswers();
            ConfigureAnswerButtons(answers);
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

        

    }
}
