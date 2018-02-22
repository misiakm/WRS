using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WRS.Models
{
    public class EmployeeDepartment
    {
        [Key, Column(Order = 1)]
        public int Employee { get; set; }

        [Key, Column(Order = 2)]
        public int Department { get; set; }

        public string Comment { get; set; }

        public DateTime DateOfAdd { get; set; } = DateTime.Now;
    }
}