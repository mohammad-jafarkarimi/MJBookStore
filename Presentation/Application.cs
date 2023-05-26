using Domain.Contracts;
using Domain.Entities;
using Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    internal class Application : IApplication
    {

        private readonly IUserService _userService;
        private readonly IBookService _bookService;
        private readonly IBasketService _basketService;
        private readonly IBasketDetailsService _basketDetailsService;

        public Application(IUserService userService, IBookService bookService, IBasketService basketService, IBasketDetailsService basketDetailsService)
        {
            this._userService = userService;
            this._bookService = bookService;
            this._basketService = basketService;
            this._basketDetailsService = basketDetailsService;
        }
        public void Run()
        {
            ServiceResult<User> theUser;

            while (true)
            {
                Console.WriteLine("enter [1] to sign in, [2] to sign up");
                string enteredOption = Console.ReadLine();
                if (enteredOption == 1.ToString())
                {
                    Console.WriteLine("Please enter your UserName: (I check nothing, please be human and type correctly!");
                    string enteredUserName = Console.ReadLine();

                    theUser = _userService.GetUserByUserName(enteredUserName);
                    if (theUser.IsSuccessfull)
                    {
                        Console.WriteLine(theUser.Result.FirstName);

                        Console.WriteLine("Please enter your Password: (I check nothing, please be human and type correctly!");
                        string enteredPassword = Console.ReadLine();

                        if (theUser.Result.Password == enteredPassword)
                        {
                            Console.WriteLine($"Success! You are logged in as '{enteredUserName}'\n");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("incorrect password!!!");
                        }
                    }
                    else
                    {
                        Console.WriteLine(theUser.ErrorMessage);
                    }

                }

                if (enteredOption == 2.ToString())
                {
                    Console.WriteLine("Please enter your FirstName: (I check nothing, please be human and type correctly!");
                    string enteredFirstName = Console.ReadLine();
                    Console.WriteLine("Please enter your LastName: (I check nothing, please be human and type correctly!");
                    string enteredLastName = Console.ReadLine();
                    Console.WriteLine("Please enter your UserName: (I check nothing, please be human and type correctly!");
                    string enteredUserName = Console.ReadLine();
                    Console.WriteLine("Please enter your Password: (I check nothing, please be human and type correctly!");
                    string enteredPassword = Console.ReadLine();

                    var user = new User { FirstName = enteredFirstName, LastName = enteredLastName, UserName = enteredUserName, Password = enteredPassword };
                    theUser = _userService.SignUpUser(user);

                    if (theUser.IsSuccessfull)
                    {
                        Console.WriteLine($"Success! You are logged in as '{enteredUserName}'\n");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Failed. Try again!");
                    }
                }

            }

            while (true)
            {
                Console.WriteLine("enter [1] to add books, [2] to finalize buy");
                string enteredOption = Console.ReadLine();
                if (enteredOption == 1.ToString())
                {
                    Console.Clear();
                    _bookService.GetAllBook().ForEach((_theBook) => Console.WriteLine(_theBook.Result.Name + "    | Price:   " + _theBook.Result.Price + "$"));


                    Basket basket = new Basket() { OrderDate = DateTime.Today.ToShortDateString(), UserID = theUser.Result.Id };
                    _basketService.AddBasketToDataBase(basket, theUser.Result);


                    while (true)
                    {
                        Console.WriteLine("enter the name of the book you want: or [1] to exit!");
                        string enteredBookName = Console.ReadLine();

                        if (enteredBookName == 1.ToString())
                        {
                            break;
                        }
                        else
                        {
                            var theResult = _bookService.GetBookByName(enteredBookName);


                            if (theResult.IsSuccessfull)
                            {
                                _basketDetailsService.AddBasketDetailsToDataBase(basket, theResult.Result);

                            }
                            else
                            {
                                Console.WriteLine(theResult.ErrorMessage);

                            }
                        }
                    }

                }


                else if (enteredOption == 2.ToString())
                {
                    var basketDetailsList = new List<ServiceResult<BasketDetails>>();
                    basketDetailsList = _userService.CheckOut(theUser.Result);
                    Console.WriteLine("you have bought these book IDs with these prices: ");
                    basketDetailsList.ForEach((basketDetails) => Console.WriteLine("Book ID: "+ basketDetails.Result.BookID + "    |    Price: " + basketDetails.Result.Price + " $"));
                    Console.WriteLine("Wish you a good day! bye bye :) ");
                    break;
                }
            }


            Console.WriteLine("BYE BYE");


        }
    }
}
