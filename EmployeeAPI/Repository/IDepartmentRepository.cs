using EmployeeAPI.Entity;

namespace EmployeeAPI.Repository
{
    public interface IDepartmentRepository
    {
        Task<List<object>> GetDeparmentList();
        Task<List<object>> GetDepartmentID(int id);
        Task<Department> DeleteDepartment(int departmentID);
        Task<List<object>> SearchDepartment(string searchdep);
        Task<Department> UpdateDepartment(Department department);
        Task AddDepartment(Department addDepartment);
    }
}
