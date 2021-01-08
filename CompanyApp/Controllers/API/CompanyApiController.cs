using CompanyApp.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static CompanyApp.Init;

namespace CompanyApp.Controllers
{
    public class CompanyApiController : ApiController
    {
        public void Create(Company model)
        {
            companyList.Add(model);
        }

        public HttpResponseMessage Get(int id)
        {
            var company = companyList.FirstOrDefault(x => x.Id == id);

            if (company != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, company);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        [HttpPut]
        public HttpResponseMessage Update(int id, Company model)
        {
            var company = companyList.FirstOrDefault(x => x.Id == id);

            if (company != null)
            {
                company.CompanyName = model.CompanyName;
                company.Address = model.Address;
                company.PhoneNumber = model.PhoneNumber;
                return Request.CreateResponse(HttpStatusCode.OK, company);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            var company = companyList.FirstOrDefault(x => x.Id == id);
           
            if(company != null)
            {
                companyList.Remove(company);
                employeeList.RemoveAll(x => x.CompanyId == company.Id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

    }
}
