using Domain;
using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BasketDetailsRepository : IBasketDetailsRepository
    {
        public ServiceResult<int> AddBasketDetailsToDataBase(Basket basket, Book book)
        {
            using (var _dataBaseContext = new DataBaseContext())
            {


                string command = $"INSERT INTO BASKETDETAILS (BASKETID, BOOKID, PRICE, NUMBER) values ('{basket.Id}', '{book.Id}', '{book.Price}', '1');";
                using var cmd = new SqlCommand(command, _dataBaseContext.connection);
                var reader = cmd.ExecuteNonQuery();

                if ((Int32)reader > 0)
                {
                    return new ServiceSuccessResult<int>((Int32)reader);

                }
                else
                {
                    return new ServiceErrorResult<int>("No data added to basketdetails!");
                }

            }
        }

        public List<ServiceResult<BasketDetails>> GetAllBasketDetailsWithBasketID(int basketID)
        {

            var basketDetailsList = new List<ServiceResult<BasketDetails>>();
            using (var _dataBaseContext = new DataBaseContext())
            {

                string command = $"SELECT * FROM BASKETDETAILS WHERE BASKETID = '{basketID}';";
                using var cmd = new SqlCommand(command, _dataBaseContext.connection);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    BasketDetails basketDetails = new BasketDetails { BasketId = (Int32)reader[0], BookID = (Int32)reader[1], Price = (decimal)reader[2] , Number = (Int32)reader[3] };
                    basketDetailsList.Add(new ServiceSuccessResult<BasketDetails>(basketDetails));
                }

                return basketDetailsList;
            }
        }
    }
}
