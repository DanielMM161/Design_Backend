using Design.Models;

namespace Design.Services.Interfaces
{
  public interface ICommentRepository
  {
    public List<Comment> GetAllComments();  

    public Comment GetCommentById(int commentId);

    public List<Comment> GetCommentByToDo(int toDoId);

    public List<Comment> GetCommentByUser(int userId);

    public bool CreateComment(Comment newComment);

    public bool UpdateComment(Comment comment);

    public bool DeleteComment(Comment comment);
  }
}