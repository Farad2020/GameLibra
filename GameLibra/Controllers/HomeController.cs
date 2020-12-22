using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace GameLibra.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
            //Test1234)
        }

        public async System.Threading.Tasks.Task<ActionResult> About()
        {
            ViewBag.Message = "Your application description page.";

            return View("~/Views/Home/About.cshtml");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Error404()
        {
            return View("~/Views/Shared/404.cshtml");
        }
    }
}