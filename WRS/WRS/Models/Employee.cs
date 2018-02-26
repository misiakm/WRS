using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WRS.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [DisplayFormat(DataFormatString = "{0:###-###-####}")]
        public string PhoneNumber { get; set; }

        public string Login { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [EmailAddress(ErrorMessage = "Podaj prawidłowy adres mailowy")]
        public string Email { get; set; }

        [Required]
        [DefaultValue(3)]
        public int TypeOfEmployee { get; set; }

        public string Comment { get; set; }

        public DateTime DateOFAdd { get; set; } = DateTime.Now;

        [ForeignKey("Employee")]
        public virtual ICollection<EmployeeDepartment> Departments { get; set; }

        [ForeignKey("Employee")]
        public virtual ICollection<EmployeeRenumeration> Renumerations { get; set; }

        [ForeignKey("Employee")]
        public virtual ICollection<WorkTime> WorkTimes { get; set; }
    }
}