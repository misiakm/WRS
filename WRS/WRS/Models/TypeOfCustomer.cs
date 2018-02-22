using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WRS.Models
{
    public class TypeOfCustomer
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Type { get; set; }

        public string Comment { get; set; }

        public DateTime DateOfAdd { get; set; } = DateTime.Now;

        [ForeignKey("TypeOfCustomer")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}