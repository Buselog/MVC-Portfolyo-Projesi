using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolio.Controllers;
using AcunMedyaAkademiPortfolio.Models;

namespace AcunMedyaAkademiPortfolio.Controllers
{
    public class SkillController : Controller
    {
        //Database'deki tabloları burada Models folder'ı altında tutuyorum.
        //Ve Sql tarafındaki her tablo, burada bir <Sınıf> olarak tutuluyor.
        //Tablonun sütunları da sınıfın özellikleri(propert) olarak yer alıyor.
        //Ben, database ile ilgili var olan sınıftan Nesne oluşturarak, o nesne üzerinden istediğim class'a(tabloya) ulaşmalı
        // ve o tablo üzerinden listeleme, ekleme, silme, güncelleme işlemleri yapmalıyım.
        PortfolioEntities db = new PortfolioEntities();
        public ActionResult SkilList()
        {
            var values = db.TblSkill.ToList();
            return View(values); //Bu fonksiyonun View tarafına verileri gönderiyor.
        }

        [HttpGet]


        //Henüz hiçbir işlem yapılmamışsa, yani eklenilecek veriler girilmemişse ve ekle butonuna basılmamışsa, 
        //sadece ilgili içeriğin View sayfasını getirmek istiyorsak bu actionResult fonksiyonu öncesinde [HttpGet] yazılmalı.

        //Sadece sayfa yüklemesinde bunu yap:
        public ActionResult CreateSkill()
        {
            return View();
        }


        //İlgili sayfada bir değer girme işlemi, bir veri kaydetme isteği gibi işlemler varsa,
        //kayıt için butona basma gibi olaylar işlendiyse [HttpPost] altındaki actionResult fonksiyonu çalışsın.
        //Bu fonksiyon görüldüğü üzere View() döndürmez, veri tabanına yeni satır ekleme ve kaydetme işlemi yapar. 
        //Bu işlemlerden sonra tekrar listelemenin yapıldığı sayfaya yönlendirir.

        //Bir işlem yapıldığında bunu yap:

        [HttpPost]
        public ActionResult CreateSkill(TblSkill p)
        {
            db.TblSkill.Add(p);
            db.SaveChanges();
            return RedirectToAction("SkilList");
            //Asp .Net tarafındaki Response.Redirect("Default.aspx") gibi bir yapı görüldüğü üzere.
        }

        public ActionResult DeleteSkill(int id)
        {
            var value = db.TblSkill.Find(id);
            db.TblSkill.Remove(value);
            db.SaveChanges();
            return RedirectToAction("SkilList");

        }

        [HttpGet]
        //Güncelleme sayfası geldiğinde ilgili satırın verileri gözüksün diye önce id'ye göre satırı bulma işlemi yapılır.
        //Açılan sayfaya bulunan ve güncellenecek satırın verileri gönderilir.
        public ActionResult UpdateSkill(int id)
        {
            var values = db.TblSkill.Find(id);
            return View(values); //Bu fonksiyondan türetilen View sayfasına güncellenecek satırın bilgilerini buldu ve gönderdi.
           

        }

        [HttpPost]

        //Yeni girilen Skill değerlerini barındıran TblSkill türünde tbl değerini argüman olarak alan
        //bir UpdateSkill fonksiyonu yazdık. Bu fonksiyon yalnızca post işlemi olduğunda çalışacak.

        public ActionResult UpdateSkill(TblSkill tbl)
        {
            var values = db.TblSkill.Find(tbl.SkillId); //Id zaten değişmeyen readOnly alan olduğundan update edilmiş tablodan çekilebilir
            values.Title = tbl.Title; //values içindeki tablo özellikleri eski,sql'deki özellikler, güncellenmiş veriler ise tbl tarafında.
            values.Value = tbl.Value;
            values.LastWeekValue = tbl.LastWeekValue;
            values.LastMonthValue = tbl.LastMonthValue;
            db.SaveChanges();
            return RedirectToAction("SkilList");

        }
    }
}