using Domain;
using DataAccess;
using Domain.Entities;
using Domain.Contracts;

namespace Business
{
    public class UserService : IUserService
    {
        private IUserRepository _userDataAccess;
        private IBasketRepository _basketRepsitory;
        private IBasketDetailsRepository _basketDetailsRepsitory;
        public UserService(IUserRepository userDataAccess, IBasketRepository basketRepsitory, IBasketDetailsRepository basketDetailsRepository)
        {
            _userDataAccess = userDataAccess;
            _basketRepsitory = basketRepsitory;
            _basketDetailsRepsitory = basketDetailsRepository;
        }

        public ServiceResult<User> GetUserByUserName(string userName)
        {
            return _userDataAccess.GetUserByUserName(userName);
        }

        public ServiceResult<User> SignUpUser(User user)
        {
            return _userDataAccess.SignUpUser(user);
        }

        public List<ServiceResult<BasketDetails>> CheckOut(User user)
        {
            int basketID = _basketRepsitory.GetBasketIDByUser(user).Result;
            return _basketDetailsRepsitory.GetAllBasketDetailsWithBasketID(basketID);

        }
    }
}