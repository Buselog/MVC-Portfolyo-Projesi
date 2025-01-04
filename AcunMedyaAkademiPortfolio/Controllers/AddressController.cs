using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolio.Models;

namespace AcunMedyaAkademiPortfolio.Controllers
{
    public class AddressController : Controller
    {
        PortfolioEntities db = new PortfolioEntities();
        public ActionResult AddressList()
        {
            var values = db.TblAdress.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult UpdateAddress(int id)
        {
            var values = db.TblAdress.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateAddress(TblAdress p)
        {
            var values = db.TblAdress.Find(p.AdressId);
            values.Adress = p.Adress;
            values.Phone = p.Phone;
            values.Email = p.Email;
            values.Website = p.Website;
            db.SaveChanges();
            return RedirectToAction("AddressList");
        }
    }
}