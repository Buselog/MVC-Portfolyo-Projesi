using AcunMedyaAkademiPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaAkademiPortfolio.Controllers
{
    public class StatisticController : Controller
    {
        PortfolioEntities db = new PortfolioEntities();
        // GET: Statistic
        public ActionResult Index()
        {
            //Controller'dan View'a veri taşımaya yarayan yapı: ViewBag
            ViewBag.categoryCount = db.TblCategory.Count();
            ViewBag.projectCount = db.TblProject.Count();
            ViewBag.skillCount = db.TblSkill.Count();
            ViewBag.skillAvgValue = db.TblSkill.Average(x=>x.Value);
            ViewBag.getLastSkillTitle = db.GetLastSkillTitle().FirstOrDefault();
            ViewBag.SocialMediaCount = db.TblSocialMedia.Count();
            ViewBag.HobbyCount = db.TblHobby.Count();
            ViewBag.GetLatProjectName = db.GetLastProjectName().FirstOrDefault();
            ViewBag.GetLastSocialMediaName = db.GetLastSocialMediaName().FirstOrDefault();
            ViewBag.GetLastTestimonialName = db.GetLastTestimonialName().FirstOrDefault();
            

            
            return View();
        }
    }
}