using LoopLearn.Backend.Quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoopLearn.Backend.Database;
using LoopLearn.Backend.Auth;

namespace LoopLearn.Backend.ExamManager
{
    public static class ExamManager
    {
        public static Exam CreateExam(int dailyNewCount)
        {

            var newIds = DatabaseManager.GetNewQuestionIDs(UserSession.Instance.UserId,dailyNewCount);
            var dueIds = DatabaseManager.GetDueQuestionIDs(UserSession.Instance.UserId);
            var allIds = newIds.Concat(dueIds).Distinct();

            Exam exam = new Exam();
            foreach (var qid in allIds)
            {
                var q = DatabaseManager.GetQuestionByID(qid);
                if (q != null)
                {
                    exam.AddQuestion(q);
                }
            }

            return exam;
        }
    }

}
    
