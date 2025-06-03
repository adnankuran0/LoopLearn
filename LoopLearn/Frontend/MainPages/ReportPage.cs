using LoopLearn.Backend.Auth;
using LoopLearn.Backend.Database;
using System.Drawing.Printing;

namespace LoopLearn.Frontend
{
    public partial class Report : UserControl
    {
        private string currentUsername = UserSession.Instance.UserName;

        private string wrongQuestions;
        private string totalAnsweredQuestions;
        private string correctQuestions;
        private string correctPuzzles;


        public Report()
        {
            InitializeComponent();
            LoadStats();
        }

        private void LoadStats()
        {
            var user = DatabaseService.Instance.userRepository.GetUserData(currentUsername);
            if (user == null)
            {
                MessageBox.Show("Kullanıcı bulunamadı.");
                return;
            }

            var stats = DatabaseService.Instance.userStatsRepository.GetStats();
            if (stats != null)
            {
                correctQuestions = Convert.ToString(stats.Value.correctQuestions);
                wrongQuestions = Convert.ToString(stats.Value.wrongQuestions);
                correctPuzzles = Convert.ToString(stats.Value.correctPuzzles);
                totalAnsweredQuestions = Convert.ToString(stats.Value.wrongQuestions + stats.Value.correctQuestions);


                totalQuestions.Text = $"Cevaplanan Sorular: {totalAnsweredQuestions}";
                labelCorrectQuestions.Text = $"Doğru Cevaplanan Sorular: {correctQuestions}";
                labelWrongQuestions.Text = $"Yanlış Cevaplanan Sorular: {wrongQuestions}";
                labelCorrectPuzzles.Text = $"Doğru Çözülen Bulmacalar: {correctPuzzles}";


            }
        }

        private void btnPrintStats_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintStatsPage;
            PrintDialog dialog = new PrintDialog();
            dialog.Document = printDoc;

            if (dialog.ShowDialog() == DialogResult.OK)
                printDoc.Print();
        }

        private void PrintStatsPage(object sender, PrintPageEventArgs e)
        {
            float yPos = 100;
            float leftMargin = e.MarginBounds.Left;

            e.Graphics.DrawString("LoopLearn - Kullanıcı İstatistik Raporu", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, leftMargin, yPos);
            yPos += 40;
            e.Graphics.DrawString($"Kullanıcı: {currentUsername}", new Font("Arial", 12), Brushes.Black, leftMargin, yPos);
            yPos += 30;
            e.Graphics.DrawString($"Cevaplanan Sorular: {totalAnsweredQuestions}", new Font("Arial", 12), Brushes.Black, leftMargin, yPos);
            yPos += 25;
            e.Graphics.DrawString($"Doğru Sorular: {correctQuestions}", new Font("Arial", 12), Brushes.Black, leftMargin, yPos);
            yPos += 20;
            e.Graphics.DrawString($"Yanlış Sorular: {wrongQuestions}", new Font("Arial", 12), Brushes.Black, leftMargin, yPos);
            yPos += 15;
            e.Graphics.DrawString($"Doğru Bulmacalar: {correctPuzzles}", new Font("Arial", 12), Brushes.Black, leftMargin, yPos);


        }
    }
}
