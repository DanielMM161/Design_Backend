using Design.Models;
using Design.Response;
using Design.Services;
using Design.Utils;

namespace Design.Controllers
{
  public class ProjectController
  {
    private ProjectRepository _projectRepository;
    public Response<Project> createProject(Project newProject)
    {
      if(Helper.CheckEmptyFields(newProject.Name) || newProject is null || newProject.CreatedBy is null) {
        return new Response<Project>(null, "error", Response.Status.error); 
      }

      if(_projectRepository.CreateProject(newProject))
      {
        return new Response<Project>(newProject, "success", Response.Status.success); 
      }

      return new Response<Project>(null, "error", Response.Status.error); 
    }
    public Response<List<Project>> FetchAllProjectsByUser(int userId)    
    {
      List<Project> projectsByUser = _projectRepository.GetAllProjectsByUser(userId);
      if(projectsByUser.Any())
      {
        return new Response<List<Project>>(projectsByUser, "success", Response.Status.success);
      }
      return new Response<List<Project>>(null, "error", Response.Status.error);
    }
    public Response<Project> FetchProjectById(int projectId)
    {
      Project? project = _projectRepository.GetProjectById(projectId);
      if(project != null)
      {
        return new Response<Project>(project, "success", Response.Status.success);
      }

      return new Response<Project>(null, "error", Response.Status.error);
    }
    public Response<Project> UpdateProject(Project project)
    {
      if(_projectRepository.UpdateProject(project))
      {
        return new Response<Project>(project, "success", Response.Status.success);
      }

      return new Response<Project>(null, "error", Response.Status.error);
    }
  }
}