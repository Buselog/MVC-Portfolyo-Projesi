using System.Linq;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolio.Models;


namespace AcunMedyaAkademiPortfolio.Controllers
{

    public class TestimonialController : Controller
    {
        PortfolioEntities db = new PortfolioEntities(); //veritabanı bağlantısını açtık
     
        public ActionResult TestimonialList()
        {
            var values = db.TblTestimonial.ToList(); //TblTestimonial table'ına ulaşarak list ile tüm verilere erişip atadık
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTestimonial(TblTestimonial p)
        {
            db.TblTestimonial.Add(p);
            db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var value = db.TblTestimonial.Find(id);
            db.TblTestimonial.Remove(value);
            db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = db.TblTestimonial.Find(id);
            return View(value);
        }


        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonial p)
        {
            var value = db.TblTestimonial.Find(p.TestimonialId);
            value.TestimonialTitle = p.TestimonialTitle;
            value.TestimonialDescription = p.TestimonialDescription;
            value.TestimonialName = p.TestimonialName;
            value.TestimonialImageUrl = p.TestimonialImageUrl;
            db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }


    }
}