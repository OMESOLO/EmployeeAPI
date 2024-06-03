using EmployeeAPI.Entity;

namespace EmployeeAPI.Service
{
    public interface IEmployeeService
    {
        Task<List<object>> GetEmployeeList();
        Task<List<Employee>> AddEmployee(List<Employee> employees);
        Task<Employee> DeleteEmployee(int employeeId);
        Task<List<object>> SearchEmployee(string searchTerm);
        Task<Employee> UpdateEmployee(Employee employee);
        

    }
}
