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

        public static void AddUser(string username, string password)
        {
            using var conn = GetConnection();
            string query = "INSERT INTO Users (UserName, Password) VALUES (@u, @p)";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", password);
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
            string newHash = PasswordHasher.Hash(newPassword);

            using var conn = GetConnection();
            string query = "UPDATE Users SET Password = @p WHERE UserName = @u";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", newHash);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
