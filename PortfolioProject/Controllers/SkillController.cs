using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models;

namespace PortfolioProject.Controllers
{
    public class SkillController : Controller
    {
        PortfolioProjectEntities db = new PortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblSkills.ToList();
            return View(values);
        }
    }
}