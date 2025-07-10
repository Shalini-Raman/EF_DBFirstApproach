using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDBFirstApproachNew.Models;

namespace EFDBFirstApproachNew.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            CompanyDBContext devHPEntities = new CompanyDBContext();
            //DevHPEntities devHPEntities = new DevHPEntities();
            List<categories> categories= devHPEntities.Categories.ToList();
            return View(categories);
        }
    }
}