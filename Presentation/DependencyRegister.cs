using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Domain;
using Business;

namespace Presentation
{
    public static class DependencyRegister
    {
        public static ServiceProvider Register()
        {
            var servicecollection = new ServiceCollection();
            servicecollection.AddSingleton<IApplication, Application>();
            servicecollection.AddTransient<IGetUserService, GetUserService>();
            //servicecollection.AddTransient<ISignUpService, SignUpService>();

            return servicecollection.BuildServiceProvider();
        }
    }
}
