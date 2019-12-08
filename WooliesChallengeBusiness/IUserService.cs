using WooliesChallenge.Business.Models;

namespace WooliesChallengeBusiness
{
    public interface IUserService
    {
        UserDto GetUserToken(string userName);
    }
}
