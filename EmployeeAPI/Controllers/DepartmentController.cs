using EmployeeAPI.Data;
using EmployeeAPI.Entity;
using EmployeeAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IDepartmentService _departmentService;

        public DepartmentController(DataContext context, IDepartmentService departmentService)
        {
            _context = context;
            _departmentService = departmentService;
        }

        [HttpGet("GetDepartment")]
        public async Task<ActionResult<List<object>>> GetDepartment()
        {
            var result = await _departmentService.GetDepartmentList();
            return Ok(result);
        }

        [HttpGet("GetDepartmentID")]

        public async Task<ActionResult<List<object>>> GetDepartmentID(int id)
        {
            var result = await _departmentService.GetDepartmentID(id);
            return Ok(result);
        }

        [HttpDelete("DeleteDepartment/{departmentID}")]
        public async Task<ActionResult<Department>> DeleteDepartment(int departmentID)
        {
            var deletedDepartment = await _departmentService.DeleteDepartment(departmentID);
            if (deletedDepartment == null)
            {
                return NotFound();
            }
            return Ok(deletedDepartment);
        }



        [HttpGet("SearchDepartment")]
        public async Task<ActionResult<List<object>>> SearchDepartment(string searchdep)
        {
            var result = await _departmentService.SearchDepartment(searchdep);
            return result.Count > 0 ? Ok(result) : NotFound("Department Not Found");
        }

        [HttpPut("UpdateDepartment/{id}")]
        public async Task<ActionResult<Department>> UpdateDepartment(int id, Department department)
        {
            if (id != department.DepartmentID)
            {
                return BadRequest();
            }

            var updatedDepartment = await _departmentService.UpdateDepartment(id, department);
            if (updatedDepartment == null)
            {
                return NotFound();
            }

            return Ok(updatedDepartment);
        }



        [HttpPost("AddDepartment")]
        public async Task<ActionResult<Department>> AddDepartment(Department addDepartment)
        {
            

            await _departmentService.AddDepartment(addDepartment);
            return Ok("Successfully");
        }
       
        
    }
}
