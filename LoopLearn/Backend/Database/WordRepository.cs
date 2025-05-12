using LoopLearn.Backend.Auth;
using LoopLearn.Backend.Quiz;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopLearn.Backend.Database
{
    public class WordRepository : Repository
    {
        public WordRepository(SqliteConnectionProvider ConnectionProvider) : base(ConnectionProvider) { }
        public int AddWord(string eng, string tur, string picturePath, string audioPath)
        {
            using var conn = GetConnection();
            conn.Open();
            var cmd = new SQLiteCommand("INSERT INTO Words (UserID,EngWordName, TurWordName, Picture, Audio) VALUES (@uid, @eng, @tur, @pic, @audio); SELECT last_insert_rowid();", conn);
            cmd.Parameters.AddWithValue("@uid", UserSession.Instance.UserId);
            cmd.Parameters.AddWithValue("@eng", eng);
            cmd.Parameters.AddWithValue("@tur", tur);
            cmd.Parameters.AddWithValue("@pic", picturePath);
            cmd.Parameters.AddWithValue("@audio", audioPath);


            var wordID = Convert.ToInt32(cmd.ExecuteScalar());
            AddQuestion(wordID);
            return wordID;
        }
        public int GetWordCount()
        {
            using var conn = GetConnection();
            string query = "SELECT COUNT(*) FROM Words";
            using var cmd = new SQLiteCommand(query, conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private int AddQuestion(int wordID)
        {
            using var conn = GetConnection();
            conn.Open();
            var cmd = new SQLiteCommand("INSERT INTO Questions (UserID, WordID, CorrectCount, NextReviewDate) " +
                        "VALUES (@userID, @wordID, 0, @reviewDate); SELECT last_insert_rowid();", conn);
            cmd.Parameters.AddWithValue("@userID", UserSession.Instance.UserName);
            cmd.Parameters.AddWithValue("@wordID", wordID);
            cmd.Parameters.AddWithValue("@reviewDate", DateTime.Now.AddDays(1));

            var result = cmd.ExecuteScalar();

            return Convert.ToInt32(result);
        }

        public void AddWordSample(int wordId, string sample)
        {
            using var conn = GetConnection();
            conn.Open();
            var cmd = new SQLiteCommand("INSERT INTO WordSamples (WordID, Samples) VALUES (@id, @sample);", conn);
            cmd.Parameters.AddWithValue("@id", wordId);
            cmd.Parameters.AddWithValue("@sample", sample);
            cmd.ExecuteNonQuery();
        }
        public void AddWordAudio(int wordId, string audioPath)
        {
            using var conn = GetConnection();
            conn.Open();
            var cmd = new SQLiteCommand("INSERT INTO WordAudio (WordID, AudioPath) VALUES (@id, @audio);", conn);
            cmd.Parameters.AddWithValue("@id", wordId);
            cmd.Parameters.AddWithValue("@audio", audioPath);
            cmd.ExecuteNonQuery();
        }

        public bool WordExists(string engWord)
        {
            using var conn = GetConnection();
            string query = "SELECT COUNT(*) FROM Words WHERE EngWordName = @eng";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@eng", engWord);

            long count = (long)cmd.ExecuteScalar();
            return count > 0;
        }

        public Word? GetWordByID(int wordID)
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

        public Word? GetRandomWord(HashSet<int> excludeIDs)
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

        public Word GetUniqueRandomWord(HashSet<int> excludeIDs)
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
    }
}
