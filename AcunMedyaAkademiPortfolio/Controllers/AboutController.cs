using System;
using System.Linq;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolio.Models;

namespace AcunMedyaAkademiPortfolio.Controllers
{
    public class AboutController : Controller
    {

        PortfolioEntities db = new PortfolioEntities();

        public ActionResult Index()
        {
            var values = db.TblAbout.ToList();
            return View(values);
        }


        //Güncelleme sayfası getirilsin:

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            //Güncelleme sayfası getirilirken, güncellenecek verinin id'si gönderilir ve önce id'ye göre güncellenmek istenen satır bulunur(Find)
            //View tarafına bu bulunan satır verileri gönderilir. Şu anki veriler gösterilir. Kullanıcı dilerse bu veriler üzerinde değişiklik yapar.
            var values = db.TblAbout.Find(id);
            return View(values);
        }

        //Herhangi bir veri değiştirildiğinde post altındaki fonksiyon ile güncelleme işlemi yapılsın:

        [HttpPost]
        public ActionResult UpdateAbout(TblAbout p)
        {
            var values = db.TblAbout.Find(p.AboutId);
            values.Title = p.Title;
            values.Description = p.Description;
            values.ImageUrl = p.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}