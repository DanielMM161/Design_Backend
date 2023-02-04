namespace Design.Models
{
  public class Project : IEquatable<Project>
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public User CreatedBy { get; set; }
    public List<User> Users { get; set; }
    public DateOnly Created { get; set; }
    public List<ToDo> Tasks { get; set; }

    public Project(int id, string name, User createdBy)
    {
      Id = id;
      Name = name;
      CreatedBy = createdBy;      
      Created = new DateOnly();
    }

    public override bool Equals(object obj)
    {
      if (obj == null) return false;
      Project objAsProject = obj as Project;
      if (objAsProject == null) return false;
      else return Equals(objAsProject);
    }

    public bool Equals(Project other)
    {
      if (other == null) return false;
      return (this.Id.Equals(other.Id));
    }

    public override string ToString()
    {
      return "ID: " + Id + "   Name: " + Name;
    }
  }
}