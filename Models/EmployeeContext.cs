using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//162.  Using entityframeworkcore
using Microsoft.EntityFrameworkCore;

namespace Demo4EmpDisplay.Models
{
    //163.  Use DBContext
    public class EmployeeContext:DbContext
    {
        //164.  Write a constructor for DbContext so it'll understand the db name and class that it's connecting to
        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options)
        {

        }

        //194. Add Another Table for Department
        public DbSet<Department> Departments { get; set; }

        //165.  Create a table for employee
        public DbSet<Employee> Employees { get; set; } //**Notes** Table in SQL DB

        //166.  Write a method that can be overridden when necessary and build a dummy database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //195.  Create a data seeding method
            modelBuilder.Entity<Department>().HasData
                (
                new Department
                {
                    DeptId = 1,
                    DeptName ="HR"
                },
                new Department
                {
                    DeptId = 2,
                    DeptName = "IT"
                },
                new Department
                {
                    DeptId = 3,
                    DeptName = "Finance"
                },
                new Department
                {
                    DeptId = 4,
                    DeptName = "QA"
                }
                );
            //196.  Go to Startup to use SqlServer

            modelBuilder.Entity<Employee>().HasData
                (
                    new Employee
                    {
                        Eid = 101,
                        EName = "Michael",
                        Email = "Michael@gmail.com",
                        Department = Dept.HR,
                        DeptId = 1
                    },
                    new Employee
                    {
                        Eid = 102,
                        EName = "Sarah",
                        Email = "Sarah@gmail.com",
                        Department = Dept.IT,
                        DeptId = 2
                    },
                    new Employee
                    {
                        Eid = 103,
                        EName = "Logan",
                        Email = "Logan@gmail.com",
                        Department = Dept.Finance,
                        DeptId = 3
                    },
                    new Employee
                    {
                        Eid = 104,
                        EName = "Elenea",
                        Email = "Elena@gmail.com",
                        Department = Dept.QA,
                        DeptId = 4
                    }
                );
            ;
        }
        //167.  Go to Startup and add using models and entityframeworkcore
    }
}
