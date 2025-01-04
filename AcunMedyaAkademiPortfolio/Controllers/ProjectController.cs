using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolio.Models;

namespace AcunMedyaAkademiPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        PortfolioEntities db = new PortfolioEntities();
        public ActionResult ProjectList()
        {
            var values = db.ProjectCategoryName();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            List<SelectListItem> degerler = (from i in db.TblCategory.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.CategoryName,
                                                 Value = i.CategoryId.ToString()
                                             }).ToList();

            ViewBag.dgr = degerler;                               
                                        
            return View();
        }
        [HttpPost]
        public ActionResult CreateProject(TblProject p)
        {
            db.TblProject.Add(p);
            db.SaveChanges();
            return RedirectToAction("ProjectList");
        }

        public ActionResult DeleteProject(int id)
        {
            var values = db.TblProject.Find(id);
            db.TblProject.Remove(values);
            db.SaveChanges();
            return RedirectToAction("ProjectList");
        }


        [HttpGet]
        public ActionResult UpdateProject(int id)
        {

            List<SelectListItem> degerler = (from i in db.TblCategory.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.CategoryName,
                                                 Value = i.CategoryId.ToString()
                                             }).ToList();

            ViewBag.dgr = degerler;


            var values = db.TblProject.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateProject(TblProject p)
        {
            var values = db.TblProject.Find(p.ProjectId);
            values.ProjectName = p.ProjectName;
            values.ProjectImageUrl = p.ProjectImageUrl;
            values.ProjectCategory = p.ProjectCategory;
            db.SaveChanges();
            return RedirectToAction("ProjectList");
        }
    }
}