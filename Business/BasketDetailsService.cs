using Domain;
using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business

{
    public class BasketDetailsService : IBasketDetailsService
    {
        private IBasketDetailsRepository _basketDetailsDataAccess;
        public BasketDetailsService(IBasketDetailsRepository basketDetailsDataAccess)
        {
            _basketDetailsDataAccess = basketDetailsDataAccess;
        }

        public ServiceResult<int> AddBasketDetailsToDataBase(Basket basket, Book book)
        {
            return _basketDetailsDataAccess.AddBasketDetailsToDataBase(basket, book);
        }

        public List<ServiceResult<BasketDetails>> GetAllBasketDetailsWithBasketID(int basketID)
        {
            return _basketDetailsDataAccess.GetAllBasketDetailsWithBasketID(basketID);

        }
    }
}