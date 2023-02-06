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
    private ToDoRepository _toDoRepository;
    private CommentRepository _commentRepository;
    
    public UserController() 
    {
      _userRepository = UserRepository.GetInstance();
      _projectRepository = ProjectRepository.GetInstance();
      _toDoRepository = ToDoRepository.GetInstance();
      _commentRepository = CommentRepository.GetInstance();
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
        // Deleting Cascade
        DeleteUserIdProjects(userId);
        DeleteUserIdToDos(userId);
        DeleteUserComments(userId);
        return new Response<bool>(true, "User Deleted Successfully", Response.Status.success);
      }

      return new Response<bool>(true, "Error Deleting User", Response.Status.error);
    }

    private void DeleteUserIdProjects(int userId)
    {
      List<Project> userProjects = _projectRepository.GetAllProjectsByUser(userId);
      foreach(var project in userProjects)
      {
        project.UsersId.Remove(userId);
        _projectRepository.UpdateProject(project);
      }
    }

    private void DeleteUserIdToDos(int userId)
    {
      List<ToDo> userToDos = _toDoRepository.GetTodoByUser(userId);
      foreach(var toDo in userToDos)
      {
        toDo.UsersId.Remove(userId);
        _toDoRepository.UpdateToDo(toDo);
      }
    }

    private void DeleteUserComments(int userId)
    {
      List<Comment> userComments = _commentRepository.GetCommentByUser(userId);
      foreach(var comment in userComments)
      {
        _commentRepository.DeleteComment(comment);
      }
    }
  }

}