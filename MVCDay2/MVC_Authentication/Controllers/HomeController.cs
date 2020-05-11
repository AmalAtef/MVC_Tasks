using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVC_Authentication.Models;

namespace MVC_Authentication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            //ApplicationUserManager userManager =
            //    new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            //ApplicationUser adminUser = userManager.FindByEmail("Admin@gmail.com");
            //ApplicationUser managerUser = userManager.FindByEmail("Manager@gmail.com");
            //ApplicationUser clientUser = userManager.FindByEmail("Client@gmail.com");

            //userManager.AddToRole(adminUser.Id, "Admin");
            //userManager.AddToRole(managerUser.Id, "Manager");
            //userManager.AddToRole(clientUser.Id, "Client");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles ="Admin")]
        public ActionResult ForAdmin()
        {
            return View();
        }
        [Authorize(Roles = "Admin , Manager")]
        public ActionResult ForManager()
        {
            return View();
        }
        [Authorize(Roles = "Admin , Client")]
        public ActionResult ForClient()
        {
            return View();
        }

        public ActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRole(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
                roleManager.Create(role);
                return RedirectToAction("Index");
            }
            return View();

        }

    }
}