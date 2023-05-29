using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDBFirstApproachExample.Models;
using EFDBFirstApproachExample.Filters;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace EFDBFirstApproachExample.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        //[MyAuthenticationFilter]
        //[CustomerAuthorization]
       
       
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();
          List<Product> product = db.Products.ToList();
            return View(product);
        }

        [HttpPost]
        public ActionResult pg([DataSourceRequest] DataSourceRequest request)
        {
            CompanyDbContext db = new CompanyDbContext();
            List<Product> products = products = db.Products.ToList();

            return Json(products.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


    }
}