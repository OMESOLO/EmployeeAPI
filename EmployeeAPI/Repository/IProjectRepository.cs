using EmployeeAPI.Entity;

namespace EmployeeAPI.Repository
{
    public interface IProjectRepository
    {
        Task<List<object>> GetProjectList();
        Task<IEnumerable<Project>> AddProjects(IEnumerable<Project> projects);
        Task<Project> DeleteProject(int id);
        Task<List<object>> SearchProjects(string searchpro);
        Task<Project> UpdateProject(Project UpdateProj);
    }
}
