﻿using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{

    public class ContactController : Controller
    {
        PortfolioProjectEntities db = new PortfolioProjectEntities();
        // GET: Contact
        public ActionResult Index()
        {
            var values = db.TblContacts.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(TblContacts contacts)
        {
            db.TblContacts.Add(contacts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteContact(int id) 
        { 
            var contact = db.TblContacts.Find(id);
            db.TblContacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult UpdateContact(int id) 
        {
            var contact = db.TblContacts.Find(id);
            return View(contact);
        }

        [HttpPost]
        public ActionResult UpdateContact(TblContacts contacts)
        {
            var value = db.TblContacts.Find(contacts.ContactId);
            value.NameSurname = contacts.NameSurname;
            value.Adress = contacts.Adress;
            value.Phone = contacts.Phone;
            value.Email = contacts.Email;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }




}