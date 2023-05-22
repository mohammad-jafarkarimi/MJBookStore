// See https://aka.ms/new-console-template for more information
using Domain;
using Microsoft.Extensions.DependencyInjection;
using Presentation;

Console.WriteLine("Hello, World!");



var serviceProvider = DependencyRegister.Register();
var app = serviceProvider.GetRequiredService<IApplication>();
app.Run();
