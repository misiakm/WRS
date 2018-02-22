using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WRS.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string NameOfOrder { get; set; }

        [Required]
        public int Customer { get; set; }

        [Required]
        [DefaultValue(1)]
        public int Status { get; set; }

        [Required]
        public string Number { get; set; }

        public DateTime StartDate { get; set; }

        public double PlanPrace { get; set; }
        
        public DateTime PlanEndDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Comment { get; set; }

        public DateTime DateOfAdd { get; set; } = DateTime.Now;

        [ForeignKey("Order")]
        public virtual ICollection<WorkTime> WorkTimes { get; set; }
    }
}