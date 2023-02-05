using Design.Services;

namespace Design.Controllers
{
  public class CommentController
  {
    private CommentRepository _CommentRepository;

    public CommentController()
    {
      _CommentRepository = new CommentRepository();
    }
  }
}