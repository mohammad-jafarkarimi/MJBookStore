// See https://aka.ms/new-console-template for more information
using Domain.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Presentation;



var serviceProvider = Presentation.DependencyRegister.Register();
var app = serviceProvider.GetRequiredService<IApplication>();
app.Run();
