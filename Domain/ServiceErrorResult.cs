using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ServiceErrorResult<T> : ServiceResult<T>
    {
        public ServiceErrorResult(string errorMessage)
        {
            this.IsSuccessfull = false;
            this.ErrorMessage = errorMessage;
        }
    }
}
