using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using BookStore.Util;

namespace BookStore.Controllers
{
    public class Home1Controller : Controller
    {
        // Создаем контекст данных
        BookContext db = new BookContext();

        public ActionResult Index()
        {

            SelectList books = new SelectList(db.Books, "Author", "Name");

            ViewBag.Books = books;

            // return View;
            return View();
        }
    }
}

//[HttpGet]
        //public ActionResult Buy(int id)
        //{
        //    ViewBag.BookId = id;

        //    return View();
        //}

        //[HttpPost]
        //public string Buy(Purchase purchase)
        //{
        //    purchase.Date = DateTime.Now;

        //    // Add data about purchase in db
        //    db.Purchases.Add(purchase);

        //    // save changes
        //    db.SaveChanges();

        //    return "Спасибо, " + purchase.Person + ", за покупку";
        //}