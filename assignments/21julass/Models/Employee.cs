using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        [Required]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        [StringLength(50)]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; }

        [Required]
        [Range(1000, 100000, ErrorMessage = "Salary must be between 1000 and 100000")]
        public decimal Salary { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}

