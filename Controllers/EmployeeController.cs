using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo4EmpDisplay.Services;
using Demo4EmpDisplay.Models;

namespace Demo4EmpDisplay.Controllers
{
    public class EmployeeController : Controller
    {
        //103.  Add Employee Repository Interface variable
        IEmployeeRepository EmpRepo;
        //104.  Create an employee constructor and injection variable
        public EmployeeController(IEmployeeRepository repository)
        {
            EmpRepo = repository;
        }
        //105.  Create a constructor to display view result of employee
        public ViewResult AllEmployees()
        {
            //106.  Create a variable to return list of employees
            var employee = EmpRepo.GetEmployees();
            //107.  Return all employees in a view
            return View(employee);
            //***Notes*** Complex object
            //108.  Create a Razor View Page in Employee Folder to display all employees 
            //***Notes*** Page should have same name as method
            //109.  Go to AllEmployees Page
        }

        //123.  Create a construct to create new employees
        [HttpGet]
        public ViewResult Create()
        {
            //124.  First we need to see blank view, have to do HttpGet but it's be default get, write to differentiate Get and Post for create
            return View();
            //125.  Create a Create Razer Page to add new employees in Employee Folder
            //126.  Go to Create Page
        }

        //136.  Create a Post Employee function using HttpPost
        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            //137.  Write an If statement for if it is valid
            if(ModelState.IsValid)
            {
                //138.  Create new variable for employee
                Employee newEmp = EmpRepo.AddEmployee(obj);
                //139.  If everything is valid, redirect user back to all employee display to see result
                return RedirectToAction("AllEmployees");
            }
            //140.  If not valid, keep user in same view
            return View();
        }

        //141.  Go to AllEmployees web page to write logic for update and delete
        //145.  Create function to update employee using httpget
        [HttpGet]
        public ViewResult Update(int id)
        {
            Employee obj = EmpRepo.GetEmployee(id);
            return View(obj);
        }
        //146.  Create an Update Razer View Page in Employee Folder
        //147.  Copy Form Tag from Create and throw it in Update page
        //153.  Crate a post to route the update
        [HttpPost]
        public ViewResult Update(Employee emp, int id)
        {
            //153.  Compare the ID for get and sent
            emp.Eid = id;
            //154.  Call the update method
            Employee upEmp = EmpRepo.UpdateEmployee(emp);

            //155.  Get the list
            var model = EmpRepo.GetEmployees();

            //156.  Returning to AllEmployees Page and updatelist
            return View("AllEmployees", model);
        }
        
        //157.  Create a delete function
        [HttpGet]
        public IActionResult Delete(int id)
        {
            EmpRepo.DeleteEmployee(id);
            return RedirectToAction("AllEmployees");
        }

        //158.  Go to Startup







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


        //67.  Create a method to get image, We were able to pull the employee name, now we need to have the images associated with the name
        public IActionResult GetImage(string empname)
        {
            return File($@"\images\{empname.ToLower()}.png", "image/png");
        }
        //68.  Go to Employee Details


    }
}
