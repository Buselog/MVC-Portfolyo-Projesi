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
            
            return View();
        }
    }
}