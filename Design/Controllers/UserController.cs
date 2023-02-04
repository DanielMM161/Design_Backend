using Design.Models;
using Design.Response;
using Design.Services;
using Design.Utils;

namespace Design.Controllers
{
  public class UserController
  {
    private UserRepository _userRepository;

    public UserController() 
    {
      _userRepository = new UserRepository();
    }
    public List<User> GetAllUsers()
    {
      return _userRepository.GetAllUsers();
    }
    public Response<User> SignUp(string name, string email, string password)
    {
      if(Helper.CheckEmptyFields(name, email, password)) {
        return new Response<User>(null, "Empty Fields", Response.Status.error); 
      }

      User newUser = new User(name, email, password); 
      if(_userRepository.CreateUser(newUser)) {
        return new Response<User>(newUser, "success", Design.Response.Status.success);
      }

      return new Response<User>(null, "error", Response.Status.error);      
    }

    public Response<User> Login(string email, string password)
    {
      User? user = _userRepository.GetUser(email, password);
      if(user != null) {
        return new Response<User>(user, "success", Response.Status.success);
      }

      return new Response<User>(null, "error", Response.Status.error);
    }
  }

}