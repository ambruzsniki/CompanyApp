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

        public IEnumerable<Models.Company> GetCompanies()
        {
            using(var context = new DbContext())
            {
                return context.Companies.Select(x => new Models.Company()
                {
                    CompanyName = x.CompanyName,
                    PhoneNumber = x.PhoneNumber,
                    Address = x.Address,
                    Id = x.Id
                }).ToList();
            }
        }

        public Models.Company Get(int id)
        {
            using (var context = new DbContext())
            {
                var company = context.Companies.FirstOrDefault(x => x.Id == id);

                if (company != null)
                {
                    return new Models.Company()
                    {
                        Id = company.Id,
                        CompanyName = company.CompanyName,
                        Address = company.Address,
                        PhoneNumber = company.PhoneNumber
                    };
                }
                else
                {
                    return null;
                }
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
