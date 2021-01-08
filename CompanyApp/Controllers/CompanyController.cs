using CompanyApp.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
                var idMaxVal = 0;

                if (companyList.Any())
                {
                    idMaxVal = companyList.Max(x => x.Id);
                }

                model.Id = idMaxVal + 1;
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
            var model = companyList.FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Edit(Company model)
        {
            if (ModelState.IsValid)
            {
                var original = companyList.FirstOrDefault(x => x.Id == model.Id);
                if (original != null)
                {
                    original.CompanyName = model.CompanyName;
                    original.Address = model.Address;
                    original.PhoneNumber = model.PhoneNumber;
                    return RedirectToAction("Index");
                }
                else
                {
                    return HttpNotFound();
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var deletedItem = companyList.FirstOrDefault(x => x.Id == id);

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
            var selectedCompany = companyList.FirstOrDefault(x => x.Id == id);
            companyList.Remove(selectedCompany);
            employeeList.RemoveAll(x => x.Company.Id == id);

            return RedirectToAction("Index");
        }


    }
}
