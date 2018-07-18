using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutorizFilterApp.Filters;

namespace AutorizFilterApp.Controllers
{
    public class HomeController : Controller
    {
        [MyAuthAttribute]
        public ActionResult Index()
        {
            return View();
        }

       // [HandleError(ExceptionType = typeof(System.IndexOutOfRangeException), View = "ExceptionFound")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
          //  int[] mas = new int[2];
            //mas[6] = 4;
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}