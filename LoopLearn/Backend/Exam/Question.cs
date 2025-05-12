using LoopLearn.Backend.Database;
using System.Text.RegularExpressions;

namespace LoopLearn.Backend.Quiz
{
    public class Question
    {
        private readonly Random random = new Random();

        private Word _correctWord;
        public Word correctWord
        {
            get => _correctWord;
            set
            {
                _correctWord = value;
                if (_correctWord != null)
                {
                    string rawSampleSentence = DatabaseService.Instance.questionRepository.GetSampleByWordID(_correctWord.wordID);
                    sampleSentence = HideAnswerInSentence(rawSampleSentence, _correctWord.engWordName);
                }
            }
        }

        private List<Word> _wrongWords = new List<Word>(3);
        public List<Word> wrongWords
        {
            get => _wrongWords;
            set
            {
                if (value == null || value.Count != 3)
                    throw new ArgumentException("Tam olarak 3 yanlış kelime gereklidir.");
                _wrongWords = value;
            }
        }

        public int questionID { get; set; }
        public int userID { get; set; }
        public int correctCount { get; set; }
        public DateTime? answerDate { get; set; }
        public DateTime? nextReviewDate { get; set; }

        public string? sampleSentence;

        public List<string> GetShuffledAnswers()
        {
            var answers = new List<string>
            {
                correctWord.engWordName,
                wrongWords[0].engWordName,
                wrongWords[1].engWordName,
                wrongWords[2].engWordName
            };

            return answers.OrderBy(_ => random.Next()).ToList();
        }

        public bool SubmitAnswer(string answer)
        {
            bool isAnswerCorrect = answer.Equals(
                correctWord.engWordName,
                StringComparison.OrdinalIgnoreCase);

            DatabaseService.Instance.questionRepository.UpdateQuestionAfterAnswer(questionID, isAnswerCorrect);
            return isAnswerCorrect;
        }

        private string HideAnswerInSentence(string text, string wordToReplace)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(wordToReplace))
                return text;

            string pattern = Regex.Escape(wordToReplace);
            return Regex.Replace(text, pattern, "...", RegexOptions.IgnoreCase);
        }
    }
}
