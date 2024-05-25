using EmployeeAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .Property(d => d.DepartmentID)
                .ValueGeneratedOnAdd();
        }
    }
}
