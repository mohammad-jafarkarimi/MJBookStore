using Domain;
using DataAccess;

namespace Business
{
    public class UserService : IUserService
    {
        private IUserRepository _userDataAccess;
        public UserService(IUserRepository userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }
        public ServiceResult<User> GetUserByUserName(string userName)
        {
            return _userDataAccess.GetUser(userName);            
        }
    }
}