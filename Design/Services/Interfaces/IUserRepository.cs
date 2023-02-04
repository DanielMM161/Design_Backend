using Design.Models;

namespace Design.Services.Interfaces
{
  public interface IUserRepository
  {
    public List<User> GetAllUsers();
    public User? GetUser(string email, string password);    
    public bool CreateUser(User newUser);
    public bool UpdateUser(User user);
    public bool DeleteUser(User user);
  }
}