using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models;

namespace PortfolioProject.Controllers
{
    public class FeatureController : Controller
    {
        PortfolioProjectEntities db = new PortfolioProjectEntities();
        // GET: Feature
        public ActionResult Index()
        {
            var values = db.TblFeatures.ToList();
            return View(values);
        }

        public ActionResult AddFeature()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFeature(TblFeatures features)
        {
            db.TblFeatures.Add(features);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteFeature(int id) 
        {
            var value = db.TblFeatures.Find(id);
            db.TblFeatures.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var feature = db.TblFeatures.Find(id);
            return View(feature);
        }

        [HttpPost]
        public ActionResult UpdateFeature(TblFeatures features)
        {
            var value = db.TblFeatures.Find(features.FeatureId);
           value.NameSurname = features.NameSurname;
            value.Title = features.Title;
            value.ImageUrl = features.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}