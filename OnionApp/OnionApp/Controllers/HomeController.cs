using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnionApp.Domain.Core;
using OnionApp.Domain.Interfaces;
using OnionApp.Services.Interfaces;

namespace OnionApp.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository repo;
        private IOrder order;

        public HomeController(IBookRepository r, IOrder o)
        {
            repo = r;
            order = o;
        }

        public ActionResult Index()
        {
            var books = repo.GetBookList();
            return View();
        }

        public ActionResult Buy(int id)
        {
            Book book = repo.GetBook(id);
            order.MakeOrder(book);
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            repo.Dispose();
            base.Dispose(disposing);
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