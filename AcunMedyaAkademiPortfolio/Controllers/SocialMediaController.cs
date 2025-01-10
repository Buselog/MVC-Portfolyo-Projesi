using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolio.Models;

namespace AcunMedyaAkademiPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        PortfolioEntities db = new PortfolioEntities();
        public ActionResult SocialMediaList()
        {
            var values = db.TblSocialMedia.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSocialMedia(TblSocialMedia p)
        {
            db.TblSocialMedia.Add(p);
            db.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }


        public ActionResult DeleteSocialMedia(int id)
        {
            var values = db.TblSocialMedia.Find(id);
            db.TblSocialMedia.Remove(values);
            db.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var values = db.TblSocialMedia.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedia p)
        {
            if (!ModelState.IsValid) return View("UpdateSocialMedia");

            var values = db.TblSocialMedia.Find(p.SocialMediaId);
            values.SocialMediaName = p.SocialMediaName;
            values.SocialMediaIcon = p.SocialMediaIcon;
            values.SocialMediaUrl = p.SocialMediaUrl;
            db.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
    }
}