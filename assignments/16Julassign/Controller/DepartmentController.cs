using EmployeeManagementSystem.Model;
using System.Collections.Generic;

namespace EmployeeManagementSystem.Controller
{
    public class DepartmentController
    {
        private List<Department> departments = new List<Department>();

        public void AddDepartment(Department dept)
        {
            departments.Add(dept);
        }

        public List<Department> GetDepartments()
        {
            return departments;
        }
    }
}

