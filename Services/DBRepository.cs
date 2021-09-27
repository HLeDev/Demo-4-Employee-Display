using Demo4EmpDisplay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo4EmpDisplay.Services
{
    //174.  Reference the Employee interface
    public class DBRepository : IEmployeeRepository
    {
        //182.  Create a var for EmployeeContext Class
        private EmployeeContext empContext;
        //183.  Write a construct for this repository and pass the var of employeeocntext to associate the db
        public DBRepository(EmployeeContext context)
        {
            empContext = context;
        }
        //184.  Go to Startup and use DB instead of Mock



        //175.  Write methods for CRUD
        public Employee AddEmployee(Employee e)
        {
            //176.  Create Logic for Adding Employee
            //177.  First, we want EID max +1, autoincrement
            e.Eid = empContext.Employees.Max(e => e.Eid) + 1;


            //200.  Add an if statement to compare department name and id
            if(e.Department.ToString()=="HR")
            {
                e.DeptId = 1;
            }
            if (e.Department.ToString() == "IT")
            {
                e.DeptId = 2;
            }
            if (e.Department.ToString() == "Finance")
            {
                e.DeptId = 3;
            }
            if (e.Department.ToString() == "QA")
            {
                e.DeptId = 4;
            }
            //201.  Do the same thing for Update



            empContext.Employees.Add(e);
            empContext.SaveChanges();
            return e;
        }

        public Employee DeleteEmployee(int id)
        {
            //178.  Write logic to delete employee base on id
            Employee emp = empContext.Employees.FirstOrDefault(e => e.Eid == id);
            if (emp != null)
            {
                empContext.Employees.Remove(emp);
            }
            empContext.SaveChanges();
            return emp;
        }

        public Employee GetEmployee(int id)
        {
            //179.  Write Logic to search for employee from list by eid
            return empContext.Employees.FirstOrDefault(e => e.Eid == id);

        }

        public IEnumerable<Employee> GetEmployees()
        {
            //180.  Return employee list
            return empContext.Employees.ToList();
        }

        public Employee UpdateEmployee(Employee EmpUpdate)
        {
            //181.  Update Employee from list by matching eid
            Employee emp = empContext.Employees.FirstOrDefault(e => e.Eid == EmpUpdate.Eid);
            if (emp != null)
            {
                //**Note** If it is not null, update changes from new record to old record
                emp.EName = EmpUpdate.EName;
                emp.Email = EmpUpdate.Email;
                emp.Department = EmpUpdate.Department;

                //202.  Add an if statement to compare department name and id
                if (emp.Department.ToString() == "HR")
                {
                    emp.DeptId = 1;
                }
                if (emp.Department.ToString() == "IT")
                {
                    emp.DeptId = 2;
                }
                if (emp.Department.ToString() == "Finance")
                {
                    emp.DeptId = 3;
                }
                if (emp.Department.ToString() == "QA")
                {
                    emp.DeptId = 4;
                }
            }
            empContext.SaveChanges();
            return emp;
        }
    }
}
