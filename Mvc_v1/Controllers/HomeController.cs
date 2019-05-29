using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_v1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Careers()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Careers(HttpPostedFileBase file)
        {
            string filename = Path.GetFileName(file.FileName);
            string filepath = Path.Combine(Server.MapPath("~/File_Upload"), filename);

            return View();
        }
    }
}