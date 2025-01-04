using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolio.Models;

namespace AcunMedyaAkademiPortfolio.Controllers
{
    public class ServiceController : Controller
    {
        PortfolioEntities db = new PortfolioEntities();
        
        public ActionResult ServiceList()
        {
            var values = db.TblService.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateService(TblService p)
        {
            db.TblService.Add(p);
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }


        public ActionResult DeleteService(int id)
        {
            var values = db.TblService.Find(id);
            db.TblService.Remove(values);
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var values = db.TblService.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateService(TblService p)
        {
            var values = db.TblService.Find(p.ServicesId);
            values.Title = p.Title;
            values.Description = p.Description;
            values.IconUrl = p.IconUrl;
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }
    }
}