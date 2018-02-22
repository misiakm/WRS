using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WRS.Models
{
    public class Department
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string NameOfDepartment { get; set; }

        public DateTime DateOfAdd { get; set; } = DateTime.Now;

        public string Comment { get; set; }

        [ForeignKey("Department")]
        public virtual ICollection<EmployeeDepartment> Employees { get; set; }
    }
}