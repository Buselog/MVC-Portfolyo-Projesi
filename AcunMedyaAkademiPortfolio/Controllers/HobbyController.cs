using System.Linq;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolio.Models;

namespace AcunMedyaAkademiPortfolio.Controllers
{
    public class HobbyController : Controller
    {
        PortfolioEntities db = new PortfolioEntities();
        public ActionResult HobbyList()
        {
            var values = db.TblHobby.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult CreateHobby()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateHobby(TblHobby p)
        {
            db.TblHobby.Add(p);
            db.SaveChanges();
            return RedirectToAction("HobbyList");
        }


        public ActionResult DeleteHobby(int id)
        {
            var values = db.TblHobby.Find(id);
            db.TblHobby.Remove(values);
            db.SaveChanges();
            return RedirectToAction("HobbyList");
        }

        [HttpGet]
        public ActionResult UpdateHobby(int id)
        {
            var values = db.TblHobby.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateHobby(TblHobby p)
        {
            if (!ModelState.IsValid) return View("UpdateHobby");

            var values = db.TblHobby.Find(p.HobbyId);
            values.IconUrl = p.IconUrl;
            values.Title = p.Title;
            db.SaveChanges();
            return RedirectToAction("HobbyList");
        }

    }
}