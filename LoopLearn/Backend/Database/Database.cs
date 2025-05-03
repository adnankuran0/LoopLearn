using LoopLearn.Backend.Utils;
using System.Data.SQLite;

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
    }
}
