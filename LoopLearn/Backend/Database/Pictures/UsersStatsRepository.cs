using LoopLearn.Backend.Auth;
using System.Data.SQLite;

namespace LoopLearn.Backend.Database
{
    public class UserStatsRepository : Repository
    {
        public UserStatsRepository(SqliteConnectionProvider connectionProvider) : base(connectionProvider)
        {
        }

        private void EnsureStatsRowExists()
        {
            using var conn = GetConnection();
            string insertQuery = "INSERT OR IGNORE INTO Stats (UserID) VALUES (@userID)";
            using var cmd = new SQLiteCommand(insertQuery, conn);
            cmd.Parameters.AddWithValue("@userID", UserSession.Instance.UserId);
            cmd.ExecuteNonQuery();
        }

        public void IncrementQuizStat()
        {
            EnsureStatsRowExists();
            using var conn = GetConnection();
            string updateQuery = "UPDATE Stats SET CorrectQuestionCount = CorrectQuestionCount + 1 WHERE UserID = @userID";
            using var cmd = new SQLiteCommand(updateQuery, conn);
            cmd.Parameters.AddWithValue("@userID", UserSession.Instance.UserId);
            cmd.ExecuteNonQuery();
        }

        public void IncrementWrongStat()
        {
            EnsureStatsRowExists();
            using var conn = GetConnection();
            string updateQuery = "UPDATE Stats SET WrongQuestionCount = WrongQuestionCount + 1 WHERE UserID = @userID";
            using var cmd = new SQLiteCommand(updateQuery, conn);
            cmd.Parameters.AddWithValue("@userID", UserSession.Instance.UserId);
            cmd.ExecuteNonQuery();
        }

        public void IncrementPuzzleStat()
        {
            EnsureStatsRowExists();
            using var conn = GetConnection();
            string updateQuery = "UPDATE Stats SET CorrectPuzzleCount = CorrectPuzzleCount + 1 WHERE UserID = @userID";
            using var cmd = new SQLiteCommand(updateQuery, conn);
            cmd.Parameters.AddWithValue("@userID", UserSession.Instance.UserId);
            cmd.ExecuteNonQuery();
        }

        public (int correctQuestions, int wrongQuestions ,int correctPuzzles)? GetStats()
        {
            EnsureStatsRowExists();
            using var conn = GetConnection();
            string selectQuery = "SELECT CorrectQuestionCount, CorrectPuzzleCount,WrongQuestionCount FROM Stats WHERE UserID = @userID";
            using var cmd = new SQLiteCommand(selectQuery, conn);
            cmd.Parameters.AddWithValue("@userID", UserSession.Instance.UserId);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int questions = reader.GetInt32(0);
                int puzzles = reader.GetInt32(1);
                int wrongQuestions = reader.GetInt32(2);
                return (questions, puzzles, wrongQuestions);
            }
            return null;
        }
    }
}
