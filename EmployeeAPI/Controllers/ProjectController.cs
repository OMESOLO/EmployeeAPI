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
        public async Task<IActionResult> AddProjects([FromBody] IEnumerable<Project> projects)
        {
            if (projects == null || !projects.Any())
            {
                return BadRequest("Invalid input.");
            }

            await _projectService.AddProjects(projects);
            return Ok("Projects added successfully.");
        }

        [HttpDelete("DeleteProject/{projectId}")]
        public async Task<ActionResult<Project>> DeleteProject(int projectId)
        {
            var deletedProject = await _projectService.DeleteProject(projectId);
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
