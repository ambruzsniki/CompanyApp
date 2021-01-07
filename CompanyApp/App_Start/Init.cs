using CompanyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyApp
{
    public class Init
    {
        public static List<Company> companyList = new List<Company>();
        public static List<Employee> employeeList = new List<Employee>();

        public static void CreateInstances()
        {
            var company1 = new Company()
            {
                Id = 1,
                CompanyName = "Teszt cég",
                PhoneNumber = "+36 46 564 823",
                Address = "3532 Miskolc, Próba utca 34"
            };

            var company2 = new Company()
            {
                Id = 2,
                CompanyName = "Próba cég",
                PhoneNumber = "+36 46 234121",
                Address = "1012, Budapest Ciprus utca 34"
            };

            var employee1 = new Employee()
            {
                Id = 1,
                Name = "Kis Rozália",
                Position = "Irodavezető",
                PhoneNumber = "06304517262",
                Email = "kisrozika@mail.com",
                Company = company1,
                CompanyId = company1.Id
            };

            var employee2 = new Employee()
            {
                Id = 2,
                Name = "Teszt Evelin",
                Position = "Tesztelő",
                PhoneNumber = "+36204354241",
                Email = "tesztevelin@mail.com",
                Company = company2,
                CompanyId = company2.Id
            };

            companyList.Add(company1);
            companyList.Add(company2);
            employeeList.Add(employee1);
            employeeList.Add(employee2);

        }
    }
}