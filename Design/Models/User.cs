namespace Design.Models
{
  public class User 
  {
     public int id { get; set;}
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Created { get; set; }
    public List<Project> Projects { get; set; }
    public List<ToDo> Tasks { get; set; }

    public User(string name, string email, string password) 
    {
      Created = DateTime.Now.ToString();
      Name = name;
      Email = email;
      Password = password;
      Projects = new List<Project>();
      Tasks = new List<ToDo>();
    }
  }
}