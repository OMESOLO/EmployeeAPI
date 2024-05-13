using EmployeeAPI.Data;
using EmployeeAPI.Entity;
using EmployeeAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(DataContext context, IEmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }

       

        [HttpGet("GetEmployee")]
        public async Task<ActionResult<List<object>>> GetEmployee()
        {
            var result = await _employeeService.GetEmployeeList();
            return Ok(result);
        }

        [HttpPost("AddEmployee")]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            var addedEmployee = await _employeeService.AddEmployee(employee);
            return Ok(addedEmployee);
        }

        [HttpDelete("DeleteEmployee")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int employeeId)
        {
            var deletedEmployee = await _employeeService.DeleteEmployee(employeeId);
            if (deletedEmployee == null)
            {
                return NotFound();
            }

            return Ok(deletedEmployee);
        }

        [HttpGet("SearchEmployee")]
        public async Task<ActionResult<List<object>>> SearchEmployee(string searchTerm)
        {
            var searchResult = await _employeeService.SearchEmployee(searchTerm);
            return Ok(searchResult);
        }

        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee)
        {
            var updatedEmployee = await _employeeService.UpdateEmployee(employee);
            if (updatedEmployee == null)
            {
                return NotFound();
            }

            return Ok(updatedEmployee);
        }


    }
}
