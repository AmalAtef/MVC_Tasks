﻿using MVCDay2.Models;
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

    }
}