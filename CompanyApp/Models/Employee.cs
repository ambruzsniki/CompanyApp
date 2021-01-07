using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyApp.Models
{
    public class Employee
    {
        [Required]
        [Display(Name = "Név")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Pozíció")]
        public string Position { get; set; }

        [Required]
        [Display(Name = "Telefonszám")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "E-mail cím")]
        public string Email { get; set; }

        public Company Company { get; set; }

        [Required]
        [Display(Name = "Cégnév")]
        public string CompanyName { get; set; }

    }
}