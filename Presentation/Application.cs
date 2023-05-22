using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    internal class Application : IApplication
    {
        private readonly IGetUserService signInService;
        //private readonly IPaymentService paymentService;
        public Application(IGetUserService signInService)
        {
            this.signInService = signInService;
        }
        public void Run()
        {

        }
    }
}
