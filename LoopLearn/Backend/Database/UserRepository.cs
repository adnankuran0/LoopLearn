using LoopLearn.Backend.Auth;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LoopLearn.Backend.Database
{
    public class UserRepository : Repository
    {
        public UserRepository(SqliteConnectionProvider ConnectionProvider) : base(ConnectionProvider)
        {
            
        }

        public bool AddUser(string username, string password, string securityAnswer)
        {
            if (UserExists(username)) return false;

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

        public bool UserExists(string username)
        {
            using var conn = GetConnection();
            string query = "SELECT COUNT(*) FROM Users WHERE UserName = @u";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@u", username);
            long count = (long)cmd.ExecuteScalar();

            return count > 0;
        }

        public bool ValidateUser(string username, string hashedPassword)
        {
            using var conn = GetConnection();
            string query = @"SELECT COUNT(*) FROM Users WHERE UserName = @u AND Password = @p";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", hashedPassword);

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count == 1;
        }

        public bool UpdateUserPassword(string username, string newPassword)
        {
            using var conn = GetConnection();
            string query = "UPDATE Users SET Password = @p WHERE UserName = @u";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", newPassword);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool VerifySecurityAnswer(string username, int questionID, string inputAnswer)
        {
            using var conn = GetConnection();
            string query = "SELECT SecurityAnswer FROM Users WHERE UserName = @u";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@u", username);

            var result = cmd.ExecuteScalar();
            if (result == null)
                return false;

            string? storedHashedAnswer = result.ToString();

            return storedHashedAnswer == inputAnswer;
        }

        public UserData? GetUserData(string userName)
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
    }
}
