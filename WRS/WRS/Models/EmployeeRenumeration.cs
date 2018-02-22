using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WRS.Models
{
    public class EmployeeRenumeration
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int Employee { get; set; }

        [Required]
        public double RenumStandard { get; set; }

        [Required]
        public double RenumOvertime { get; set; }

        [Required]
        public double RenumTripStandard { get; set; }

        [Required]
        public double RenumTripOvertime { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime DateOfAdd { get; set; } = DateTime.Now;
    }
}