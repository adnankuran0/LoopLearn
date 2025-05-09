using LoopLearn.Backend.Auth;
using LoopLearn.Backend.Quiz;
using LoopLearn.Backend.Utils;
using System.Data.SQLite;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LoopLearn.Backend.Database
{
    public static class DatabaseManager
    {
        private static string connectionString = "Data Source=../../../Backend/Database/LoopLearnDB.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(connectionString);
            conn.Open();
            return conn;
        }

        public static void Initalize()
        {

        }

        public static bool AddUser(string username, string password, string securityAnswer)
        {
            using var conn = GetConnection();
            string query = "INSERT INTO Users (UserName, Password,SecurityAnswer) VALUES (@u, @p, @s)";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", password);
            cmd.Parameters.AddWithValue("@s", securityAnswer);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool UserExists(string username)
        {
            using var conn = GetConnection();
            string query = "SELECT COUNT(*) FROM Users WHERE UserName = @u";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@u", username);
            long count = (long)cmd.ExecuteScalar();

            return count > 0;
        }

        public static bool ValidateUser(string username, string hashedPassword)
        {
            using var conn = GetConnection();
            string query = @"SELECT COUNT(*) FROM Users WHERE UserName = @u AND Password = @p";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", hashedPassword);

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count == 1;
        }

        public static bool UpdateUserPassword(string username, string newPassword)
        {
            using var conn = GetConnection();
            string query = "UPDATE Users SET Password = @p WHERE UserName = @u";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", newPassword);

            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool VerifySecurityAnswer(string username, int questionID, string inputAnswer)
        {
            using var conn = GetConnection();
            string query = "SELECT SecurityAnswer FROM Users WHERE UserName = @u";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@u", username);

            var result = cmd.ExecuteScalar();
            if (result == null)
                return false;

            string storedHashedAnswer = result.ToString();

            return storedHashedAnswer == inputAnswer;
        }

        public static UserData? GetUserData(string userName)
        {
            UserData userData = new UserData();
            using var conn = GetConnection();
            string query = "SELECT UserID FROM Users WHERE UserName = @u";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@u", userName);
            var result = cmd.ExecuteScalar();
            if (result == null) return null;

            userData.userID = Convert.ToInt32(result);
            userData.userName = userName;
            return userData;

        }

        public static int AddWord(int userID, string eng, string tur, string picturePath, string audioPath)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand("INSERT INTO Words (UserID,EngWordName, TurWordName, Picture, Audio) VALUES (@uid, @eng, @tur, @pic, @audio); SELECT last_insert_rowid();", conn);
                cmd.Parameters.AddWithValue("@uid", userID);
                cmd.Parameters.AddWithValue("@eng", eng);
                cmd.Parameters.AddWithValue("@tur", tur);
                cmd.Parameters.AddWithValue("@pic", picturePath);
                cmd.Parameters.AddWithValue("@audio", audioPath);


                var wordID = Convert.ToInt32(cmd.ExecuteScalar());
                AddQuestion(UserSession.Instance.UserId, wordID);
                return wordID;
            }
        }
        public static int GetWordCount()
        {
            using var conn = GetConnection();
            string query = "SELECT COUNT(*) FROM Words";
            using var cmd = new SQLiteCommand(query, conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private static int AddQuestion(int userID, int wordID)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand("INSERT INTO Questions (UserID, WordID, CorrectCount, NextReviewDate) " +
                            "VALUES (@userID, @wordID, 0, @reviewDate); SELECT last_insert_rowid();", conn);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@wordID", wordID);
                cmd.Parameters.AddWithValue("@reviewDate", DateTime.Now.AddDays(1));

                var result = cmd.ExecuteScalar();

                return Convert.ToInt32(result);
            }
        }

        public static void AddWordSample(int wordId, string sample)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand("INSERT INTO WordSamples (WordID, Samples) VALUES (@id, @sample);", conn);
                cmd.Parameters.AddWithValue("@id", wordId);
                cmd.Parameters.AddWithValue("@sample", sample);
                cmd.ExecuteNonQuery();
            }
        }
        public static void AddWordAudio(int wordId, string audioPath)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand("INSERT INTO WordAudio (WordID, AudioPath) VALUES (@id, @audio);", conn);
                cmd.Parameters.AddWithValue("@id", wordId);
                cmd.Parameters.AddWithValue("@audio", audioPath);
                cmd.ExecuteNonQuery();
            }
        }

        public static bool WordExists(string engWord)
        {
            using var conn = GetConnection();
            string query = "SELECT COUNT(*) FROM Words WHERE EngWordName = @eng";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@eng", engWord);

            long count = (long)cmd.ExecuteScalar();
            return count > 0;
        }

        public static Word? GetWordByID(int wordID)
        {
            using var conn = GetConnection();
            string query = "SELECT WordID, UserID, EngWordName, TurWordName, Picture, Audio FROM Words WHERE WordID = @id";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", wordID);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Word(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5)
                );
            }

            return null;
        }

        public static Word? GetRandomWord(HashSet<int> excludeIDs)
        {
            using var conn = GetConnection();

            string placeholders = excludeIDs.Count > 0
                ? string.Join(",", excludeIDs.Select((_, i) => $"@id{i}"))
                : "NULL";

            string condition = excludeIDs.Count > 0
                ? $"WHERE WordID NOT IN ({placeholders})"
                : "";

            string query = $@"SELECT WordID, UserID, EngWordName, TurWordName, Picture, Audio 
                      FROM Words 
                      {condition}
                      ORDER BY RANDOM() 
                      LIMIT 1";

            using var cmd = new SQLiteCommand(query, conn);

            int index = 0;
            foreach (var id in excludeIDs)
            {
                cmd.Parameters.AddWithValue($"@id{index}", id);
                index++;
            }

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Word(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5)
                );
            }

            return null;
        }

        private static Word GetUniqueRandomWord(HashSet<int> excludeIDs)
        {
            Word? word = null;
            int attempts = 0;

            while (word == null && attempts < 10)
            {
                word = GetRandomWord(excludeIDs);

                if (word != null && !excludeIDs.Contains(word.wordID))
                {
                    return word;
                }

                attempts++;
            }

            throw new Exception("Yeterince farklı kelime bulunamadı.");
        }

        public static Question? GetQuestionByID(int questionID)
        {
            if (GetWordCount() < 4)
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

            Word? correctWord = GetWordByID(correctWordID);
            if (correctWord == null)
                return null;

            HashSet<int> usedIDs = new HashSet<int> { correctWordID };

            Word wrong1 = GetUniqueRandomWord(usedIDs);
            usedIDs.Add(wrong1.wordID);

            Word wrong2 = GetUniqueRandomWord(usedIDs);
            usedIDs.Add(wrong2.wordID);

            Word wrong3 = GetUniqueRandomWord(usedIDs);

            return new Question()
            {
                questionID = qID,
                userID = userID,
                CorrectWord = correctWord,
                WrongWord1 = wrong1,
                WrongWord2 = wrong2,
                WrongWord3 = wrong3,
                correctCount = correctCount,
                answerDate = answerDate,
                nextReviewDate = nextReviewDate
            };
        }

        public static string GetSampleByWordID(int wordID)
        {
            using var conn = GetConnection();
            string query = "SELECT Samples FROM WordSamples WHERE WordID = @id LIMIT 1";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", wordID);

            var result = cmd.ExecuteScalar();

            return result?.ToString() ?? string.Empty;
        }

        public static List<int> GetQuestionIDsByUser(int userID)
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

        public static List<int> GetNewQuestionIDs(int userID, int count)
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

        public static List<int> GetDueQuestionIDs(int userID)
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

        public static void UpdateQuestionAfterAnswer(int questionID, bool isCorrect)
        {
            using var conn = GetConnection();
            string query = "SELECT UserID, WordID, CorrectCount FROM Questions WHERE QuestionID = @qid";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@qid", questionID);
            using var reader = cmd.ExecuteReader();

            if (!reader.Read())
                return; 

            int userID = reader.GetInt32(0);
            int wordID = reader.GetInt32(1);
            int correctCount = reader.GetInt32(2);

            if (correctCount >= 6)
                return;

            DateTime now = DateTime.Now;
            DateTime? nextReviewDate;
            DateTime? lastAnsweredDate;

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
                correctCount = 0;
                lastAnsweredDate = null;
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

        private static DateTime CalculateNextReviewDate(int correctCount, DateTime currentDate)
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

        public static void AddKnownWord(int userID, int wordID, DateTime knownDate)
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

