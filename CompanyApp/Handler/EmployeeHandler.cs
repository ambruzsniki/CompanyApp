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

        public DB.Employee Get(int id)
        {
            using(var context = new DbContext())
            {
                return context.Employees.FirstOrDefault(x => x.Id == id);
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