using Design.Models;
using Design.DataBase;
using Design.Services.Interfaces;

namespace Design.Services
{
  public class CommentRepository : ICommentRepository
  {
    private List<Comment> _allComments = DataBaseHelper.GetData<List<Comment>>("comments");

    public List<Comment> GetAllComments()
    {
      return _allComments;
    }

    public List<Comment> GetCommentByToDo(int toDoId)
    {
      return _allComments.Where(item => item.ToDoId == toDoId).ToList();
    }

    public List<Comment> GetCommentByUser(int userId)
    {
      return _allComments.Where(item => item.UserId == userId).ToList();
    }

    public bool CreateComment(Comment newComment)
    {
      newComment.Id = _allComments.Count();
      _allComments.Add(newComment);
      return WriteDataBase();
    }

    public bool UpdateComment(Comment comment)
    {
      Comment? updateComment = _allComments.FirstOrDefault(item => item.Id == comment.Id);
      if(updateComment != null)
      {
        updateComment = comment;
        return WriteDataBase();
      }
      return false;
    }

    public bool DeleteComment(Comment comment)
    {
      if(_allComments.Remove(comment))
      {
        return WriteDataBase();
      }
      return false;
    }

    private bool WriteDataBase()
    {
      return DataBaseHelper.WriteJsonData<List<Comment>>(_allComments, "comments");
    }
  }
}