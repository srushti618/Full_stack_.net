using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required, StringLength(50)]
        public string EmployeeName { get; set; }

        [Required]
        public string Department { get; set; }

        [Range(1000, 100000)]
        public double Salary { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
