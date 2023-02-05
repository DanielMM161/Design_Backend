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
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateOnly DueDate { get; set; }
    public string Created { get; set; }
    public Status Status { get; set; }
    public List<User> Users { get; set; }
    public List<Comment> Comments { get; set; }

    public ToDo(int projectId, string title, string description)
    {      
      ProjectId = projectId;
      Title = title;
      Description = description;
      Created = DateTime.Now.ToString();
      Status = Status.open;
    }
  }
}