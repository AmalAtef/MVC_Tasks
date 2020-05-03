using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDay1.Controllers
{
    public class User{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Choice { get; set; }
    }

    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Form()
        { 
            return View();
        }

        [HttpPost]
        public ViewResult Form(User user)
        {
            if (user.Name!= null && user.Email != null)
            {
                ViewBag.Name = user.Name;
                return View("Welcome");
            }
            return View();
        }

    }
}