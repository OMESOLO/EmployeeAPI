using EmployeeAPI.Entity;
using EmployeeAPI.Repository;

namespace EmployeeAPI.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<List<object>> GetDepartmentList()
        {
            var departmentList = await _departmentRepository.GetDeparmentList();
            return departmentList;
        }

        public async Task<List<object>> GetDepartmentID(int id)
        {
            var result = await _departmentRepository.GetDepartmentID(id);
            return result;
        }

        public async Task<Department> DeleteDepartment(int departmentID)
        {
            var deleteDepartment = await _departmentRepository.DeleteDepartment(departmentID);
            return deleteDepartment;
        }

        public async Task<List<object>> SearchDepartment(string searchdep)
        {
            var result = await _departmentRepository.SearchDepartment(searchdep);
            return result;
        }

        public async Task<Department> UpdateDepartment(Department department)
        {
            var updatedepartment = await _departmentRepository.UpdateDepartment(department);
            return updatedepartment;
        }

        public async Task AddDepartment(Department addDepartment)
        {
            await _departmentRepository.AddDepartment(addDepartment);
        }
        
    }
}
