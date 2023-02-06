using Design.DataBase;
using Design.Models;
using Design.Services.Interfaces;

namespace Design.Services
{
  public class ToDoRepository : IToDoRepository
  {
    private static ToDoRepository _instance;
    private List<ToDo> _allToDo = DataBaseHelper.GetData<List<ToDo>>("todos");

    private ToDoRepository() {}

    public static ToDoRepository GetInstance()
    {
      if(_instance == null)
      {
        _instance = new ToDoRepository();
      }
      return _instance;
    }

    public List<ToDo> GetAllToDo()
    {
      return _allToDo;
    }

    public ToDo? GetToDoById(int todoId)
    {
      ToDo? task = _allToDo.Find(
      delegate(ToDo task)
      {
        return task.Id == todoId;
      }
      );
      return task ?? null;
    }
    
    public List<ToDo> GetTodoByProject(int projectId)
    {
      return _allToDo.Where(toDo => toDo.ProjectId == projectId).ToList();
    }

    public List<ToDo> GetTodoByUser(int userId)
    {
      return _allToDo.Where(toDo => toDo.UsersId.Any(value => value == userId)).ToList();
    }

    public bool CreateTodo(ToDo newToDo)
    {
      newToDo.Id = _allToDo.Count();
      _allToDo.Add(newToDo);
      return WriteDataBase();
    }

    public bool UpdateToDo(ToDo toDo)
    {
      ToDo? updatedToDo = _allToDo.FirstOrDefault(item => item.Id == toDo.Id);
      if(updatedToDo != null)
      {
        updatedToDo = toDo;
        return WriteDataBase();
      }
      return false;
    }

    public bool DeleteTodo(ToDo toDo)
    {
      if(_allToDo.Remove(toDo))
      {
        return WriteDataBase();
      }
      return false;
    }

    private bool WriteDataBase()
    {
      return DataBaseHelper.WriteJsonData<List<ToDo>>(_allToDo, "todos");
    }
  }
}