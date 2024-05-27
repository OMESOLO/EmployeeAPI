using EmployeeAPI.Entity;

namespace EmployeeAPI.Service
{
    public interface IDepartmentService
    {
        Task<List<object>> GetDepartmentList();
        Task<List<object>> GetDepartmentID(int id);
        Task<Department> DeleteDepartment(int departmentID);
        Task<List<object>> SearchDepartment(string searchdep);
        Task<Department> UpdateDepartment(int id, Department department);
        Task AddDepartment(Department addDepartment);
    }
}
