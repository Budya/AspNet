using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWorkApp.Models;

namespace UnitOfWorkApp.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork;

        public HomeController()
        {
            unitOfWork = new UnitOfWork();
        }
        public ActionResult Index()
        {
            var books = unitOfWork.Books.GetAll();
            return View(books);
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