﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFDBFirstApproachExample.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home/Index
        public ActionResult Index()
        {
            return View();
        }
    }
}