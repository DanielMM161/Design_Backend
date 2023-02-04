using Design.Models;
using Design.Services.Interfaces;

namespace Design.Services
{
  public class ProjectRepository : IProjectRepository
  {
    public bool CreateProject(Project newProject)
    {
      throw new NotImplementedException();
    }

    public bool DeleteProject(int projectId)
    {
      throw new NotImplementedException();
    }

    public List<Project> GetAllProjectsByUser(int userId)
    {
      throw new NotImplementedException();
    }

    public Project GetProjectById(int projectId)
    {
      throw new NotImplementedException();
    }

    public bool UpdateProject(Project projectId)
    {
      throw new NotImplementedException();
    }
  }
}