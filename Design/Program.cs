// See https://aka.ms/new-console-template for more information
using Design.Controllers;

UserController userController = new UserController();
Console.WriteLine($"Fetch All Users. {userController.GetAllUsers().Count}");

