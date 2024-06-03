using EmployeeAPI.Data;
using EmployeeAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        // GetEmployee
        public async Task<List<object>> GetEmployeeList()
        {
            var data = await (from emp in _context.Employees
                              join dept in _context.Departments on emp.DepartmentID equals dept.DepartmentID
                              join proj in _context.Projects on dept.DepartmentID equals proj.DepartmentID
                              select new
                              {
                                  emp.FirstName,
                                  emp.LastName,
                                  emp.Email,
                                  emp.Gender,
                                  emp.JobTitle,
                                  DepartmentName = dept.DepartmentName,
                                  ProjectName = proj.ProjectName,
                                  StartDate = proj.StartDate.HasValue ? proj.StartDate.Value.ToString("dd/MM/yyyy") : null,
                                  EndDate = proj.EndDate.HasValue ? proj.EndDate.Value.ToString("dd/MM/yyyy") : null
                              }).ToListAsync<object>();
            return data;
        }

        public async Task<List<Employee>> AddEmployee(List<Employee> employees)
        {
            _context.Employees.AddRange(employees);
            await _context.SaveChangesAsync();
            return employees;
        }


        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee == null)
            {
                return null;
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<List<object>> SearchEmployee(string searchTerm)
        {
            var data = await (from emp in _context.Employees
                              join dept in _context.Departments on emp.DepartmentID equals dept.DepartmentID
                              join project in _context.Projects on dept.DepartmentID equals project.DepartmentID
                              where string.IsNullOrEmpty(searchTerm) ||
                                    emp.FirstName.Contains(searchTerm) ||
                                    emp.LastName.Contains(searchTerm) ||
                                    emp.Email.Contains(searchTerm) ||
                                    dept.DepartmentName.Contains(searchTerm) ||
                                    project.ProjectName.Contains(searchTerm)
                              select new
                              {
                                  emp.FirstName,
                                  emp.LastName,
                                  emp.Email,
                                  emp.Gender,
                                  emp.JobTitle, 
                                  DepartmentName = dept.DepartmentName,
                                  ProjectName = project.ProjectName,
                                  StartDate = project.StartDate.HasValue ? project.StartDate.Value.ToString("dd/MM/yyyy") : null,
                                  EndDate = project.EndDate.HasValue ? project.EndDate.Value.ToString("dd/MM/yyyy") : null
                              }).ToListAsync<object>();
            return data;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var existingEmployee = await _context.Employees.FindAsync(employee.EmployeeID);
            if (existingEmployee == null)
            {
                return null;
            }

            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.Email = employee.Email;
            existingEmployee.Gender = employee.Gender;
            existingEmployee.DepartmentID = employee.DepartmentID;
            existingEmployee.JobTitle = employee.JobTitle; 

            await _context.SaveChangesAsync();
            return existingEmployee;
        }
    }
}
