using CompanyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using static CompanyApp.Init;

namespace CompanyApp.Controllers.API
{
    public class EmployeeApiController : ApiController
    {
        public HttpResponseMessage Create(Employee model)
        {
            var company = companyList.FirstOrDefault(x => x.Id == model.CompanyId);
            if (company != null)
            {
                model.Company = company;
                employeeList.Add(model);
                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public HttpResponseMessage Get(int id)
        {
            var employee = employeeList.FirstOrDefault(x => x.Id == id);

            if (employee != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, employee);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        [HttpPut]
        public HttpResponseMessage Update(int id, Employee model)
        {
            var employee = employeeList.FirstOrDefault(x => x.Id == id);
            var company = companyList.FirstOrDefault(x => x.Id == model.CompanyId);

            if (employee != null && company != null)
            {
                employee.Name = model.Name;
                employee.Position = model.Position;
                employee.PhoneNumber = model.PhoneNumber;
                employee.Email = model.Email;
                employee.CompanyId = model.CompanyId;
                employee.Company = company;
                return Request.CreateResponse(HttpStatusCode.OK, employee);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            var employee = employeeList.FirstOrDefault(x => x.Id == id);

            if (employee != null)
            {
                employeeList.Remove(employee);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}