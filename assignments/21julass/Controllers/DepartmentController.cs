using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        public ActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Details(Department dept)
        {
            if (ModelState.IsValid)
            {
                return View("DepartmentInfo", dept);
            }
            return View(dept);
        }
    }
}

