using System;
using WooliesChallenge.Business.Models;
using WooliesChallengeDatabase;

namespace WooliesChallengeBusiness
{
    public class UserService : IUserService
    {
       private IUserRepository _userRepository;

       public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserDto GetUserToken(string userName)
        {
            string token;
            UserDto objUser = new UserDto();
            token = _userRepository.GetUserToken(userName);
            if(!String.IsNullOrEmpty(token))
            {
                objUser.Name = "Neha Pundir";
                objUser.Token = token;
            }
            return objUser;
        }
    }
}
