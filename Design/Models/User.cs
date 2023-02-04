namespace Design.Models
{
  public class User 
  {
    public int id { get; set;}
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateOnly Created { get; set; }
    public List<Project> Projects { get; set; }
    public List<ToDo> Tasks { get; set; }

    public User(string name, string email, string password, List<Project> projects, List<ToDo> tasks) 
    {
      Created = new DateOnly();
      Name = name;
      Email = email;
      Password = password;
      Projects = projects;
      Tasks = tasks;
    }
  }
}