using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data;
using Domain.Entities;
using Domain.Contracts;
using System.Runtime.CompilerServices;

namespace DataAccess
{
    public class UserRepository : IUserRepository
    {
        
        public ServiceResult<User> GetUserByUserName(string userName)
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
                    return new ServiceErrorResult<User>("No user with that username!");
                }
            }
        }

        public ServiceResult<User> SignUpUser(User user)
        {
            using (var _dataBaseContext = new DataBaseContext())
            {

                string command = $"INSERT INTO \"USER\" (FIRSTNAME, LASTNAME, USERNAME, PASSWORD) OUTPUT INSERTED.ID AS 'ID' values ('{user.FirstName}', '{user.LastName}', '{user.UserName}', '{user.Password}');";
                using var cmd = new SqlCommand(command, _dataBaseContext.connection);
                var reader = cmd.ExecuteScalar();

                user.Id = (Int32)reader;

                if ((Int32)reader > 0)
                {
                    return new ServiceSuccessResult<User>(user);

                }
                else
                {
                    return new ServiceErrorResult<User>("No data added to users!");
                }

            }
        }
    }
}
