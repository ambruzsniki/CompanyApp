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
            if (ModelState.IsValid)
            {
                companyList.Add(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
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
        public ActionResult Delete(string name)
        {
            var deletedItem = companyList.Find(x => x.CompanyName.Equals(name));
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
        public ActionResult Delete(string name, FormCollection form)
        {
            var selectedCompany = companyList.Find(x => x.CompanyName.Equals(name));
            companyList.Remove(selectedCompany);
            employeeList.RemoveAll(x => x.Company.CompanyName.Equals(name));

            return RedirectToAction("Index");
        }


    }
}
