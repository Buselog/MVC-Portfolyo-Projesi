using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolio.Models;

namespace AcunMedyaAkademiPortfolio.Controllers
{
    public class ContactController : Controller
    {
        PortfolioEntities db = new PortfolioEntities();
        public ActionResult ContactList()
        {
            var values = db.TblContact.ToList();
            return View(values);
        }
    }
}