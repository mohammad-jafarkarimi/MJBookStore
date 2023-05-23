using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IUserService
    {
        ServiceResult<User> GetUserByUserName(string userName);
    }
}
