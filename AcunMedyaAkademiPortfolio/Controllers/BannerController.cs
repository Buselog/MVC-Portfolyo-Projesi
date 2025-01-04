using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolio.Models;

namespace AcunMedyaAkademiPortfolio.Controllers
{
    public class BannerController : Controller
    {
        PortfolioEntities db = new PortfolioEntities();
        public ActionResult BannerList()
        {
            var values = db.TblBanner.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateBanner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBanner(TblBanner p)
        {
            db.TblBanner.Add(p);
            db.SaveChanges();
            return RedirectToAction("BannerList");
        }

        public ActionResult DeleteBanner(int id)
        {
            var values = db.TblBanner.Find(id);
            db.TblBanner.Remove(values);
            db.SaveChanges();
            return RedirectToAction("BannerList");
        }


        [HttpGet]
        public ActionResult UpdateBanner(int id)
        {
            var values = db.TblBanner.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateBanner(TblBanner p)
        {
            var values = db.TblBanner.Find(p.BannerId);
            values.Title = p.Title;
            values.Description = p.Description;
            values.ImageUrl = p.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("BannerList");
        }
    }
}