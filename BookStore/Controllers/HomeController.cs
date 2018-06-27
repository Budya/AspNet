using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using BookStore.Util;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        // Создаем контекст данных
        BookContext db = new BookContext();
        public ActionResult Index()
        {
            // get all books from DB
            IEnumerable<Book> books = db.Books;

            //put all books in VievBag
            ViewBag.Books = books;

            // return View;
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;

            return View();
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;

            // Add data about purchase in db
            db.Purchases.Add(purchase);

            // save changes
            db.SaveChanges();

            return "Спасибо, " + purchase.Person + ", за покупку";
        }

        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2> Hello World !!!</h2>");
        }

        public ActionResult GetImage()
        {
            string path = "../Images/visualstudio.png";
            return new ImageResult(path);
        }

        public RedirectResult SomeMethod()
        {
            return Redirect("/Home/Index");
        }

        public ActionResult Partial()
        {
            ViewBag.Message = "This is partial view";
            return PartialView();
        }

    }
}