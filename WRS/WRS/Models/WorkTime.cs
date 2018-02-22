using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WRS.Models
{
    public class WorkTime
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int Employee { get; set; }

        public int? Department { get; set; }

        [Required]
        public TimeSpan Time { get; set; }
        
        [Required]
        public int Order { get; set; }

        [Required]
        public DateTime WorkDate { get; set; }

        public string comment { get; set; }

        public DateTime DateOfAdd { get; set; } = DateTime.Now;
    }
}