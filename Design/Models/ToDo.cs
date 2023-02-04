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
    public string Title { get; set; }
    public string Description { get; set; }
    public DateOnly DueDate { get; set; }
    public DateOnly Created { get; set; }
    public Status Status { get; set; }
    public List<User> Users { get; set; }
    public List<Comment> Comments { get; set; }

    public ToDo(int id, string title, string description, DateOnly dueDate, List<User> users)
    {
      Id = id;
      Title = title;
      Description = description;
      Created = new DateOnly();
      Status = Status.open;
      DueDate = dueDate;
      Users = users;
    }
  }
}