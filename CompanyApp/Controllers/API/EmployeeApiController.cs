using CompanyApp.Handler;
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
            var handler = new EmployeeHandler();

            try
            {
                var success = handler.Create(model);

                if (success)
                {
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            catch(Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        public HttpResponseMessage Get(int id)
        {
            var handler = new EmployeeHandler();

            try
            {
                var employee = handler.Get(id);

                if (employee != null)
                {
                    var model = new Employee()
                    {
                        Name = employee.Name,
                        Position = employee.Position,
                        PhoneNumber = employee.PhoneNumber,
                        Email = employee.Email,
                        CompanyId = employee.CompanyId
                    };

                    return Request.CreateResponse(HttpStatusCode.OK, model);
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            catch(Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public HttpResponseMessage Update(int id, Employee model)
        {
            var handler = new EmployeeHandler();

            try
            {
                var success = handler.Update(id, model);

                if (success)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);

                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            var handler = new EmployeeHandler();

            try
            {
                bool success = handler.Delete(id);

                if (success)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            catch(Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}