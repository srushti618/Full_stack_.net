using _16Jul.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _16Jul.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Student> students = new List<Student>()
            {
                new Student{ Id=101, Name="abc" ,Age = 20,Course="Dot net Framework",Gender='F',Qualification="B.E",Fee=2500},
                new Student{ Id=102, Name="abd" ,Age = 21,Course="java Framework",Gender='M',Qualification="B.tech",Fee=2400},
                new Student{ Id=103, Name="abe" ,Age = 22,Course="frontend Framework",Gender='F',Qualification="B.sc",Fee=2300},
                new Student{ Id=104, Name="abf" ,Age = 23,Course="backend Framework",Gender='M',Qualification="B.com",Fee=2200},
            };
            return View(students);
        }

    }
}
