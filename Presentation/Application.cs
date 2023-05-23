using Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    internal class Application : IApplication
    {
        private readonly IUserService getUserService;
        public Application(IUserService getUserService)
        {
            this.getUserService = getUserService;
        }
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("enter 1 to sign in, 2 to sign up");
                string enteredOption = Console.ReadLine();
                if (enteredOption == 1.ToString())
                {
                    Console.WriteLine("Please enter your UserName: (I check nothing, please be human and type correctly!");
                    string enteredUserName = Console.ReadLine();

                    var userResult = getUserService.GetUserByUserName(enteredUserName);
                    if (userResult.IsSuccessfull)
                    {
                        Console.WriteLine(userResult.Result.FirstName);

                        Console.WriteLine("Please enter your Password: (I check nothing, please be human and type correctly!");
                        string enteredPassword = Console.ReadLine();

                        if (userResult.Result.Password == enteredPassword)
                        {
                            Console.WriteLine($"Success! You are logged in as '{enteredUserName}'\n");

                        }
                        else
                        {
                            Console.WriteLine("incorrect password!!!");
                        }
                    }
                    else
                    {
                        Console.WriteLine(userResult.ErrorMessage);
                    }









                }

            }
        }
    }
}
