using EmployeeAPI.Entity;
using EmployeeAPI.Repository;

namespace EmployeeAPI.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<object>> GetProjectList()
        {
            var projectList = await _projectRepository.GetProjectList();
            return projectList;
            
        }

        public async Task<Project> AddProject(Project project)
        {
            var addproject = await _projectRepository.AddProject(project);
            return addproject;
        }

        public async Task<Project> DeleteProject(int id)
        {
            var deletedProject = await _projectRepository.DeleteProject(id);
            return deletedProject;
        }

        public async Task<List<object>> SearchProjects(string searchpro)
        {
            var result = await _projectRepository.SearchProjects(searchpro);
            return result;
        }

        public async Task<Project> UpdateProject(Project UpdateProj)
        {
            var result = await _projectRepository.UpdateProject(UpdateProj);
            return result;
        }
    }
}
