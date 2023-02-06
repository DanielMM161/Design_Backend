namespace Design.Models
{
  public class Project : IEquatable<Project>
  {
    public int Id { get; }
    public string Name { get; set; }    
    public List<int> UsersId { get; set; }
    public string Created { get; }

    public Project(int id, string name)
    {
      Id = Id;
      Name = name;      
      Created = DateTime.Now.ToString();
      UsersId = new List<int>();      
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