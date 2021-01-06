using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyApp.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cégnév")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Cím")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Telefonszám")]
        public string PhoneNumber { get; set; }

        public List<Employee> EmployeeList { get; set; }
    }
}