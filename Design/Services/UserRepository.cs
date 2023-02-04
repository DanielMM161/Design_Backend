using Design.Models;
using Design.Services.Interfaces;
using Design.DataBase;

namespace Design.Services
{
  public class UserRepository : IUserRepository
  {
    private List<User> _allUsers = DataBaseHelper.GetData<List<User>>("user");
    public bool CreateUser(User newUser)
    {
      _allUsers.Add(newUser);
      return DataBaseHelper.WriteJsonData<List<User>>(_allUsers, "user");      
    }

    public bool DeleteUser(int id)
    {
      throw new NotImplementedException();
    }

    public List<User> GetAllUsers()
    {
      return _allUsers;
    }

    public User? GetUser(string email)
    {
      List<User> findUser = _allUsers.FindAll(user => user.Email.Equals(email));
      if(findUser.Count > 0) {
        return findUser[0];
      }
      return null;
    }

    public List<User> InsertUser(User newUser)
    {
      throw new NotImplementedException();
    }

    public bool UpdateUser(int id, string email)
    {
      throw new NotImplementedException();
    }
  }
}