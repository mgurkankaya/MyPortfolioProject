using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PortfolioProject.Controllers
{
    public class TestimonialController : Controller
    {
        PortfolioProjectEntities db = new PortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblTestimonials.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonial(TblTestimonials tblTestimonials)
        {
            db.TblTestimonials.Add(tblTestimonials);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTestimonial(int id)
        {

            var testimonial = db.TblTestimonials.Find(id);
            db.TblTestimonials.Remove(testimonial);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var testimonial = db.TblTestimonials.Find(id);
            return View(testimonial);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonials tblTestimonials)
        {
            var value = db.TblTestimonials.Find(tblTestimonials.TestimonialId);
            value.ImageUrl = tblTestimonials.ImageUrl;
            value.Comment = tblTestimonials.Comment;
            value.NameSurname = tblTestimonials.NameSurname;
            value.Title = tblTestimonials.Title;
            value.Status = tblTestimonials.Status;
            value.CommentDate = tblTestimonials.CommentDate;
           
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}