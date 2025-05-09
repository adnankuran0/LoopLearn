using LoopLearn.Backend.Utils;
using LoopLearn.Backend.Database;

namespace LoopLearn.Backend.Auth
{
    public class AuthManager
    {
        private static AuthManager? instance;

        public static AuthManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new AuthManager();

                return instance;
            }
        }

        public void Kill()
        {
            instance = null;
        }

        public bool Register(string username, string password, int seqQuestionID, string securityAnswer)
        {
            if (DatabaseManager.UserExists(username))
                return false;

            string hashedPassword = Hasher.Hash(password);
            string hashedSecurityAnswer = Hasher.Hash(securityAnswer + seqQuestionID.ToString());

            return DatabaseManager.AddUser(username, hashedPassword, hashedSecurityAnswer);
        }

        public bool Login(string username, string password)
        {
            string hashedPassword = Hasher.Hash(password);
            return DatabaseManager.ValidateUser(username, hashedPassword);
        }

        public bool UpdatePassword(string username, string newPassword, int seqQuestionID, string securityAnswer)
        {
            string hashedSecurityAnswer = Hasher.Hash(securityAnswer + seqQuestionID.ToString());
            if (!DatabaseManager.VerifySecurityAnswer(username, seqQuestionID, hashedSecurityAnswer))
                return false;

            string newHashedPassword = Hasher.Hash(newPassword);
            return DatabaseManager.UpdateUserPassword(username, newHashedPassword);
        }
    }
}
