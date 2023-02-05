using Design.Models;

namespace Design.Services.Interfaces
{
  public interface IToDoRepository
  { 
    public List<ToDo> GetAllToDo();   
    public List<ToDo> GetTodoByProject(int projectId);
    public ToDo GetToDoById(int todoId);
    public bool CreateTodo(ToDo newToDo);
    public bool UpdateToDo(ToDo toDo);
    public bool DeleteTodo(ToDo toDo);
  }
}