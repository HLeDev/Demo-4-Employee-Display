using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo4EmpDisplay.Models
{
    //74.  Create a function for Department using enum
    //75.  Add using System.ComponentModel.DataAnnotations; to use ID
    public enum Dept
    {
        None,
        HR,
        Finance,
        IT,
        QA
    }
    public class Employee
    {
        //76. Create properties for employees
        [Display(Name = "Employee Id: ")]
        [Required]
        [Key]
        public int Eid { get; set; }

        [Display(Name = "First & Last Name: ")]
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 chars")]
        public string EName { get; set; }

        [Display(Name = "Email: ")]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Format")]
        public string Email { get; set; }

        [Display(Name = "Department: ")]
        public Dept Department { get; set; }

        //191.  Add another property that's similar to Department Class
        public int DeptId { get; set; }
        //192.  Add Department class to set relation
        public virtual Department dept { get; set; }
        //193.  Go to Employee Context Class in Models
        


        //77.  Add an Interface (IEmployeeRepository) in Services
        //78.  Go to IEmployeeRepository class
    }
}
