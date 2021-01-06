using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyApp.Models
{
    public class Employee
    {
        public int Id { get; set; }

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

        [Required]
        [Display(Name = "Cégnév")]
        public Company Company { get; set; }

    }
}