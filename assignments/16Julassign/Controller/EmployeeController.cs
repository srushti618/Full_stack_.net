using EmployeeManagementSystem.Model;
using System.Collections.Generic;

namespace EmployeeManagementSystem.Controller
{
    public class EmployeeController
    {
        private List<Employee> employees = new List<Employee>();

        public void AddEmployee(Employee emp)
        {
            employees.Add(emp);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}

