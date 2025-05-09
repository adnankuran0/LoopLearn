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

            var newIds = Database.Database.GetNewQuestionIDs(UserSession.UserId,dailyNewCount);
            var dueIds = Database.Database.GetDueQuestionIDs(UserSession.UserId);
            var allIds = newIds.Concat(dueIds).Distinct();

            Exam exam = new Exam();
            foreach (var qid in allIds)
            {
                var q = Database.Database.GetQuestionByID(qid);
                if (q != null)
                {
                    exam.AddQuestion(q);
                }
            }

            return exam;
        }
    }

}
    
