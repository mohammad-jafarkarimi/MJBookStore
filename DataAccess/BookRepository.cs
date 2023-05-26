using Domain;
using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookRepository : IBookRepository
    {
        public ServiceResult<Book> GetBookByName(string bookName)
        {
            using (var _dataBaseContext = new DataBaseContext())
            {

                string command = $"SELECT * FROM BOOK WHERE Name = '{bookName}';";
                using var cmd = new SqlCommand(command, _dataBaseContext.connection);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Book book = new Book { Id = (Int32)reader[0], Name = reader[1].ToString(), Price = (decimal)reader[2] };
                    return new ServiceSuccessResult<Book>(book);
                }
                else
                {
                    return new ServiceErrorResult<Book>("No book with that name!");
                }
            }
        }

        public List<ServiceResult<Book>> GetAllBooks()
        {
            var bookList = new List<ServiceResult<Book>>();
            using (var _dataBaseContext = new DataBaseContext())
            {

                string command = $"SELECT * FROM BOOK;";
                using var cmd = new SqlCommand(command, _dataBaseContext.connection);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Book book = new Book { Id = (Int32)reader[0], Name = reader[1].ToString(), Price = (decimal)reader[2] };
                    bookList.Add(new ServiceSuccessResult<Book>(book));
                }

                return bookList;
            }
        }

    }
}
