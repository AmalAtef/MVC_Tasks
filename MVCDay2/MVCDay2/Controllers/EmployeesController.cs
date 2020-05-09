using MVCDay2.Models;
using MVCDay2.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            EmployeeViewModel employeeVM = new EmployeeViewModel {
                Employees = context.Employees.ToList(),
                Departments=context.Departments.ToList()
            };
            return View(employeeVM);
        }

        public ViewResult Add()
        {
            ViewBag.Action = "Add";
            EmployeeViewModel employeeVM = new EmployeeViewModel
            {
                Departments = context.Departments.ToList()
            };

            return View("EmployeeForm",employeeVM);
        }
        public ViewResult Details(int id)
        {
            return View(context.Employees.FirstOrDefault(e=>e.Id==id));
        }

        public ActionResult Edit(int id)
        {
            Employee emp = context.Employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                ViewBag.Action = "Edit";
                EmployeeViewModel employeeVM = new EmployeeViewModel
                {
                    Departments = context.Departments.ToList()
                };
                return View("EmployeeForm",employeeVM);
            }
            return HttpNotFound("Employee not found");
        }


        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                context.Employees.Attach(emp);
                context.Entry(emp).State = EntityState.Modified;
                context.SaveChanges();
                TempData["Message"] = "Employee Edited Successfully";
                return RedirectToAction("Index");
            }
            ViewBag.Action = "Edit";
            EmployeeViewModel employeeVM = new EmployeeViewModel
            {
                Departments = context.Departments.ToList()
            };
            return View("EmployeeForm",employeeVM);
        }

        public ActionResult Delete(int id)
        {
            Employee emp = context.Employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
            context.Employees.Remove(emp);
            context.SaveChanges();
                //return RedirectToAction("Index");
                return Json(true);

            }
            return HttpNotFound("Employee not found");
        }

        [HttpPost]
        public ActionResult Add(Employee emp)
        {
            if (ModelState.IsValid)
            {
                context.Employees.Add(emp);
                context.SaveChanges();
                TempData["Message"] = "Employee Added Successfully";
                return RedirectToAction("Index");
            }
            ViewBag.Action = "Add";
            EmployeeViewModel employeeVM = new EmployeeViewModel
            {
                Departments = context.Departments.ToList()
            };
            return View("EmployeeForm", employeeVM);
        }

        [HttpPost]
        public ActionResult AddAjax(Employee employee)
        {
            if (ModelState.IsValid)
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                TempData["Message"] = "Employee Added Successfully";
                return PartialView("_EmpoyeePartial");
            }
            return Json(ModelState);
        }
    }
}