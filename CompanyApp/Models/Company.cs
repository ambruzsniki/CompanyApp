using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyApp.Models
{
    public class Company
    {
        [Required]
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

        public static explicit operator Company(DB.Company company)
        {
            return new Models.Company() 
            {
                Id = company.Id,
                Address = company.Address,
                PhoneNumber = company.PhoneNumber,
                CompanyName = company.CompanyName
            };
        }
    }
}