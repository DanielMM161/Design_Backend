namespace Design.Models
{
  public enum Status
  {
    open,
    inProgress,
    resolved,
    closed
  }
  public class ToDo
  {
    public int Id { get; }
    public int ProjectId { get; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string DueDate { get; set; }
    public string Created { get; }
    public Status Status { get; set; }
    public List<int> UsersId { get; set; }    

    public ToDo(int id, int projectId, string title, string description)
    {
      Id = id;
      ProjectId = projectId;
      Title = title;
      Description = description;
      Created = DateTime.Now.ToString();
      Status = Status.open;
      UsersId = new List<int>();      
    }
  }
}