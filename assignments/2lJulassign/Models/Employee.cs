using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; }

        [Range(1000, 100000, ErrorMessage = "Salary must be between 1000 and 100000")]
        public double Salary { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
    }
}

