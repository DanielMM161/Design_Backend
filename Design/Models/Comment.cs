namespace Design.Models
{
  public class Comment
  {
    public int Id { get; }
    public string Description { get; set; }
    public string Created { get; }
    public int UserId { get; }
    public int ToDoId { get; }

    public Comment(int id, string description, int userId, int toDoiId)
    {
      Id = id;
      Description = description;
      Created = DateTime.Now.ToString();
      UserId = userId;
      ToDoId = toDoiId;
    }
  }
}