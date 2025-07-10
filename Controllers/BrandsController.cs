using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDBFirstApproachNew.Models;

namespace EFDBFirstApproach.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Brands
        public ActionResult Index()
        {
            CompanyDBContext devHPEntities = new CompanyDBContext();
            //DevHPEntities devHPEntities = new DevHPEntities();
            List<Brands> brands = devHPEntities.Brands.ToList();
            return View(brands);
        }
    }
}