using System.Collections.Generic;

namespace WooliesChallengeDatabase
{
    public class UserRepository : IUserRepository
    {
        Dictionary<string, string> userTokenList = new Dictionary<string, string>();

        public UserRepository()
        {
            userTokenList.Add("NEHA", "76f8d8e2-5b0f-43cc-a840-3309f0175de4");
        }
        public string GetUserToken(string userName)
        {
           string token;
            userName = userName.ToUpper();
            userTokenList.TryGetValue(userName, out token);
            return token;
        }
    
    }
}
