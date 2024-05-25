using EmployeeAPI.Entity;

namespace EmployeeAPI.Service
{
    public interface IProjectService
    {
        Task<List<object>> GetProjectList();
        Task<Project> AddProject(Project project);
        Task<Project> DeleteProject(int id);
        Task<List<object>> SearchProjects(string searchpro);
        Task<Project> UpdateProject(Project UpdateProj);
    }
}
