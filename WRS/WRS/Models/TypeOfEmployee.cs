using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WRS.Models
{
    public class TypeOfEmployee
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string NameOfType { get; set; }

        public string Comment { get; set; }

        public DateTime DateOfAdd { get; set; } = DateTime.Now;

        [ForeignKey("TypeOfEmployee")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}