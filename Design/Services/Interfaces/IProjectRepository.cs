using Design.Models;

namespace Design.Services.Interfaces
{
  public interface IProjectRepository
  {
    public List<Project> GetAllProjects();
    public List<Project> GetAllProjectsByUser(int userId);
    public Project? GetProjectById(int projectId);
    public bool CreateProject(Project newProject);
    public bool UpdateProject(Project project);
    public bool DeleteProject(Project project);
  }
}