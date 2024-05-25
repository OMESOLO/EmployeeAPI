using EmployeeAPI.Data;
using EmployeeAPI.Entity;
using EmployeeAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IProjectService _projectService;

        public ProjectController(DataContext context, IProjectService projectService)
        {
            _context = context;
            _projectService = projectService;
        }

        [HttpGet("GetProject")]
        public async Task<ActionResult<List<object>>> GetProject()
        {
            var result = await _projectService.GetProjectList();
            return Ok(result);
        }

        [HttpPost("AddProject")]
        public async Task<ActionResult<Project>> AddProject(Project project)
        {
            var addProject = await _projectService.AddProject(project);
            return Ok(addProject);
        }

        [HttpDelete("DeleteProject")]
        public async Task<ActionResult<Project>> DeleteProject(int id)
        {
            var deletedProject = await _projectService.DeleteProject(id);
            if (deletedProject == null)
            {
                return NotFound();
            }
            return Ok(deletedProject);
        }

        [HttpGet("SearchProject")]
        public async Task<ActionResult<List<object>>> SearchProjects(string searchpro)
        {
            var result = await _projectService.SearchProjects(searchpro);
            return Ok(result);
        }

        [HttpPut("UpdateProject")]
        public async Task<ActionResult<Project>> UpdateProject(Project UpdateProj)
        {
            var updatedProject = await _projectService.UpdateProject(UpdateProj);
            if (updatedProject == null)
            {
                return NotFound();
            }

            return Ok(updatedProject);
        }
    }
}
