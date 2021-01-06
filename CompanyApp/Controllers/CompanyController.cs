using CompanyApp.Models;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using static CompanyApp.Init;

namespace CompanyApp.Controllers
{
    public class CompanyController : Controller
    {
        public ActionResult Index()
        {
            return View(companyList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Company model)
        {
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Company model)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var deletedItem = companyList.Find(x => x.Id == id);
            if(deletedItem != null)
            {
                return View(deletedItem);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            var selectedCompany = companyList.Find(x => x.Id == id);
            companyList.Remove(selectedCompany);
            employeeList.RemoveAll(x => x.Company.Id == id);

            return RedirectToAction("Index");
        }


    }
}
