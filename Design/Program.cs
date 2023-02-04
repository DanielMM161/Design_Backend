// See https://aka.ms/new-console-template for more information
using Design.Controllers;
using Design.Models;
using Design.Response;

UserController userController = new UserController();
string name = "Daniel Moteno";
string email = "daniel@test.com";
string password = "123456";
Console.WriteLine("----------- Sign Up User -----------");
Console.WriteLine($"Name: {name}, Email: {email}, Password: {password}");

Response<User?> user = userController.SignUp(name, email, password);
if(user.Data == null)
{
  Console.WriteLine($"----------- Status: {user.Status}, Message: {user.Message} -----------");
} else {
  Console.WriteLine($"----------- Status: {user.Status}, Message: {user.Message} -----------");
  Console.WriteLine($"{user.Data.Name} SignUp Correctly");
}



