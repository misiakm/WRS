using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WRS.Models;

namespace WRS.ModelsViews
{
    public class LoginPage
    {
        [Required(ErrorMessage = "Wpisz hasło")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Wpisz login")]
        public string Login { get; set; }
    }
}