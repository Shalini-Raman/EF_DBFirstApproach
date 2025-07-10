using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDBFirstApproachNew.Models;

namespace EFDBFirstApproachNew.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        //  EFDBFirstApproach Code
        // DevHPEntities devHPEntities = new DevHPEntities();
        //Code First
        CompanyDBContext devHPEntities = new CompanyDBContext();
        public ActionResult Index(string search="",string SortColumn= "ProductName", String IconClass= "fa-sort-asc",int pageNo=1)
        {

            //Retrieve all the rows
            //    DevHPEntities devHPEntities = new DevHPEntities();
            //    List<Product> products= devHPEntities.Products.ToList();
            //    return View(products);

            // Retrieving Rows based on Filter
            //DevHPEntities devHPEntities = new DevHPEntities();
            //List<Product> products = devHPEntities.Products.Where(temp => temp.CategoryID == 1 && temp.Price >= 50000).ToList();
            //return View(products);

            //Retriving Based On Stored Procedure
            //DevHPEntities devHPEntities = new DevHPEntities();
            //SqlParameter[] sqlParameters = new SqlParameter[]
            //{
            //    new SqlParameter("@BrandID",2)
            //};

            //List<Product> products1 = devHPEntities.Database.SqlQuery<Product>("exec getProductsByBrandID @BrandID", sqlParameters).ToList();
            //return View(products1);

            //SearchBox
          //  DevHPEntities devHPEntities = new DevHPEntities();
            ViewBag.Search = search;
            List<Products> products = devHPEntities.Products.Where(temp => temp.ProductName.Contains(search)).ToList();
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;

            if (ViewBag.SortColumn == "ProductID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.ProductID).ToList();
                else
                    products = products.OrderByDescending(temp => temp.ProductID).ToList();
            }

            else if (ViewBag.SortColumn == "ProductName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.ProductName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.ProductName).ToList();
            }

            else if (ViewBag.SortColumn == "DateOfPurchase")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.DOP).ToList();
                else
                    products = products.OrderByDescending(temp => temp.DOP).ToList();
            }

            else if (ViewBag.SortColumn == "Price")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Price).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Price).ToList();
            }

            else if (ViewBag.SortColumn == "CategoryID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.category.CategoryName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.category.CategoryName).ToList();
            }
            else if (ViewBag.SortColumn == "BrandID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Brand.BrandName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Brand.BrandName).ToList();
            }

            int NoOfRecordsPerPage = 5;
            int NoOfpages =Convert.ToInt16(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordstoSkip = (pageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = pageNo;
            ViewBag.NoOfPages = NoOfpages;
            products = products.Skip(NoOfRecordstoSkip).Take(NoOfRecordsPerPage).ToList();
            return View(products);
        }
        public ActionResult Details(long id)
        {
            //DevHPEntities devHPEntities = new DevHPEntities();
            Products products = devHPEntities.Products.Where(temp => temp.ProductID==id).FirstOrDefault();
            return View(products);
        }

        public ActionResult Create()
        {
           // DevHPEntities devHPEntities = new DevHPEntities();
            ViewBag.Categories = devHPEntities.Categories.ToList();
            ViewBag.Brands = devHPEntities.Brands.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include= "ProductID,ProductName,active,CategoryID,BrandID,DOP,AvailabilityStatus,Price")]Products product)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imageBytes = new Byte[file.ContentLength - 1];
                    file.InputStream.Read(imageBytes, 0, file.ContentLength - 1);
                    var base64String = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                    product.Photo = base64String;
                }
                devHPEntities.Products.Add(product);
                devHPEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = devHPEntities.Categories.ToList();
                ViewBag.Brands = devHPEntities.Brands.ToList();
                return View("Create");
            }
            //DevHPEntities devHPEntities = new DevHPEntities();
           
        }

        public ActionResult Edit(int Id)
        {
            //DevHPEntities devHPEntities = new DevHPEntities();
            Products existingproduct = devHPEntities.Products.Where(temp => temp.ProductID == Id).FirstOrDefault();
            ViewBag.Categories = devHPEntities.Categories.ToList();
            ViewBag.Brands = devHPEntities.Brands.ToList();
            return View(existingproduct);
        }
        [HttpPost]
        public ActionResult Edit(Products P)
        {
            Products existingproduct = devHPEntities.Products.Where(temp => temp.ProductID == P.ProductID).FirstOrDefault();
            existingproduct.ProductName = P.ProductName;
            existingproduct.Price = P.Price;
            existingproduct.DOP = P.DOP;
            existingproduct.CategoryID = P.CategoryID;
            existingproduct.BrandID = P.BrandID;
            existingproduct.AvailabilityStatus = P.AvailabilityStatus;
            existingproduct.active = P.active;
            devHPEntities.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int Id)
        {
            //DevHPEntities devHPEntities = new DevHPEntities();
            Products existingproduct = devHPEntities.Products.Where(temp => temp.ProductID == Id).FirstOrDefault();
            return View(existingproduct);
        }
        [HttpPost]
        public ActionResult Delete(int id,Products P)
        {
            //DevHPEntities devHPEntities = new DevHPEntities();
            Products existingproduct = devHPEntities.Products.Where(temp => temp.ProductID ==id).FirstOrDefault();
            devHPEntities.Products.Remove(existingproduct);
            devHPEntities.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}