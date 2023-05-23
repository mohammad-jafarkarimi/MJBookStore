using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data;

namespace DataAccess
{
    public class UserRepository : IUserRepository
    {


        public ServiceResult<User> GetUser(string userName)
        {

            using (var _dataBaseContext = new DataBaseContext())
            {

                string command = $"SELECT * FROM \"User\" WHERE UserName = '{userName}';";
                using var cmd = new SqlCommand(command, _dataBaseContext.connection);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    User user = new User { Id = (Int32)reader[0], FirstName = reader[1].ToString(), LastName = reader[2].ToString(), UserName = reader[3].ToString(), Password = reader[4].ToString() };
                    return new ServiceSuccessResult<User>(user);
                }
                else 
                {
                    return new ServiceErrorResult<User>("No data with that username!");

                }


            }
        }
    }
}
