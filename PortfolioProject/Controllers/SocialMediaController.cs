using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models;

namespace PortfolioProject.Controllers
{
    public class SocialMediaController : Controller
    {
        PortfolioProjectEntities db = new PortfolioProjectEntities();
        public ActionResult Index()
        {
            var value = db.TblSocialMedias.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocialMedia(TblSocialMedias socialMedias)
        {
            db.TblSocialMedias.Add(socialMedias);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var socialmedia = db.TblSocialMedias.Find(id);
            db.TblSocialMedias.Remove(socialmedia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var socialMedia = db.TblSocialMedias.Find(id);
            return View(socialMedia);
        }


        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedias socialMedias)
        {
            var value = db.TblSocialMedias.Find(socialMedias.SocialMediaId);
            value.SocialMediaName = socialMedias.SocialMediaName;
            value.Url = socialMedias.Url;
            value.Icon = socialMedias.Icon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}