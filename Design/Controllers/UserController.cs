using Design.Models;
using Design.Response;
using Design.Services;
using Design.Utils;

namespace Design.Controllers
{
  public class UserController
  {
    private UserRepository _userRepository;
    private ProjectRepository _projectRepository;    
    
    public UserController() 
    {
      _userRepository = UserRepository.GetInstance();
      _projectRepository = ProjectRepository.GetInstance();
    }

    public List<User> GetAllUsers()
    {
      return _userRepository.GetAllUsers();
    }
    
    /** Post */
    public Response<User> SignUp(string name, string email, string password)
    {
      if(Helper.CheckEmptyFields(name, email, password)) {
        return new Response<User>(null, "Empty Fields", Response.Status.error); 
      }

      User newUser = new User(name, email, password, false); 
      if(_userRepository.CreateUser(newUser)) {
        return new Response<User>(newUser, "SignUp Successfully", Design.Response.Status.success);
      }

      return new Response<User>(null, "Error Sing Up", Response.Status.error);      
    }

    /** Get */
    public Response<User> Login(string email, string password)
    {
      if(Helper.CheckEmptyFields(email, password))
      {
        return new Response<User>(null, "Empty Fields", Response.Status.error);
      }

      User? user = _userRepository.GetUser(email, password);
      if(user != null) {
        return new Response<User>(user, "Login Successfully", Response.Status.success);
      }

      return new Response<User>(null, "Error Login User Not Exist", Response.Status.error);
    }

    /** Delete */
    public Response<bool> DeleteUser(int userId)
    {
      User? user = _userRepository.GetUserById(userId);
      if(user == null)
      {
        return new Response<bool>(false, "User Not Exist", Response.Status.error);
      }

      if(_userRepository.DeleteUser(user))
      {
        return new Response<bool>(true, "User Deleted Successfully", Response.Status.success);
      }

      return new Response<bool>(true, "Error Deleting User", Response.Status.error);
    }
  }

}