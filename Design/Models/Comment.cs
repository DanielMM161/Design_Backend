namespace Design.Models
{
  public class Comment
  {
    public int Id { get; set; }
    public string Description { get; set; }
    public DateOnly Created { get; set; }
    public List<User> Users { get; set; }
    public ToDo Task { get; set; }

    public Comment(int id, string description, List<User> users, ToDo task)
    {
      Id = id;
      Description = description;
      Created = new DateOnly();
      Users = users;
      Task = task;
    }
  }
}