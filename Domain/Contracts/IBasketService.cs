using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IBasketService
    {
        ServiceResult<int> AddBasketToDataBase(Basket basket, User user);
    }
}
