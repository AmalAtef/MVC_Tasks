using MVCDay2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDay2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Index(Employee emp)
        {
            if (ModelState.IsValid)
            {
                ModelContext context = new ModelContext();
                var e = context.employess.Add(emp);
                var r=context.SaveChanges();
                if (r > 0) {
                    ViewBag.Name = emp.Name;
                    return View("SucessAdded", emp);
                }
                else return View();

            }
            return View();
        }

    }
}