using Design.Models;
using Design.Services.Interfaces;

namespace Design.Services
{
  public class CommentRepository : ICommentRepository
  {
    public bool CreateComment(Comment newComment)
    {
      throw new NotImplementedException();
    }

    public bool DeleteComment(int commentId)
    {
      throw new NotImplementedException();
    }

    public List<Comment> GetCommentByToDo(int toDoId)
    {
      throw new NotImplementedException();
    }

    public bool UpdateComment(Comment commentId)
    {
      throw new NotImplementedException();
    }
  }
}