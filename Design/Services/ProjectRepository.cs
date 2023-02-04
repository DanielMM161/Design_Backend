using Design.DataBase;
using Design.Models;
using Design.Services.Interfaces;

namespace Design.Services
{
  public class ProjectRepository : IProjectRepository
  {
    private List<Project> _allProjects = DataBaseHelper.GetData<List<Project>>("project");
    public List<Project> GetAllProjectsByUser(int userId)
    {
      return _allProjects.Where(project => project.Users.Any(user => user.id == userId)).ToList();      
    }
    public Project? GetProjectById(int projectId)
    {
      Project? project = _allProjects.Find(
      delegate(Project project)
      {
        return project.Id == projectId;
      });
      if(project != null)
      {
        return project;
      }
      return null;
    }
    public bool CreateProject(Project newProject)
    {
      newProject.Id = _allProjects.Count();
      _allProjects.Add(newProject);
      return DataBaseHelper.WriteJsonData<List<Project>>(_allProjects, "project");
    }
    public bool UpdateProject(Project project)
    {
      Project? result = _allProjects.FirstOrDefault(item => item.Id == project.Id);
      if(result != null)
      {
        result = project;
        return DataBaseHelper.WriteJsonData<List<Project>>(_allProjects, "project");
      }
      return false;
    }
    public bool DeleteProject(Project project)
    {
      if(_allProjects.Remove(project)) {
        return DataBaseHelper.WriteJsonData<List<Project>>(_allProjects, "project");
      }
      
      return false;
    }
  }
}