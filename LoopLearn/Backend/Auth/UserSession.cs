using LoopLearn.Backend.Database;

namespace LoopLearn.Backend.Auth
{
    public class UserSession
    {
        private static UserSession? instance;

        public static UserSession Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserSession();

                return instance;
            }
        }

        public int UserId { get; set; }
        public string UserName { get; set; }

        public void SetUserData(string userName)
        {
            UserData? userData = DatabaseService.Instance.userRepository.GetUserData(userName);
            UserId = userData.userID;
            UserName = userData.userName;   
        }

        public bool IsActive => UserId != 0 && !string.IsNullOrEmpty(UserName);
    }
}
