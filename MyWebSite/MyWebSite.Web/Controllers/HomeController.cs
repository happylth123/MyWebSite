using MyWebSite.Share.Encrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebSite.Web.Controllers
{
    public class HomeController : Controller
    {
        MD5Encrypt encrypt = new MD5Encrypt();

        public ActionResult Index()
        {
            string testStr = "minjie@kooboo.com";
            string test1 = encrypt.MD5Encrypt16(testStr);
            var test2 = encrypt.MD5Encrypt32(testStr).ToLower();
            var test3 = encrypt.MD5Encrypt64(testStr);
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
    }
}