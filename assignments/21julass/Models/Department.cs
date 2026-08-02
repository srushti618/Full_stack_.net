

using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Department
    {
        [Required]
        public string DepartmentName { get; set; }

        [Required]
        public string DepartmentHead { get; set; }

        [Required]
        [Phone(ErrorMessage = "Invalid Contact Number")]
        public string HeadContactNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string HeadEmail { get; set; }
    }
}

