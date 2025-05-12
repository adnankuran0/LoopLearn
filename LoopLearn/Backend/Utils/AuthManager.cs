using LoopLearn.Backend.Database;

namespace LoopLearn.Backend.Utils
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
            if (DatabaseService.Instance.userRepository.UserExists(username))
                return false;

            string hashedPassword = Hasher.Hash(password);
            string hashedSecurityAnswer = Hasher.Hash(securityAnswer + seqQuestionID.ToString());

            return DatabaseService.Instance.userRepository.AddUser(username, hashedPassword, hashedSecurityAnswer);
        }

        public bool Login(string username, string password)
        {
            string hashedPassword = Hasher.Hash(password);
            return DatabaseService.Instance.userRepository.ValidateUser(username, hashedPassword);
        }

        public bool UpdatePassword(string username, string newPassword, int seqQuestionID, string securityAnswer)
        {
            string hashedSecurityAnswer = Hasher.Hash(securityAnswer + seqQuestionID.ToString());
            if (!DatabaseService.Instance.userRepository.VerifySecurityAnswer(username, seqQuestionID, hashedSecurityAnswer))
                return false;

            string newHashedPassword = Hasher.Hash(newPassword);
            return DatabaseService.Instance.userRepository.UpdateUserPassword(username, newHashedPassword);
        }
    }
}
