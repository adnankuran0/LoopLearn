using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoopLearn.Backend.Auth;
using LoopLearn.Backend.Database;

namespace LoopLearn.Backend.Quiz
{
    public class Exam
    {
        public List<Question> questions {  get; private set; }
        private int currentQuestionIndex = 0;

        public Exam()
        {
            questions = new List<Question>();
        }

        public void AddQuestion(Question question)
        {
            questions.Add(question);
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
