using Design.Models;
using Design.Response;
using Design.Services;
using Design.Utils;

namespace Design.Controllers
{
  public class ToDoController
  {
    private ToDoRepository _toDoRepository;

    public ToDoController()
    {
      _toDoRepository = new ToDoRepository();
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

      if(!_toDoRepository.GetAllToDo().Any(item => item.Title.Trim().ToLower().Equals(title.Trim().ToLower())))
      {
        return new Response<ToDo>(null, "ToDo Already Created", Response.Status.error);
      }

      ToDo newToDo = new ToDo(projectId, title, description);
      if(_toDoRepository.CreateTodo(newToDo))
      {
        return new Response<ToDo>(newToDo, "ToDo Created Successfully", Response.Status.success);
      }

      return new Response<ToDo>(null, "Error Inserting Creating ToDo", Response.Status.error);
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