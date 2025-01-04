using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolio.Models;

namespace AcunMedyaAkademiPortfolio.Controllers
{
    public class FeatureController : Controller
    {
        PortfolioEntities db = new PortfolioEntities();
        public ActionResult FeatureList()
        {
            var values = db.TblFeature.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var values = db.TblFeature.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateFeature(TblFeature p)
        {
            var values = db.TblFeature.Find(p.FeatureId);
            values.FeatureTitle = p.FeatureTitle;
            values.FeatureSubtitle = p.FeatureSubtitle;
            values.FeatureImageUrl = p.FeatureImageUrl;
            db.SaveChanges();
            return RedirectToAction("FeatureList");
        }
    }
}