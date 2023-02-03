using Design.Models;

namespace Design.Services.Interfaces
{
  public interface IUserRepository
  {
    public bool CreateUser(User newUser);
    public List<User> GetAllUsers();
    public User? GetUser(string email);    
    public List<User> InsertUser(User newUser);
    public bool UpdateUser(int id, string email);
    public bool DeleteUser(int id);
  }
}