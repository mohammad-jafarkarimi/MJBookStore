using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BasketDetails
    {
        public int BasketId { get; set; }
        public int BookID { get; set; }
        public decimal Price { get; set; }
        public int Number { get; set; }
    }
}
