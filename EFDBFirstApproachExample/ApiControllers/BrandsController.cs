using EFDBFirstApproachExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EFDBFirstApproachExample.ApiControllers
{
    public class BrandsController : ApiController
    {
        public List<Brand> Get()
        {
            CompanyDbContext db = new CompanyDbContext();
             List<Brand> brand=db.Brands.ToList();
            return brand;
        }
    }
}
