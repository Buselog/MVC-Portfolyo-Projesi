using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaAkademiPortfolio.Controllers

//    Veri tabanımızdaki her tablo için bir controller üretilmeli ve o controller'ın view tarafı
//yani kullanıcıya gösterilecek ön uç tarafı doldurulmalı.

{
    public class AdminLayoutController : Controller
    {
        // GET: AdminLayout

        // Solution exp -> Controllers folder -> sağ tık -> Add -> Controller -> MVC 5 Controller Empty
        // hiçbir kutucuğu seçmeden yeni bir isim ile yeni bir controller oluşturuyoruz.

        //Default olarak Index() isimli bir fonksiyon geliyor.Index üzerine sağ tık -> Add View -> MVC5 View 
        //hiçbir kutuyu işaretlemeden bu fonksiyon için bir View oluşturduk.

        //MVC -> Model -View - Controller yapısı nedir ?
        //Çok uzun zamandır var olan bir yazılım geliştirme deseni olarak düşünülebilir.
        //Hata yakalama kolaylığı, farklı grupların çalışabileceği, sürdürülebilir kodlama için proje 3 ana kısma ayrılır:
        //Model-> Datalarımızın, tablolarımızın olduğu kısımdır. Database buradadır.
        //View -> Uygulamanın kullanıcıya sunulacak kısmıyla burada ilgilenilir. Ön tarafta gösterilecek işler yani.
        //Controller -> Ara katmandır. Veri tabanıyla ilgili işlemler, verinin nasıl kullanılacağı burada gerçekleşir.
        //Model katmanından alınan veriler Controller'da işlenir, Controller'dan View'e kullanılmak, gösterilmek üzere gönderilir.

        //Şimdi Index() fonksiyonuna bir View oluşturduk.
        //Solution Exp kısmında Views -> AdminLayout->[@]Index.cshtml olarak bu View gözükecek.


        //Bu index fonksiyonunun view'i içerisine indirdiğimiz bootstrap projesinin sidebar-07 içerisindeki index chrome sayfasını açıp,
        // kaynak kodu görüntüleye basarak sayfanın html kodunu kopyalayıp Index view'ı içerisine yapıştıracağız. 
        //Çünkü view'da bulunan kodlar bizim ön tarafta kullanıcıya göstereceğimiz kısımları içermeli, başka bir şey içermemeli.
        public ActionResult Index() 
        {
            return View();
        }


        //Index View içerisine yapıştırdığımız, sitenin html kodları çok uzun. Bunların hepsinin tek bir sayfada tutulmaması gerekiyor.
       //Bu nedenle parçalara ayırmak gerekiyor. Sitenin bazı görünümlerini kod tarafında parçalara ayıracağız. 
       //Misal sidebar(soldaki sabit menü), navbar(üstteki sabit menü),
       //sayfanın dinamik hale gelmesini sağlayan ve javascript kodları içeren kısımlar, html'in body'den önce gelen head etiketinin alanı.
       //Bunları ayrı bir yerde tutabiliriz. Bu ayrı yerler, <<<Partial View>>> olarak adlandırılır.



        //HeadPartial() fonksiyon ismine sağ tık -> Add View -> MVC5 View -> Create As a Partial View kutucuğunu seçerek 
        //Views folder -> AdminLayout -> [@]HeadPartial.cshtml partial view'i görebiliriz.

        //Aynı işlem ayrımak istediğimiz diğer kod bölümleri için de geçerli. Aşağıda SideBar, Navbar ve javascript kod bölümü için
        //script partial fonksiyonları gösterilir. Bunlara da PartialView eklenmiştir. 
        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }
        public PartialViewResult SideBarPartial()
        {
            return PartialView();
        }
        public PartialViewResult NavBarPartial()
        {
            return PartialView();
        }

        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }


        /*
         SON OLARAK:

        View folder'da ön uç html kodlarımızın bulunduğu [@]Index.csthml kodlarını ayrıma işlemini tamamladık.
        Fakat sildiğimiz kısımlara bir referans, bir adres vermeliyiz ki kod o noktaya okumak için gelindiğinde verilen adrese gitsin ve
        o partial'dan okumaya devam etsin. Bunun için Index view içerisinde kodu ayırdığımız kısımlara, ilgili partial'lere göre,

        @Html.Partial("~/Views/AdminLayout/HeadPartial.cshtml")
        @Html.Partial("~/Views/AdminLayout/SideBarPartial.cshtml")
        @Html.Partial("~/Views/AdminLayout/NavBarPartial.cshtml")
        @Html.Partial("~/Views/AdminLayout/ScriptPartial.cshtml")

        kodlarını eklemeliyiz. 
         


        ###Solution exp.'daki Template folder'ı nedir, niye oluşturduk ? 

        İnternetten bulup indirdiğimiz Bootstrap projesinin sidebar-07 klasörünü bu folder'ı oluşturup içine yükledik. 
        İnternet sayfası bu dosya içerisinde her türlü koduyla mevcut. css,js, font, image vs. 
        Bunları kullanmak, gerekli yerlerde kodumuza dahil edeceğimiz kısımları bulup dahil etmek için bir dosya içerisine projeyi ekledik.
         
         */
    }
}