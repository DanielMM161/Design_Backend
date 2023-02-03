using Design.Models;
using Design.Services;

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

  }

}