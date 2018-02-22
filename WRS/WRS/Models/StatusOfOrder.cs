﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WRS.Models
{
    public class StatusOfOrder
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string NameOfStatus { get; set; }

        public string Comment { get; set; }

        public DateTime DateOfAdd { get; set; } = DateTime.Now;
    }
}