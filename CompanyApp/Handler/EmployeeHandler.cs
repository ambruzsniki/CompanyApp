using CompanyApp.DB;
using CompanyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyApp.Handler
{
    public class EmployeeHandler
    {
        public bool Create(Models.Employee model)
        {
            using(var context = new DbContext())
            {
                var success = false;
                var company = context.Companies.FirstOrDefault(x => x.Id == model.CompanyId);
               
                if (company != null) {
                    context.Employees.Add(new DB.Employee() 
                    { 
                        Name = model.Name,
                        Position = model.Position,
                        PhoneNumber = model.PhoneNumber,
                        Email = model.Email,
                        CompanyId = model.CompanyId
                    });

                    context.SaveChanges();
                    success = true;
                }

                return success;
            }
        }

        public List<Models.Employee> GetEmployees()
        {
            using(var context = new DbContext())
            {
                var employeeList = context.Employees;
                var list = new List<Models.Employee>();

                foreach(var x in employeeList)
                {
                    list.Add(new Models.Employee()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Position = x.Position,
                        PhoneNumber = x.PhoneNumber,
                        Email = x.Email,
                        CompanyId = x.CompanyId,
                        Company = (Models.Company)context.Companies.FirstOrDefault(y => y.Id == x.CompanyId)
                    });                   
                }

                return list;
            }
        }

        public Models.Employee Get(int id)
        {
            using(var context = new DbContext())
            {
                var employee = context.Employees.FirstOrDefault(x => x.Id == id);

                return new Models.Employee()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Position = employee.Position,
                    PhoneNumber = employee.PhoneNumber,
                    Email = employee.Email,
                    CompanyId = employee.CompanyId
                };
            }
        }

        public bool Update(int id, Models.Employee model)
        {
            using(var context = new DbContext())
            {
                var success = false;
                var employee = context.Employees.FirstOrDefault(x => x.Id == id);

                if (employee != null)
                {
                    context.Entry(employee).CurrentValues.SetValues(model);
                    context.SaveChanges();
                    success = true;
                }

                return success;
            }
        }

        public bool Delete(int id)
        {
            using (var context = new DbContext())
            {
                var success = false;
                var employee = context.Employees.FirstOrDefault(x => x.Id == id);

                if (employee != null)
                {
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                    success = true;
                }

                return success;
            }
        }
    }
}