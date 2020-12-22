using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameLibra.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View("~/Views/Shared/404.cshtml");
        }
        public ActionResult Error404()
        {
            return View("~/Views/Shared/404.cshtml");
        }

        public ActionResult PageNotFound()
        {
            return View("~/Views/Shared/404.cshtml");
        }
    }
}