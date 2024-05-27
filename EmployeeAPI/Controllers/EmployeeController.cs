using EmployeeAPI.Data;
using EmployeeAPI.Entity;
using EmployeeAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

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
        public async Task<ActionResult> GetEmployee()
        {
            try
            {
                var result = await _employeeService.GetEmployeeList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("AddEmployee")]
        public async Task<ActionResult> AddEmployee(Employee employee)
        {
            try
            {
                var addedEmployee = await _employeeService.AddEmployee(employee);
                return Ok(addedEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("DeleteEmployee/{employeeId}")]
        public async Task<ActionResult> DeleteEmployee(int employeeId)
        {
            try
            {
                var deletedEmployee = await _employeeService.DeleteEmployee(employeeId);
                if (deletedEmployee == null)
                {
                    return NotFound();
                }
                return Ok(deletedEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("SearchEmployee")]
        public async Task<ActionResult> SearchEmployee(string searchTerm)
        {
            try
            {
                var searchResult = await _employeeService.SearchEmployee(searchTerm);
                return Ok(searchResult);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("UpdateEmployee/{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if (id != employee.EmployeeID)
                {
                    return BadRequest("Employee ID mismatch");
                }
                var updatedEmployee = await _employeeService.UpdateEmployee(employee);
                if (updatedEmployee == null)
                {
                    return NotFound();
                }
                return Ok(updatedEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
