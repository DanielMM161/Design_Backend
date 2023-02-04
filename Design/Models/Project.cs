namespace Design.Models
{
  public class Project
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public List<User> Users { get; set; }
    public DateOnly Created { get; set; }
    public List<ToDo> Tasks { get; set; }

    public Project(int id, string name, List<User> users)
    {
      Id = id;
      Name = name;
      Users = users;
      Created = new DateOnly();
    }
  }
}