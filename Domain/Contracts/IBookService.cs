using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IBookService
    {
        List<ServiceResult<Entities.Book>> GetAllBook();
        ServiceResult<Entities.Book> GetBookByName(string bookName);

    }
}
