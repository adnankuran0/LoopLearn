using LoopLearn.Backend.Utils;

namespace LoopLearn.Backend.Auth
{
    public class AuthService
    {
        public bool Register(string username, string password)
        {
            if (Database.Database.UserExists(username))
            {
                return false;
            }

            string hashedPassword = PasswordHasher.Hash(password);

            try
            {
                Database.Database.AddUser(username, hashedPassword);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Login(string username, string password)
        {
            return Database.Database.ValidateUser(username, password);
        }

        public bool UpdatePassword(string username, string newPassword)
        {
            return Database.Database.UpdateUserPassword(username, newPassword);
        }
    }
}
