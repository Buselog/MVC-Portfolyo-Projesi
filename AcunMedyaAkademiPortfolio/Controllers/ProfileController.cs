using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolio.Models;

namespace AcunMedyaAkademiPortfolio.Controllers
{
    public class ProfileController : Controller
    {
        PortfolioEntities db = new PortfolioEntities();

        public ActionResult ProfileList()
        {
            var values = db.TblProfile.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult UpdateProfile(int id)
        {
            var values = db.TblProfile.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateProfile(TblProfile p)
        {
            var values = db.TblProfile.Find(p.ProfileId);
            values.Name = p.Name;
            values.Birthday = p.Birthday;
            values.Address = p.Address;
            values.Email = p.Email;
            values.Telefon = p.Telefon;
            db.SaveChanges();
            return RedirectToAction("ProfileList");
        }


    }
}