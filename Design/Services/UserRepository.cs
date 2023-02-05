using Design.Models;
using Design.Services.Interfaces;
using Design.DataBase;

namespace Design.Services
{
  public class UserRepository : IUserRepository
  {
    private static UserRepository _instance;
    private List<User> _allUsers = DataBaseHelper.GetData<List<User>>("users");

    private UserRepository() {}

    public static UserRepository GetInstance()
    {
      if(_instance == null)
      {
        _instance = new UserRepository();
      }
      return _instance;
    }

    public List<User> GetAllUsers()
    {
      return _allUsers;
    }

    public User? GetUser(string email, string password)
    {
      return _allUsers.Find(user => user.Email.Equals(email) && user.Password.Equals(password));
    }

    public User? GetUserById(int userId)
    {
      return _allUsers.Find(user => user.Id == userId);
    }

    public bool CreateUser(User newUser)
    {
      newUser.Id = _allUsers.Count();
      _allUsers.Add(newUser);
      return WriteDataBase();
    }

    public bool UpdateUser(User user)
    {
      throw new NotImplementedException();
    }
    
    public bool DeleteUser(User user)
    {
      if(_allUsers.Remove(user)) {
        return WriteDataBase();
      }
      return false;
    }

    private bool WriteDataBase()
    {
      return DataBaseHelper.WriteJsonData<List<User>>(_allUsers, "users");
    }
  }
}