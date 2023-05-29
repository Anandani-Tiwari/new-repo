using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDBFirstApproachExample.Models;
namespace EFDBFirstApproachExample.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Admin/Products/Index
        public ActionResult Index(string search = "", int PageNo = 1, string IconClass = "fa-sort-asc", string SortColumn = "ProductId")
        {
            ViewBag.search = search;
            ViewBag.IconClass = IconClass;
            ViewBag.SortColumn = SortColumn;
            CompanyDbContext db = new CompanyDbContext();
            List<Product> product = db.Products.Where(temp => temp.ProductName.Contains(search)).ToList();

            //sorting
            if (ViewBag.SortColumn == "ProductId")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    product = product.OrderBy(temp => temp.ProductId).ToList();
                }
                else
                {
                    product = product.OrderByDescending(temp => temp.ProductId).ToList();
                }
            }

            if (ViewBag.SortColumn == "ProductName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    product = product.OrderBy(temp => temp.ProductName).ToList();
                }
                else
                {
                    product = product.OrderByDescending(temp => temp.ProductName).ToList();
                }
            }

            if (ViewBag.SortColumn == "BrandId")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    product = product.OrderBy(temp => temp.BrandId).ToList();
                }
                else
                {
                    product = product.OrderByDescending(temp => temp.BrandId).ToList();
                }
            }

            if (ViewBag.SortColumn == "CategoryId")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    product = product.OrderBy(temp => temp.CategoryId).ToList();
                }
                else
                {
                    product = product.OrderByDescending(temp => temp.CategoryId).ToList();
                }
            }
            if (ViewBag.SortColumn == "Price")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    product = product.OrderBy(temp => temp.Price).ToList();
                }
                else
                {
                    product = product.OrderByDescending(temp => temp.Price).ToList();
                }
            }

            if (ViewBag.SortColumn == "AvailabilityStatus")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    product = product.OrderBy(temp => temp.AvailabilityStatus).ToList();
                }
                else
                {
                    product = product.OrderByDescending(temp => temp.AvailabilityStatus).ToList();
                }
            }

            if (ViewBag.SortColumn == "DateOfPurchase")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    product = product.OrderBy(temp => temp.DateOfPurchase).ToList();
                }
                else
                {
                    product = product.OrderByDescending(temp => temp.DateOfPurchase).ToList();
                }
            }
            if (ViewBag.SortColumn == "Price")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    product = product.OrderBy(temp => temp.Price).ToList();
                }
                else
                {
                    product = product.OrderByDescending(temp => temp.Price).ToList();
                }
            }

            //paging
            int NoOfRecordsPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(product.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            product = product.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
            return View(product);
        }
        //retrieve single line data
        public ActionResult Details(int id)
        {
            CompanyDbContext db = new CompanyDbContext();
            Product p = db.Products.Where(temp => temp.ProductId == id).FirstOrDefault();
            return View(p);
        }
        //creating new product
        public ActionResult Create()
        {
            CompanyDbContext db = new CompanyDbContext();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,DateOfPurchase,AvailabilityStatus,CategoryId,BrandId")] Product p)
        {
            CompanyDbContext db = new CompanyDbContext();
            if (ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    p.Photo = base64String;
                }

                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}