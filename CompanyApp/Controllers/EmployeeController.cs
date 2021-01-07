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
                var company = companyList.FirstOrDefault(x => x.Id == model.CompanyId);
                if (company != null)
                {
                    model.Company = company;
                    var idMaxVal = employeeList.Max(x => x.Id);
                    model.Id = idMaxVal + 1;
                    employeeList.Add(model);
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
        public ActionResult Edit(int id)
        {
            var model = employeeList.FirstOrDefault(x => x.Id == id);

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
        public ActionResult Edit(Employee model)
        {
            if (ModelState.IsValid)
            {
                var original = employeeList.FirstOrDefault(x => x.Id == model.Id);
                var company = companyList.FirstOrDefault(x => x.Id == model.CompanyId);

                if (original != null && company != null)
                {
                    original.Name = model.Name;
                    original.Email = model.Email;
                    original.PhoneNumber = model.PhoneNumber;
                    original.Position = model.Position;
                    original.CompanyId = model.CompanyId;
                    original.Company = company;
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
            Employee selectedItem = employeeList.FirstOrDefault(x => x.Id == id);

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
            var selectedEmployee = employeeList.FirstOrDefault(x => x.Id == id);

            if (selectedEmployee != null)
            {
                employeeList.Remove(selectedEmployee);
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }

    }
}