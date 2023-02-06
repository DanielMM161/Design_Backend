using Design.Models;
using Design.Response;
using Design.Services;
using Design.Utils;

namespace Design.Controllers
{
  public class ToDoController
  {
    private ToDoRepository _toDoRepository;
    private UserRepository _userRepository;    
    private CommentRepository _commentRepository;

    public ToDoController()
    {
      _toDoRepository = ToDoRepository.GetInstance();
      _userRepository = UserRepository.GetInstance();      
      _commentRepository = CommentRepository.GetInstance();

    }

    public Response<List<ToDo>> FetchToDoByProject(int projectId)
    {
      List<ToDo> toDo = _toDoRepository.GetTodoByProject(projectId);
      return new Response<List<ToDo>>(toDo, "Sucess", Response.Status.success);
    }

    public Response<ToDo> CreateToDo(int projectId, string title, string description)
    {
      if(Helper.CheckEmptyFields(title, description))
      {
        return new Response<ToDo>(null, "Not empty fields", Response.Status.error);
      }

      bool exist = _toDoRepository.GetAllToDo().Any(item => {
        bool exisTitle = item.Title.Trim().ToLower().Equals(title.Trim().ToLower());
        if(exisTitle && item.ProjectId == projectId)
        {
          return true;
        }
        return false;
      });
      
      if(exist)
      {
        return new Response<ToDo>(null, "ToDo Already Exist", Response.Status.error);
      }

      int id = _toDoRepository.GetAllToDo().Count();
      ToDo newToDo = new ToDo(id, projectId, title, description);
      if(_toDoRepository.CreateTodo(newToDo))
      {
        return new Response<ToDo>(newToDo, "ToDo Created Successfully", Response.Status.success);
      }

      return new Response<ToDo>(null, "Error Creating ToDo", Response.Status.error);
    }

    public Response<bool> AssignToDo(int userId, int todoId)
    {  
      User? user = _userRepository.GetUserById(userId);      
      if(user == null)
      {
        return new Response<bool>(false, "User Not Exist", Response.Status.error);
      }

      ToDo? todo = _toDoRepository.GetToDoById(todoId);      
      if(todo == null)
      {
        return new Response<bool>(false, "ToDo Not Exist", Response.Status.error);
      }

      foreach(var usersId in todo.UsersId)
      {        
        if(usersId == userId)
        {
          return new Response<bool>(false, "User Already Assigned", Response.Status.error);
        }
      }

      todo.UsersId.Add(userId);
      if(_toDoRepository.UpdateToDo(todo))
      {
        return new Response<bool>(true, "User Assigned Successfully", Response.Status.success);
      }

      return new Response<bool>(false, "Error Assigning User", Response.Status.error);
    }

    public Response<bool> DeleteToDo(int todoId)
    {
      ToDo? toDo = _toDoRepository.GetToDoById(todoId);
      if(toDo == null)
      {
        return new Response<bool>(false, "ToDo Not Found", Response.Status.error);
      }

      if(_toDoRepository.DeleteTodo(toDo))
      {
        // Deleting in Cascade
        List<Comment> allComments = _commentRepository.GetCommentByToDo(todoId);
        foreach(var coment in allComments)
        {
          _commentRepository.DeleteComment(coment);
        }
        return new Response<bool>(true, "ToDo Deleted Successfully", Response.Status.success);
      }

      return new Response<bool>(false, "Error Deleting ToDo", Response.Status.error);
    }

    public Response<ToDo> UpdateTodo(ToDo toDo)
    {
      if(_toDoRepository.UpdateToDo(toDo))
      {
        return new Response<ToDo>(toDo, "ToDo Updated Successfully", Response.Status.success);
      }

      return new Response<ToDo>(null, "Error Updating ToDo", Response.Status.error);
    }
  }
}