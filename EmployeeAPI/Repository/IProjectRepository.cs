using EmployeeAPI.Entity;

namespace EmployeeAPI.Repository
{
    public interface IProjectRepository
    {
        Task<List<object>> GetProjectList();
        Task<Project> AddProject(Project project);
        Task<Project> DeleteProject(int id);
        Task<List<object>> SearchProjects(string searchpro);
        Task<Project> UpdateProject(Project UpdateProj);
    }
}
