using CompanyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static CompanyApp.Init;

namespace CompanyApp.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            List<Employee> model = employeeList;

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Company model)
        {
            return View();
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
            Employee selectedItem = employeeList.Find(x => x.Id == id);

            if (selectedItem != null)
            {
                return View(selectedItem);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            var selectedCompany = employeeList.Find(x => x.Id == id);
            employeeList.Remove(selectedCompany);
            return RedirectToAction("Index");
        }

    }
}