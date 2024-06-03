using EmployeeAPI.Data;
using EmployeeAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext _context;

        public DepartmentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<object>> GetDeparmentList()
        {
            var data = await (from dept in _context.Departments
                              select new
                              {
                                dept.DepartmentID,
                                dept.DepartmentName,
                                dept.ManagerID
                              }).ToListAsync<object>();

            return data;    
        }

        public async Task<List<object>> GetDepartmentID(int id)
        {
            var data = await (from dept in _context.Departments
                              join emp in _context.Employees on dept.DepartmentID equals emp.DepartmentID
                              where dept.DepartmentID == id
                              select new
                              {
                                  emp.FirstName,
                                  emp.LastName,
                                  emp.Email,
                                  emp.Gender,
                                  dept.DepartmentName,
                              }).ToListAsync<object>();
            return data;
        }

        public async Task<Department> DeleteDepartment(int departmentID)
        {
            var department = await _context.Departments.FindAsync(departmentID);
            if (department == null)
            {
                return null;
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<List<object>> SearchDepartment(string searchdep)
        {
            var data = await (from dept in _context.Departments
                              where string.IsNullOrEmpty(searchdep)
                                    || dept.DepartmentName.Contains(searchdep)
                                    || dept.ManagerID.ToString().Contains(searchdep)
                              select new
                              {
                                  dept.DepartmentName,
                                  dept.ManagerID,
                              }).ToListAsync<object>();
            return data;
        }

        public async Task<Department> UpdateDepartment(int id, Department department)
        {
            var updept = await _context.Departments.FindAsync(id);

            if (updept == null)
            {
                return null;
            }

            updept.DepartmentName = department.DepartmentName;
            updept.ManagerID = department.ManagerID;

        
            await _context.SaveChangesAsync();

            return department;
        }



        public async Task<IEnumerable<Department>> AddDepartments(IEnumerable<Department> departments)
        {
            foreach (var department in departments)
            {
                _context.Departments.Add(department);
            }
            await _context.SaveChangesAsync();
            return departments;
        }


    }
}
