using Design.Models;
using Design.Services.Interfaces;

namespace Design.Services
{
  public class ToDoRepository : IToDoRepository
  {
    public bool CreateTodo(ToDo newToDo)
    {
      throw new NotImplementedException();
    }

    public bool DeleteTodo(int toDoId)
    {
      throw new NotImplementedException();
    }

    public ToDo GetToDoById(int todoId)
    {
      throw new NotImplementedException();
    }

    public List<ToDo> GetTodoByProject(int projectId)
    {
      throw new NotImplementedException();
    }

    public bool UpdateToDo(ToDo toDo)
    {
      throw new NotImplementedException();
    }
  }
}