using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models;

namespace PortfolioProject.Controllers
{
    public class TeamController : Controller
    {
        PortfolioProjectEntities db = new PortfolioProjectEntities();   
        public ActionResult Index()
        {
            var value = db.TblTeams.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddTeam()
        {
           return View();
        }

        [HttpPost]
        public ActionResult AddTeam(TblTeams tblTeams)
        {
            db.TblTeams.Add(tblTeams);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTeam(int id)
        {
            var team = db.TblTeams.Find(id);
            db.TblTeams.Remove(team);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTeam(int id)
        {
            var team = db.TblTeams.Find(id);
            return View(team);
        }
        [HttpPost]
        public ActionResult UpdateTeam(TblTeams tblTeams)
        {
            var value = db.TblTeams.Find(tblTeams.TeamId);
            value.ImageUrl = tblTeams.ImageUrl;
            value.NameSurname = tblTeams.NameSurname;
            value.Title = tblTeams.Title;
            value.Description = tblTeams.Description;
            value.TwitterUrl = tblTeams.TwitterUrl;
            value.FacebookUrl = tblTeams.FacebookUrl;
            value.InstagramUrl = tblTeams.InstagramUrl;
            value.LinkedInUrl = tblTeams.LinkedInUrl;
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}