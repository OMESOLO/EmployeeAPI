using System.Data.SqlTypes;

namespace EmployeeAPI.Entity
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email {  get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int DepartmentID {  get; set; }

        public string JobTitle { get; set; }

    }
}
