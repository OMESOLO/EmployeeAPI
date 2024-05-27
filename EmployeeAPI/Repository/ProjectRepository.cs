using EmployeeAPI.Data;
using EmployeeAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _context;

        public ProjectRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<object>> GetProjectList()
        {
            var data = await (from proj in _context.Projects
                              join dept in _context.Departments on proj.DepartmentID equals dept.DepartmentID into projDept
                              from dept in projDept.DefaultIfEmpty()
                              select new
                              {
                                  proj.ProjectName,
                                  DepartmentName = dept != null ? dept.DepartmentName : "No Department",
                                  StartDate = proj.StartDate.HasValue ? proj.StartDate.Value.ToString("yyyy-MM-dd HH:mm") : null,
                                  EndDate = proj.EndDate.HasValue ? proj.EndDate.Value.ToString("yyyy-MM-dd HH:mm") : null
                              }).ToListAsync<object>();
            return data;
        }

        public async Task<Project> AddProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return null;
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<List<object>> SearchProjects(string searchpro)
        {
            var data = await (from proj in _context.Projects
                              join dept in _context.Departments on proj.DepartmentID equals dept.DepartmentID into projDept
                              from dept in projDept.DefaultIfEmpty()
                              where string.IsNullOrEmpty(searchpro)
                                    || proj.ProjectName.Contains(searchpro)
                                    || (dept != null && dept.DepartmentName.Contains(searchpro))
                              select new
                              {
                                  proj.ProjectName,
                                  Department = dept != null ? dept.DepartmentName : "No Department",
                                  StartDate = proj.StartDate.HasValue ? proj.StartDate.Value.ToString("yyyy-MM-dd HH:mm") : null,
                                  EndDate = proj.EndDate.HasValue ? proj.EndDate.Value.ToString("yyyy-MM-dd HH:mm") : null,
                              }).ToListAsync<object>();
            return data;
        }

        public async Task<Project> UpdateProject(Project UpdateProj)
        {
            var upproj = await _context.Projects.FindAsync(UpdateProj.ProjectID);
            if (upproj == null)
            {
                return null;
            }

            upproj.ProjectName = UpdateProj.ProjectName;
            upproj.DepartmentID = UpdateProj.DepartmentID;
            upproj.StartDate = UpdateProj.StartDate;
            upproj.EndDate = UpdateProj.EndDate;

            _context.Entry(upproj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return upproj;
        }
    }
}
