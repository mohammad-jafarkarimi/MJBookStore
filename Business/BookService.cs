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
    public class BookService : IBookService
    {
        private IBookRepository _bookDataAccess;
        public BookService(IBookRepository bookDataAccess)
        {
            _bookDataAccess = bookDataAccess;
        }

        public List<ServiceResult<Book>> GetAllBook()
        {
            return _bookDataAccess.GetAllBooks();
        }

        public ServiceResult<Book> GetBookByName(string bookName)
        {
            return _bookDataAccess.GetBookByName(bookName);
        }
    }
}
