using Design.Models;
using Design.Response;
using Design.Services;
using Design.Utils;

namespace Design.Controllers
{
  public class CommentController
  {
    private CommentRepository _commentRepository;
    private UserRepository _userRepository;
    private ToDoRepository _toDoRepository;

    public CommentController()
    {
      _commentRepository = CommentRepository.GetInstance();
      _userRepository = UserRepository.GetInstance();
      _toDoRepository = ToDoRepository.GetInstance();
    }

    public Response<Comment> CreateComment(string description, int userId, int toDoId)
    {
      if(Helper.CheckEmptyFields(description))
      {
        return new Response<Comment>(null, "Description Can not be empty", Response.Status.error); 
      }

      List<User> allUsers = _userRepository.GetAllUsers();
      User? user = allUsers.Find(item => item.Id == userId);
      if(user == null)
      {
        return new Response<Comment>(null, "The User Not Exist, All comment must have a User asociated", Response.Status.error); 
      }

      List<ToDo> allToDo = _toDoRepository.GetAllToDo();
      ToDo? toDo = allToDo.Find(item => item.Id == toDoId);
      if(toDo == null)
      {
        return new Response<Comment>(null, "The ToDo Not Exist, All comment must have a ToDo asociated", Response.Status.error); 
      }

      Comment newComment = new Comment(description, userId, toDoId);
      if(_commentRepository.CreateComment(newComment))
      {
        return new Response<Comment>(newComment, "Comment Created Successfully", Response.Status.success); 
      }
      
      return new Response<Comment>(null, "Error Creating Comment", Response.Status.error); 
    }

    public Response<Comment> UpdateComment(string newDescription, int commentId)
    {
      Comment comment = _commentRepository.GetCommentById(commentId);
      if(comment == null)
      {
        return new Response<Comment>(null, "Comment No Exist Check Id", Response.Status.error); 
      }

      if(Helper.CheckEmptyFields(newDescription))
      {
        return new Response<Comment>(null, "Description Can Not Be Empty", Response.Status.error); 
      }

      comment.Description = newDescription;
      if(_commentRepository.UpdateComment(comment))
      {
        return new Response<Comment>(comment, "Comment Updated Successfully", Response.Status.success); 
      }

      return new Response<Comment>(null, "Error Updating Comment", Response.Status.error); 
    }

    public Response<bool> DeleteComment(int commentId)
    {
      Comment? comment = _commentRepository.GetCommentById(commentId);
      if(comment == null)
      {
        return new Response<bool>(false, "Comment No Exist Check Id", Response.Status.error); 
      }

      if(_commentRepository.DeleteComment(comment))
      {
        return new Response<bool>(true, "Comment Deleted Successfully", Response.Status.success); 
      }

      return new Response<bool>(false, "Error Deleting Comment", Response.Status.error); 
    }
  }
}