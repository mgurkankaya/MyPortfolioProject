using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class MessageController : Controller
    {
        PortfolioProjectEntities db = new PortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblMessages.ToList();
            return View(values);
        }

        public ActionResult DeleteMessage(int id)
        {

            var message = db.TblMessages.Find(id);
            db.TblMessages.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult UpdateMessage(int id)
        {
            var value = db.TblMessages.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateMessage(TblMessages messages)
        {
            var value = db.TblMessages.Find(messages.MessageId);
            value.Name = messages.Name;
            value.Email = messages.Email;
            value.Subject = messages.Subject;
            value.MessageContent = messages.MessageContent;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}


