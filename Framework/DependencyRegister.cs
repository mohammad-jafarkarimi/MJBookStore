using static System.Net.Mime.MediaTypeNames;
using System;
using Microsoft.Extensions.DependencyInjection;
using Domain;
using Business;
using DataAccess;

// -----------------------------------------------------------------
// -----------------------------------------------------------------
// -----------------------------------------------------------------

// The Framework layer is not working yet. I had a problem with injecting
// The 'Application' service because it is located in the Presentation
// layer and here I don't have access to that layer! I must ask Sina
// about it. 

// -----------------------------------------------------------------
// -----------------------------------------------------------------
// -----------------------------------------------------------------
namespace Framework
{
    public static class DependencyRegister
    {
        public static ServiceProvider Register()
        {
            var servicecollection = new ServiceCollection();
            //servicecollection.AddSingleton<IApplication, Application>();
            servicecollection.AddTransient<IGetUserService, GetUserService>();
            servicecollection.AddTransient<IUserDataAccess, UserDataAccess>();
            //servicecollection.AddTransient<ISignUpService, SignUpService>();

            return servicecollection.BuildServiceProvider();
        }
    }
}