using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopLearn.Backend.Quiz
{
    public class Question
    {
        public int questionID {  get; set; }
        public int userID { get; set; }
        public Word CorrectWord { get; set; }
        public Word WrongWord1 { get; set; }
        public Word WrongWord2 { get; set; }
        public Word WrongWord3 { get; set; }
        public int correctCount { get; set; }
        public DateTime? answerDate { get; set; }
        public DateTime? nextReviewDate { get; set; }
    }
}
