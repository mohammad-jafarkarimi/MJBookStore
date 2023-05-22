using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    internal class ServiceSuccessResult<T> : ServiceResult<T>
    {
        public ServiceSuccessResult(T result)
        {
            this.IsSuccessfull = true;
            this.Result = result;
        }
    }
}
