using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo4EmpDisplay.Models;

namespace Demo4EmpDisplay.Services
{
    //79.  Make interface public
    public interface IEmployeeRepository
    {
        //80.  Create a method to search employee whenever needed
        Employee GetEmployee(int id);
        //81.  Read expected employees
        IEnumerable<Employee> GetEmployees();
        //82.  (Create)Add an employee
        Employee AddEmployee(Employee e);
        //83.  Update an Employee
        Employee UpdateEmployee(Employee EmpUpdate);
        //84.  Delete an Employee base on id
        Employee DeleteEmployee(int id);
    }
    //85.  Create a class to implement everything
    //86.  Add a class(MockEmployeeRepository) in Services Folder
    //87.  Go to MockEmployeeRepository class
}
