using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolio.Models;

namespace AcunMedyaAkademiPortfolio.Controllers
{
    public class DefaultController : Controller
    {
        PortfolioEntities db = new PortfolioEntities();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartialFeature()
        {
            var values = db.TblFeature.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialAbout()
        {
            var values = db.TblAbout.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialProfile()
        {
            var values = db.TblProfile.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialHobby()
        {
            var values = db.TblHobby.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialSkill()
        {
            var values = db.TblSkill.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialStatistic()
        {
            var skillCount = db.TblSkill.ToList().Count();
            ViewBag.SkillCount = skillCount;

            var projectCount = db.TblProject.ToList().Count();
            ViewBag.ProjectCount = projectCount;

            var testimonialCount = db.TblTestimonial.ToList().Count();
            ViewBag.TestimonialCount = testimonialCount;

            var servicesCount = db.TblService.ToList().Count();
            ViewBag.ServicesCount = servicesCount;

            return PartialView();
        }

        public PartialViewResult PartialService()
        {
            var values = db.TblService.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialProject()
        {
            var values = db.TblProject.ToList();

            //// Projelerin kategorilerini çekelim
            //ViewBag.ProjectCategoryNames = db.TblProject
            //    .Join(db.TblCategory,
            //          project => project.ProjectCategory,
            //          category => category.CategoryId,
            //          (project, category) => new
            //          {
            //              project.ProjectCategory,
            //              category.CategoryName
            //          })
            //    .ToList(); // Liste olarak al

            return PartialView(values);
        }


        public PartialViewResult PartialTestimonial()
        {
            var values = db.TblTestimonial.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialAddress()
        {
            var values = db.TblAdress.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult PartialContact()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult PartialContact(TblContact p)
        {
            db.TblContact.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }

        public PartialViewResult PartialSocialMedia()
        {
            var values = db.TblSocialMedia.ToList();
            return PartialView(values);
        }


        public PartialViewResult PartialFooterService()
        {
            var values = db.TblService.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialFooterAddress()
        {
            var values = db.TblAdress.ToList();
            return PartialView(values);
        }
    }
}