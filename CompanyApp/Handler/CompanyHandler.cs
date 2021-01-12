using CompanyApp.DB;
using CompanyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyApp.Handler
{
    public class CompanyHandler
    {
        public void Create(Models.Company model)
        {
            using (var context = new DbContext())
            {
                context.Companies.Add(new DB.Company()
                {
                    CompanyName = model.CompanyName,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber
                });

                context.SaveChanges();
            }
        }

        public DB.Company Get(int id)
        {
            using (var context = new DbContext())
            {
                return context.Companies.FirstOrDefault(x => x.Id == id);
            }
        }

        public bool Update(int id, Models.Company model)
        {
            using (var context = new DbContext())
            {
                var company = context.Companies.FirstOrDefault(x => x.Id == id);

                if(company != null)
                {
                    context.Entry(company).CurrentValues.SetValues(model);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Delete(int id)
        {
            using (var context = new DbContext())
            {
                var company = context.Companies.FirstOrDefault(x => x.Id == id);

                if (company != null)
                {
                    context.Companies.Remove(company);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
