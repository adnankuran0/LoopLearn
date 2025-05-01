using LoopLearn.Backend.Utils;
namespace LoopLearn.Backend.Auth
{
    public class AuthService
    {
        public bool Register(string username, string password,int questionID,string securityAnswer)
        {
            
            if (Database.Database.UserExists(username))
            {
                return false;
            }

            string hashedPassword = PasswordHasher.Hash(password);
            string hashedSecurityAnswer = PasswordHasher.Hash(securityAnswer+questionID.ToString());

            try
            {
                Database.Database.AddUser(username, hashedPassword,hashedSecurityAnswer);
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

        public bool UpdatePassword(string username, string newPassword, int questionID, string securityAnswer)
        {
            string hashedSecurityAnswer = PasswordHasher.Hash(securityAnswer + questionID.ToString());
            if (!Database.Database.VerifySecurityAnswer(username, questionID, hashedSecurityAnswer))
                return false;

            string newHashedPassword = PasswordHasher.Hash(newPassword);
            return Database.Database.UpdateUserPassword(username, newHashedPassword);
        }
    }
}
