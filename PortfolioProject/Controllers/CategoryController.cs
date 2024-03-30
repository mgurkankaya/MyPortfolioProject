using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class CategoryController : Controller
    {
        PortfolioProjectEntities db = new PortfolioProjectEntities();
        // GET: Category
        public ActionResult Index()
        {
            var values = db.TblCategories.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(TblCategories categories)
        {
            db.TblCategories.Add(categories);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult DeleteCategory(int id)
        {

            var category = db.TblCategories.Find(id);
            db.TblCategories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = db.TblCategories.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(TblCategories categories)
        {
            var value = db.TblCategories.Find(categories.CategoryId);
            value.CategoryName = categories.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}