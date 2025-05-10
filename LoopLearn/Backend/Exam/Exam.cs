using LoopLearn.Backend.Auth;
using LoopLearn.Backend.Database;

namespace LoopLearn.Backend.Quiz
{
    public class Exam
    {
        public List<Question> questions {  get; private set; }
        public Question currentQuestion;
        private int currentQuestionIndex = 0;

        public Exam(int dailyNewCount)
        {
            questions = new List<Question>();
            var newIds = DatabaseManager.GetNewQuestionIDs(UserSession.Instance.UserId, dailyNewCount);
            var dueIds = DatabaseManager.GetDueQuestionIDs(UserSession.Instance.UserId);
            var allIds = newIds.Concat(dueIds).Distinct();

            foreach (var qid in allIds)
            {
                var q = DatabaseManager.GetQuestionByID(qid);
                if (q != null)
                {
                    questions.Add(q);
                }
            }
        }

        public Question? GetNextQuestion()
        {
            if (currentQuestionIndex < questions.Count)
            {
                return questions[currentQuestionIndex++];
            }
            else
            {
                return null;
            }
        }
    }
}
