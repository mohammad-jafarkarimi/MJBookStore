
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IUserRepository
    {
        public ServiceResult<User> GetUserByUserName(string userName);
        public ServiceResult<User> SignUpUser(User user);

    }
}
