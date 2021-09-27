using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo4EmpDisplay.Models;

namespace Demo4EmpDisplay.Services
{
    //88.  Reference Employee inferface
    public class MockEmployeeRepository : IEmployeeRepository
    {
        //89.  Create a private list of employees for this specific class
        private List<Employee> eList;
        //90.  Create a constructor to initialize the list
        public MockEmployeeRepository()
        {
            //91.  Will display only once if using singleton(Will do in startup)
            //92.  Create a list of employees
            eList = new List<Employee>()
            {
                new Employee() { Eid = 101, EName = "Michael", Email = "michael@gmail.com", Department = Dept.HR },
                new Employee() { Eid = 102, EName = "Elena", Email = "elena@gmail.com", Department = Dept.Finance },
                new Employee() { Eid = 103, EName = "Logan", Email = "logan@gmail.com", Department = Dept.IT },
                new Employee() { Eid = 104, EName = "Nathan", Email = "nathan@gmail.com", Department = Dept.QA },
                new Employee() { Eid = 105, EName = "Sarah", Email = "sarah@gmail.com", Department = Dept.None }
                
            };
        }

        //93.  Delete Execeptions
        public Employee AddEmployee(Employee e)
        {
            //94.  Create Logic for Adding Employee
            //95.  First, we want EID max +1, autoincrement
            e.Eid = eList.Max(e => e.Eid) + 1;
            eList.Add(e);
            return e;
        }

        public Employee DeleteEmployee(int id)
        {
            //96.  Write logic to delete employee base on id
            Employee emp = eList.FirstOrDefault(e => e.Eid == id);
            if (emp != null)
            {
                eList.Remove(emp);
            }
            
            return emp;
        }

        public Employee GetEmployee(int id)
        {
            //97.  Write Logic to search for employee from list by eid
            return eList.FirstOrDefault(e => e.Eid == id);
            
        }

        public IEnumerable<Employee> GetEmployees()
        {
            //98.  Return employee list
            return eList;
        }

        public Employee UpdateEmployee(Employee EmpUpdate)
        {
            //99.  Update Employee from list by matching eid
            Employee emp = eList.FirstOrDefault(e => e.Eid == EmpUpdate.Eid);
            if(emp != null)
            {
                //If it is not null, update changes from new record to old record
                emp.EName = EmpUpdate.EName;
                emp.Email = EmpUpdate.Email;
                emp.Department = EmpUpdate.Department;
            }
            return emp;
        }

        //100.  Go to Startup
    }
}
