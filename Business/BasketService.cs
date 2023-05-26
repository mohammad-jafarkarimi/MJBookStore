using Domain.Entities;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;

namespace Business
{
    public class BasketService : IBasketService
    {
        private IBasketRepository _basketDataAccess;
        public BasketService(IBasketRepository basketDataAccess)
        {
            _basketDataAccess = basketDataAccess;
        }

        public ServiceResult<int> AddBasketToDataBase(Basket basket, User user)
        {
            return _basketDataAccess.AddBasketToDataBase(basket, user);

        }


    }
}
