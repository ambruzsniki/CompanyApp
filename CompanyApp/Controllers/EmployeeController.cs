using CompanyApp.Handler;
using CompanyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyApp.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            var handler = new EmployeeHandler();
            List<Employee> employeeList = handler.GetEmployees();
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
                var handler = new EmployeeHandler();
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
            var handler = new EmployeeHandler();
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
        public ActionResult Edit(Employee model)
        {
            if (ModelState.IsValid)
            {
                var handler = new EmployeeHandler();
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
            var handler = new EmployeeHandler();
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
        public ActionResult Delete(int id, FormCollection form)
        {
            var handler = new EmployeeHandler();
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

        public static List<Company> GetCompanies()
        {
            var handler = new CompanyHandler();
            List<Company> companyList = handler.GetCompanies().ToList();
            //List<SelectListItem> list = new List<SelectListItem>();
            //companyList.ForEach(x => list.Add(new SelectListItem() { Text = x.CompanyName, Value = x.Id.ToString() }));
            return companyList;
        }
    }
}