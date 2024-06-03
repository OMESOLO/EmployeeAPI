using EmployeeAPI.Entity;

namespace EmployeeAPI.Service
{
    public interface IProjectService
    {
        Task<List<object>> GetProjectList();
        Task AddProjects(IEnumerable<Project> projects);
        Task<Project> DeleteProject(int id);
        Task<List<object>> SearchProjects(string searchpro);
        Task<Project> UpdateProject(Project UpdateProj);
    }
}
