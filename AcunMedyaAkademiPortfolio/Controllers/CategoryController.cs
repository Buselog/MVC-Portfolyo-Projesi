using AcunMedyaAkademiPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaAkademiPortfolio.Controllers
{
    public class CategoryController : Controller
    {
        PortfolioEntities db = new PortfolioEntities();
        public ActionResult CategoryList()
        {
            var values = db.TblCategory.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(TblCategory newTbl)
        {
            db.TblCategory.Add(newTbl);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public ActionResult DeleteCategory(int id)
        {
            var values = db.TblCategory.Find(id); //Silinecek satırı id sayesinde bulur
            db.TblCategory.Remove(values);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var values = db.TblCategory.Find(id);
            return View(values); //Bu fonksiyondan türetilen View sayfasına güncellenecek satırın bilgilerini buldu ve gönderdi.
        }


        [HttpPost]
        public ActionResult UpdateCategory(TblCategory tbl)
        {
            var values = db.TblCategory.Find(tbl.CategoryId); //Id zaten değişmeyen readOnly alan olduğundan update edilmiş tablodan çekilebilir
            values.CategoryName = tbl.CategoryName;
            db.SaveChanges();
            return RedirectToAction("CategoryList");

        }



    }
}