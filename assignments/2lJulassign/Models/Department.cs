using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Department
    {
        [Required]
        public string DeptName { get; set; }

        [Required]
        public string DeptHead { get; set; }

        [Required, Phone]
        public string HeadContact { get; set; }

        [Required, EmailAddress]
        public string HeadEmail { get; set; }
    }
}

