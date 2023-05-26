using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Business;
using DataAccess;
using Domain.Contracts;

namespace Presentation
{
    public static class DependencyRegister
    {
        public static ServiceProvider Register()
        {
            var servicecollection = new ServiceCollection();
            servicecollection.AddSingleton<IApplication, Application>();
            servicecollection.AddTransient<IUserService, UserService>();
            servicecollection.AddTransient<IUserRepository, UserRepository>();
            servicecollection.AddTransient<IBookRepository, BookRepository>();
            servicecollection.AddTransient<IBookService, BookService>();
            servicecollection.AddTransient<IBasketService, BasketService>();
            servicecollection.AddTransient<IBasketRepository, BasketRepository>();
            servicecollection.AddTransient<IBasketDetailsRepository, BasketDetailsRepository>();
            servicecollection.AddTransient<IBasketDetailsService, BasketDetailsService>();
            //servicecollection.AddTransient<ISignUpService, SignUpService>();

            return servicecollection.BuildServiceProvider();
        }
    }
}
