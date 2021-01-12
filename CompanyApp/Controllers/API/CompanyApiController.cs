using CompanyApp.Handler;
using CompanyApp.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompanyApp.Controllers
{
    public class CompanyApiController : ApiController
    {
        public HttpResponseMessage Create(Company model)
        {
            var handler = new CompanyHandler();

            try
            {
                handler.Create(model);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch(Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        public HttpResponseMessage Get(int id)
        {
            var handler = new CompanyHandler();

            try
            {
                var company = handler.Get(id);

                if (company != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, company);
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
        public HttpResponseMessage Update(int id, Company model)
        {
            var handler = new CompanyHandler();

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
            catch(Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            var handler = new CompanyHandler();

            try
            {
                var success = handler.Delete(id);

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

    }
}
