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
            return View(employeeList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                var company = companyList.Find(x => x.CompanyName.Equals(model.CompanyName));
                model.Company = company;
                employeeList.Add(model);
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
        public ActionResult Edit(Employee model)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Delete(string name)
        {
            Employee selectedItem = employeeList.Find(x => x.Name.Equals(name));

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
        public ActionResult Delete(string name, FormCollection form)
        {
            var selectedEmployee = employeeList.Find(x => x.Name.Equals(name));
            employeeList.Remove(selectedEmployee);
            return RedirectToAction("Index");
        }

    }
}