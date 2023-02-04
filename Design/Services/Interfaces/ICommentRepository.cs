using Design.Models;

namespace Design.Services.Interfaces
{
  public interface ICommentRepository
  {
    public List<Comment> GetCommentByToDo(int toDoId);    
    public bool CreateComment(Comment newComment);
    public bool UpdateComment(Comment commentId);
    public bool DeleteComment(int commentId);
  }
}