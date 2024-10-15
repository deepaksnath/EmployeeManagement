using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Data.Employees
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
