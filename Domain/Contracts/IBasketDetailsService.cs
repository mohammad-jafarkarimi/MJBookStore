using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IBasketDetailsService
    {
        ServiceResult<int> AddBasketDetailsToDataBase(Basket basket, Book book);
        public List<ServiceResult<BasketDetails>> GetAllBasketDetailsWithBasketID(int basketID);

    }
}
