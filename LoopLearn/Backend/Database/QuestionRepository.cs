using LoopLearn.Backend.Quiz;
using LoopLearn.Backend.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopLearn.Backend.Database
{
    public class QuestionRepository : Repository
    {
        public QuestionRepository(SqliteConnectionProvider ConnectionProvider) : base(ConnectionProvider) { }
        public  Question? GetQuestionByID(int questionID)
        {
            if (WordManager.GetWordCount() < 4)
                throw new Exception("Soru oluşturmak için yeterli kelime yok.");

            using var conn = GetConnection();

            string query = @"SELECT QuestionID, UserID, WordID, CorrectCount, LastAnsweredDate, NextReviewDate
                     FROM Questions
                     WHERE QuestionID = @qid";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@qid", questionID);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read())
                return null;

            int qID = reader.GetInt32(0);
            int userID = reader.GetInt32(1);
            int correctWordID = reader.GetInt32(2);
            int correctCount = reader.GetInt32(3);
            DateTime? answerDate = reader.IsDBNull(4) ? null : reader.GetDateTime(4);
            DateTime? nextReviewDate = reader.IsDBNull(5) ? null : reader.GetDateTime(5);

            Word? correctWord = WordManager.GetWordByID(correctWordID);
            if (correctWord == null)
                return null;

            HashSet<int> usedIDs = new HashSet<int> { correctWordID };

            var wrongWords = new List<Word>
            {
                WordManager.GetUniqueRandomWord(usedIDs),
                WordManager.GetUniqueRandomWord(usedIDs),
                WordManager.GetUniqueRandomWord(usedIDs)
            };

            foreach (var w in wrongWords)
                usedIDs.Add(w.wordID);

            return new Question
            {
                questionID = qID,
                userID = userID,
                correctWord = correctWord,
                wrongWords = wrongWords,
                correctCount = correctCount,
                answerDate = answerDate,
                nextReviewDate = nextReviewDate
            };
        }

        public  string GetSampleByWordID(int wordID)
        {
            using var conn = GetConnection();
            string query = "SELECT Samples FROM WordSamples WHERE WordID = @id LIMIT 1";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", wordID);

            var result = cmd.ExecuteScalar();

            return result?.ToString() ?? string.Empty;
        }

        public  List<int> GetQuestionIDsByUser(int userID)
        {
            List<int> questionIDs = new List<int>();

            using var conn = GetConnection();

            string query = "SELECT QuestionID FROM Questions WHERE UserID = @uid";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@uid", userID);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                questionIDs.Add(reader.GetInt32(0));
            }

            return questionIDs;
        }

        public  List<int> GetNewQuestionIDs(int userID, int count)
        {
            using var conn = GetConnection();
            using var cmd = new SQLiteCommand(
                "SELECT QuestionID FROM Questions WHERE UserID = @uid AND LastAnsweredDate IS NULL LIMIT @cnt", conn);
            cmd.Parameters.AddWithValue("@uid", userID);
            cmd.Parameters.AddWithValue("@cnt", count);
            using var reader = cmd.ExecuteReader();
            var ids = new List<int>();
            while (reader.Read())
                ids.Add(reader.GetInt32(0));
            return ids;
        }

        public  List<int> GetDueQuestionIDs(int userID)
        {
            using var conn = GetConnection();
            using var cmd = new SQLiteCommand(
                "SELECT QuestionID FROM Questions WHERE UserID = @uid AND NextReviewDate <= @now", conn);
            cmd.Parameters.AddWithValue("@uid", userID);
            cmd.Parameters.AddWithValue("@now", DateTime.Now);
            using var reader = cmd.ExecuteReader();
            var ids = new List<int>();
            while (reader.Read())
                ids.Add(reader.GetInt32(0));
            return ids;
        }

        public  void UpdateQuestionAfterAnswer(int questionID, bool isCorrect)
        {
            using var conn = GetConnection();
            string query = "SELECT UserID, WordID, CorrectCount, LastAnsweredDate, NextReviewDate FROM Questions WHERE QuestionID = @qid";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@qid", questionID);
            using var reader = cmd.ExecuteReader();

            if (!reader.Read())
                return;

            int userID = reader.GetInt32(0);
            int wordID = reader.GetInt32(1);
            int correctCount = reader.GetInt32(2);
            DateTime? lastAnsweredDate = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3);
            DateTime? nextReviewDate = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4);

            if (correctCount >= 6)
                return;

            DateTime now = DateTime.Now;

            if (isCorrect)
            {
                correctCount++;
                lastAnsweredDate = now;
                nextReviewDate = CalculateNextReviewDate(correctCount, now);

                if (correctCount == 6)
                    AddKnownWord(userID, wordID, now);
            }
            else
            {
                if (correctCount == 0)
                    lastAnsweredDate = now;

                correctCount = 0;
                nextReviewDate = now.AddDays(1);
            }

            string updateQuery = @"
                UPDATE Questions 
                SET CorrectCount = @correctCount, 
                    LastAnsweredDate = @lastAnsweredDate, 
                    NextReviewDate = @nextReviewDate 
                WHERE QuestionID = @qid";
            using var updateCmd = new SQLiteCommand(updateQuery, conn);
            updateCmd.Parameters.AddWithValue("@correctCount", correctCount);
            updateCmd.Parameters.AddWithValue("@lastAnsweredDate",
                lastAnsweredDate.HasValue ? (object)lastAnsweredDate.Value : DBNull.Value);
            updateCmd.Parameters.AddWithValue("@nextReviewDate", nextReviewDate);
            updateCmd.Parameters.AddWithValue("@qid", questionID);
            updateCmd.ExecuteNonQuery();
        }
        private  DateTime CalculateNextReviewDate(int correctCount, DateTime currentDate)
        {
            return correctCount switch
            {
                1 => currentDate.AddDays(1),
                2 => currentDate.AddDays(7),
                3 => currentDate.AddDays(30),
                4 => currentDate.AddDays(90),
                5 => currentDate.AddDays(180),
                6 => currentDate.AddDays(365),
                _ => currentDate.AddDays(1),
            };
        }

        public  void AddKnownWord(int userID, int wordID, DateTime knownDate)
        {
            using var conn = GetConnection();
            string insert = @"
        INSERT OR IGNORE INTO KnownWords (UserID, WordID, KnownDate)
        VALUES (@uid, @wid, @kdate)";
            using var cmd = new SQLiteCommand(insert, conn);
            cmd.Parameters.AddWithValue("@uid", userID);
            cmd.Parameters.AddWithValue("@wid", wordID);
            cmd.Parameters.AddWithValue("@kdate", knownDate);
            cmd.ExecuteNonQuery();
        }
    }
}

