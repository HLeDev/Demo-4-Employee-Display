using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo4EmpDisplay.Models
{
    public class Department
    //188.  Create properties with attributes for department
    {
        [Key]
        public int DeptId { get; set; }
        [Required]
        public string DeptName { get; set; }

        //189.  If there's a relation, must call the employee list
        public virtual ICollection<Employee> Employees { get; set; }

        //190.  Go to Employee.cs

    }
}
