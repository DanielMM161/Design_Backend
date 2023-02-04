using Design.Models;
using Design.Services.Interfaces;
using Design.DataBase;

namespace Design.Services
{
  public class UserRepository : IUserRepository
  {
    private List<User> _allUsers = DataBaseHelper.GetData<List<User>>("user");
    public List<User> GetAllUsers()
    {
      return _allUsers;
    }

    public User? GetUser(string email, string password)
    {
      List<User> findUser = _allUsers.FindAll(user => user.Email.Equals(email) && user.Password.Equals(password));
      if(findUser.Count > 0) {
        return findUser[0];
      }
      return null;
    }
    public bool CreateUser(User newUser)
    {
      newUser.id = _allUsers.Count();
      _allUsers.Add(newUser);
      return DataBaseHelper.WriteJsonData<List<User>>(_allUsers, "user");      
    }
    public bool UpdateUser(User user)
    {
      throw new NotImplementedException();
    }
    public bool DeleteUser(User user)
    {
      if(_allUsers.Remove(user)) {
        return DataBaseHelper.WriteJsonData<List<User>>(_allUsers, "user");
      }
      
      return false;
    }
  }
}