using Design.Models;

namespace Design.Services.Interfaces
{
  public interface IProjectRepository
  {
    public List<Project> GetAllProjectsByUser(int userId);
    public Project GetProjectById(int projectId);
    public bool CreateProject(Project newProject);
    public bool UpdateProject(Project projectId);
    public bool DeleteProject(int projectId);
  }
}