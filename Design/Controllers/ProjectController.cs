using Design.Models;
using Design.Response;
using Design.Services;
using Design.Utils;

namespace Design.Controllers
{
  public class ProjectController
  {
    private ProjectRepository _projectRepository;
    private ToDoRepository _toDoRepository;
    private CommentRepository _commentRepository;

    public ProjectController()
    {
      _projectRepository = ProjectRepository.GetInstance();
      _toDoRepository = ToDoRepository.GetInstance();
      _commentRepository = CommentRepository.GetInstance();
    }
    
    /** Post */
    public Response<Project> CreateProject(string projectName, int userId)
    {
      List<Project> allProjects = _projectRepository.GetAllProjects();
      if(allProjects.Any(item => item.Name.Equals(projectName)))
      {
        return new Response<Project>(null, "ProjectName Already Exist", Response.Status.error); 
      }

      if(Helper.CheckEmptyFields(projectName)) {
        return new Response<Project>(null, "ProjectName Can Not Be Empty", Response.Status.error); 
      }

      Project newProject = new Project(projectName);      
      newProject.UsersId.Add(userId);
      if(_projectRepository.CreateProject(newProject))
      {
        return new Response<Project>(newProject, "Project Created Successfully", Response.Status.success); 
      }

      return new Response<Project>(null, "Error Creating Project", Response.Status.error); 
    }

    /** Get */
    public Response<List<Project>> FetchAllProjectsByUser(int userId)    
    {
      List<Project> projectsByUser = _projectRepository.GetAllProjectsByUser(userId);
      if(projectsByUser.Any())
      {
        return new Response<List<Project>>(projectsByUser, "Success", Response.Status.success);
      }

      return new Response<List<Project>>(null, "Error Fetching Project By User", Response.Status.error);
    }
    
    /** Get */
    public Response<Project> FetchProjectById(int projectId)
    {
      Project? project = _projectRepository.GetProjectById(projectId);
      if(project != null)
      {
        return new Response<Project>(project, "Success", Response.Status.success);
      }

      return new Response<Project>(null, "Error Fetching Project By Id", Response.Status.error);
    }

    /** Put */
    public Response<Project> UpdateProject(Project project)
    {
      if(_projectRepository.UpdateProject(project))
      {
        return new Response<Project>(project, "Project Updated Successfully", Response.Status.success);
      }

      return new Response<Project>(null, "Error Updating Project", Response.Status.error);
    }

    /** Delete */
    public Response<bool> DeleteProject(int projectId)
    {
      Project? project = _projectRepository.GetProjectById(projectId);
      if(project == null)
      {
        return new Response<bool>(false, "Project Not Exist", Response.Status.error);
      }

      if(_projectRepository.DeleteProject(project))
      {
        // Deleting in Cascade
        DeleteProjectTaskComment(projectId);
        return new Response<bool>(false, "Project Deleted Successfully", Response.Status.success);
      }

      return new Response<bool>(false, "Error Deleting Project", Response.Status.error);
    }

    private void DeleteProjectTaskComment(int projectId)
    {
      List<ToDo> projectToDos = _toDoRepository.GetTodoByProject(projectId);
      foreach(var todo in projectToDos)
      {
        DeleteCommentTask(todo.Id);
        _toDoRepository.DeleteTodo(todo);
      }
    }

    private void DeleteCommentTask(int toDoId)
    {
      List<Comment> commentToDo = _commentRepository.GetCommentByToDo(toDoId);
      foreach(var comment in commentToDo)
      {
        _commentRepository.DeleteComment(comment);
      }
    }
  }
}