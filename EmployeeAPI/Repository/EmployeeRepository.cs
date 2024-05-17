using EmployeeAPI.Data;
using EmployeeAPI.Entity;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace EmployeeAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }
        //GetEmployee
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
                                  DepartmentName = dept.DepartmentName,
                                  ProjectName = proj.ProjectName,

      
                                  
                              }).ToListAsync<object>();
            return data;
                
        }
        
        public async Task<Employee> AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
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
                              where emp.FirstName.Contains(searchTerm) || emp.LastName.Contains(searchTerm) || emp.Email.Contains(searchTerm) || dept.DepartmentName.Contains(searchTerm) || project.ProjectName.Contains(searchTerm) || string.IsNullOrEmpty(searchTerm)
                              select new
                                {
                                    emp.FirstName,
                                    emp.LastName,
                                    emp.Email,
                                    emp.Gender,                       
                                    DepartmentName = dept.DepartmentName,
                                    ProjectName = project.ProjectName,
                                    startdate = project.StartDate != null ? project.StartDate.ToString("dd/mm/yyyy") : null,
                                    enddate = project.EndDate != null ? project.EndDate.ToString("dd/mm/yyyy") : null,

                                  

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
            



            await _context.SaveChangesAsync();
            return existingEmployee;
        }

        
    }
}
