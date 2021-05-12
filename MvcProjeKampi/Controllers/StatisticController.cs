using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic

        Context _context = new Context();

        public ActionResult Index()
        {
            var totalCategory = _context.Categories.Count();
            ViewBag.totalCategory = totalCategory;
            ViewBag.totalCategoryQuery = "Toplam kategori sayısı";

            var totalSoftwareCategory = _context.Headings.Count(x=>x.Category.CategoryName=="Yazılım");
            ViewBag.totalSoftwareCategory = totalSoftwareCategory;
            ViewBag.totalSoftwareCategoryQuery = "Yazılım kategorisi başlık sayısı";

            var writerNameWithA = _context.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.writerNameWithA = writerNameWithA;
            ViewBag.writerNameWithAQuery = "'a' harfi olan yazar sayısı";

            var mostHeadings = _context.Headings.Max(x => x.Category.CategoryName);
            ViewBag.mostHeadings = mostHeadings;
            ViewBag.mostHeadingsQuery = "En fazla başlığa sahip kategori";

            var trueStatus = _context.Categories.Count(x => x.CategoryStatus == true);
            var falseStatus = _context.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.statusSub = trueStatus - falseStatus;
            ViewBag.statusSubQuery = "Durumu T/F olan kategoriler farkı";

            return View();
        }
    }
}