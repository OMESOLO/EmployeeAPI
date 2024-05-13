using EmployeeAPI.Entity;
using EmployeeAPI.Repository;

namespace EmployeeAPI.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<object>> GetEmployeeList()
        {
            var employeeList = await _employeeRepository.GetEmployeeList();
            return employeeList;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var addedEmployee = await _employeeRepository.AddEmployee(employee);
            return addedEmployee;
        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var deletedEmployee = await _employeeRepository.DeleteEmployee(employeeId);
            return deletedEmployee;
        }

        public async Task<List<object>> SearchEmployee(string searchTerm)
        {
            var searchResult = await _employeeRepository.SearchEmployee(searchTerm);
            return searchResult;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var updatedEmployee = await _employeeRepository.UpdateEmployee(employee);
            return updatedEmployee;
        }

        
    }
}
