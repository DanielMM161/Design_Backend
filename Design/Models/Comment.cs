namespace Design.Models
{
  public class Comment
  {
    public int Id { get; set; }
    public string Description { get; set; }
    public string Created { get; set; }
    public int UserId { get; set; }
    public int ToDoId { get; set; }

    public Comment(string description, int userId, int toDoiId)
    {      
      Description = description;
      Created = DateTime.Now.ToString();
      UserId = userId;
      ToDoId = toDoiId;
    }
  }
}