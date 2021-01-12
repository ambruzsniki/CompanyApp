using CompanyApp.Handler;
using CompanyApp.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace CompanyApp.Controllers
{
    public class CompanyController : Controller
    {
        public ActionResult Index()
        {
            var handler = new CompanyHandler();
            var companyList = handler.GetCompanies();
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
                var handler = new CompanyHandler();
                handler.Create(model);
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
            var handler = new CompanyHandler();
            var model = handler.Get(id);

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
                var handler = new CompanyHandler();
                var success = handler.Update(model.Id, model);

                if (success)
                {
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
            var handler = new CompanyHandler();
            var model = handler.Get(id);

            if(model != null)
            {
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            var handler = new CompanyHandler();
            var success = handler.Delete(id);

            if (success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }


    }
}
