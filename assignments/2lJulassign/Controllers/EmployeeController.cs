using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
//using System.Web.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee Registration Form
        public ActionResult Register()
        {
            return View();
        }

        // POST: Employee Registration
        [HttpPost]
        public ActionResult Register(Employee emp)
        {
            if (ModelState.IsValid)
            {
                TempData["EmployeeName"] = emp.EmployeeName;
                TempData["Department"] = emp.Department;
                return RedirectToAction("Success");
            }
            return View(emp);
        }

        public ActionResult Success()
        {
            ViewBag.EmployeeName = TempData["EmployeeName"];
            ViewBag.Department = TempData["Department"];
            return View();
        }

        public ActionResult DepartmentDetails()
        {
            Department dept = new Department
            {
                DeptName = "IT",
                DeptHead = "Priya",
                HeadContact = "9876543210",
                HeadEmail = "priya@example.com"
            };
            return View(dept);
        }
    }
}

