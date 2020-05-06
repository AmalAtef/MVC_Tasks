using MVCDay2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDay2.Controllers
{
    public class EmployeesController : Controller
    {
        ModelContext context = new ModelContext();
        public ViewResult Index()
        {
            return View(context.Employees.ToList());
        }

        public ViewResult Add()
        {
            return View();
        }
        public ViewResult Details(int id)
        {
            return View(context.Employees.FirstOrDefault(e=>e.Id==id));
        }

        public ViewResult Edit(int id)
        {
            return View(context.Employees.FirstOrDefault(e => e.Id == id));
        }


        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                Employee employee = context.Employees.FirstOrDefault(e => e.Id == emp.Id);
                employee.Name = emp.Name;
                employee.Email = emp.Email;
                employee.Age = emp.Age;
                employee.Gender = emp.Gender;
                employee.Address = emp.Address;
                employee.Salary = emp.Salary;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {

            context.Employees.Remove(context.Employees.FirstOrDefault(e => e.Id == id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Add(Employee emp)
        {
            if (ModelState.IsValid)
            {
                context.Employees.Add(emp);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}