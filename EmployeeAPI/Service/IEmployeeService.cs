using EmployeeAPI.Entity;

namespace EmployeeAPI.Service
{
    public interface IEmployeeService
    {
        Task<List<object>> GetEmployeeList();
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> DeleteEmployee(int employeeId);
        Task<List<object>> SearchEmployee(string searchTerm);
        Task<Employee> UpdateEmployee(Employee employee);
        

    }
}
