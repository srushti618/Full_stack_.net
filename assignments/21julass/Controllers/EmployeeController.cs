using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee/Register
        public ActionResult Register()
        {
            return View();
        }

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
    }
}

