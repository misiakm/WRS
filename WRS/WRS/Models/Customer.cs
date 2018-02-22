using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WRS.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string NameOfCustmoer { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public int TypeOfCustomer { get; set; }

        public string Comment { get; set; }

        public DateTime DateOfAdd { get; set; } = DateTime.Now;

        [ForeignKey("Customer")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}