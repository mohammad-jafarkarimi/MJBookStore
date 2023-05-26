using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IBookRepository
    {
        public ServiceResult<Entities.Book> GetBookByName(string bookName);
        public List<ServiceResult<Book>> GetAllBooks();

    }
}
