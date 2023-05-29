using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDBFirstApproachExample.Filters;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using EFDBFirstApproachExample.Models;

namespace EFDBFirstApproachExample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult pp([DataSourceRequest] DataSourceRequest request)
        {
            List<Product> products = new List<Product>();
            return Json(products.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}