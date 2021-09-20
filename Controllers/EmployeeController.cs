using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo4EmpDisplay.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            //13.  Create an array for names
            ViewBag.Employeenames = new string[] { "Elena", "Logan", "Michael", "Nathan", "Sarah" };
            //14.  Go to Employee Index page
            return View();
        }

        //24.  Create Details method
        public IActionResult Details(string empname)
        {
            ViewBag.selectedemployee = empname;
            return View();
        }
        //25.  Go to Details.cshtml
    }
}
