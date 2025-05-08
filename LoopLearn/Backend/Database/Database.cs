using LoopLearn.Backend.Auth;
using LoopLearn.Backend.Quiz;
using LoopLearn.Backend.Utils;
using System.Data.SQLite;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LoopLearn.Backend.Database
{
    public static class Database
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

        public static void AddUser(string username, string password, string securityAnswer)
        {
            using var conn = GetConnection();
            string query = "INSERT INTO Users (UserName, Password,SecurityAnswer) VALUES (@u, @p, @s)";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", password);
            cmd.Parameters.AddWithValue("@s", securityAnswer);
            cmd.ExecuteNonQuery();
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

        public static bool ValidateUser(string username, string password)
        {
            string hashedPassword = PasswordHasher.Hash(password);

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
                AddQuestion(UserSession.UserId, wordID);
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

            return new Question(qID)
            {
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
    }
}
