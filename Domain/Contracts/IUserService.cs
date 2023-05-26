using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IUserService
    {
        ServiceResult<User> GetUserByUserName(string userName);
        ServiceResult<User> SignUpUser(User user);
        List<ServiceResult<BasketDetails>> CheckOut(User user);

    }
}
