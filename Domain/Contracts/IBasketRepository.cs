using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IBasketRepository
    {
        ServiceResult<int> AddBasketToDataBase(Basket basket, User user);
        ServiceResult<int> GetBasketIDByUser(User user);
    }
}
