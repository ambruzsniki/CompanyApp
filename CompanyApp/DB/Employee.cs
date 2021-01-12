using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyApp.DB
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public Company Company { get; set; }

        public int CompanyId { get; set; }
    }
}