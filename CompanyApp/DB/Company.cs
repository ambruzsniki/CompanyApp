﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyApp.DB
{
    public class Company
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<Employee> EmployeeList { get; set; }
    }
}