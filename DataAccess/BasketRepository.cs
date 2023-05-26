using Domain.Entities;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using System.Data.SqlTypes;

namespace DataAccess
{
    public class BasketRepository : IBasketRepository
    {
        public ServiceResult<int> AddBasketToDataBase(Basket basket, User user)
        {
            using (var _dataBaseContext = new DataBaseContext())
            {

                // with inserted.id I get the automatic id that sql gives to this basket, then return this id 
                // with the serviceresult and use it to insert to the basketdetail table later...

                string command = $"INSERT INTO BASKET (ORDERDATE, USERID) OUTPUT INSERTED.ID AS 'ID' values ('{DateTime.Today}', '{user.Id}');";
                using var cmd = new SqlCommand(command, _dataBaseContext.connection);
                var reader = cmd.ExecuteScalar();

                basket.Id = (Int32)reader;

                if ((Int32)reader > 0)
                {
                    return new ServiceSuccessResult<int>((Int32)reader);

                }
                else
                {
                    return new ServiceErrorResult<int>("No data added to basket!");
                }

            }
        }


        public ServiceResult<int> GetBasketIDByUser(User user)
        {
            using (var _dataBaseContext = new DataBaseContext())
            {

                var BasketList = new List<ServiceResult<BasketDetails>>();
                string command = $"Select ID FROM BASKET WHERE USERID = {user.Id};";
                using var cmd = new SqlCommand(command, _dataBaseContext.connection);
                var reader = cmd.ExecuteScalar();

                if ((Int32)reader > 0)
                {
                    return new ServiceSuccessResult<int>((Int32)reader);
                }
                else
                {
                    return new ServiceErrorResult<int>("no basket by that user!");

                }
            }
        }
    }
}
