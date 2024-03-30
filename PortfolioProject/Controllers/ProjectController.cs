using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class ProjectController : Controller
    {
      PortfolioProjectEntities db = new PortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TlbProjects.ToList();
            return View(values);
        }

        public ActionResult AddProject()
        {
            var categories = db.TblCategories.ToList();


            List<SelectListItem> categoryList = (from x in categories select new SelectListItem
            {
                Text= x.CategoryName,
                Value=x.CategoryId.ToString()
            }).ToList();
              
            ViewBag.category = categoryList;
            return View();
        }

        [HttpPost]
        public ActionResult AddProject(TlbProjects projects)
        {
            db.TlbProjects.Add(projects);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var categories = db.TblCategories.ToList();


            List<SelectListItem> categoryList = (from x in categories
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();

            ViewBag.category = categoryList;
            var value = db.TlbProjects.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProject(TlbProjects projects)
        {
            var value = db.TlbProjects.Find(projects.ProjectId);
            value.ProjectName = projects.ProjectName;
            value.ImageUrl = projects.ImageUrl;
            value.GithubUrl = projects.GithubUrl;
            value.CategoryId = projects.CategoryId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProject(int id)
        {
            var value = db.TlbProjects.Find(id);
            db.TlbProjects.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}