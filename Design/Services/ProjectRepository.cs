using Design.DataBase;
using Design.Models;
using Design.Services.Interfaces;

namespace Design.Services
{
  public class ProjectRepository : IProjectRepository
  {
    private List<Project> _allProjects = DataBaseHelper.GetData<List<Project>>("projects");

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

      return project ?? null;
    }

    public bool CreateProject(Project newProject)
    {
      newProject.Id = _allProjects.Count();
      _allProjects.Add(newProject);
      return WriteDataBase();
    }

    public bool UpdateProject(Project project)
    {
      Project? result = _allProjects.FirstOrDefault(item => item.Id == project.Id);
      if(result != null)
      {
        result = project;
        return WriteDataBase();
      }
      return false;
    }
    
    public bool DeleteProject(Project project)
    {
      if(_allProjects.Remove(project)) {
        return WriteDataBase();
      }
      
      return false;
    }

    private bool WriteDataBase()
    {
      return DataBaseHelper.WriteJsonData<List<Project>>(_allProjects, "projects");
    }
  }
}