using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DependenciesApp.Models;
using Ninject;

namespace DependenciesApp.Controllers
{
    public class HomeController : Controller
    {
        IRepository repo;

        public HomeController(IRepository r)
        {
            repo = r;
            //IKernel ninjectKernel = new StandardKernel();
            //ninjectKernel.Bind<IRepository>().To<BookRepository>();
            //repo = ninjectKernel.Get<IRepository>();
        }

        public ActionResult Index()
        {
            return View(repo.List());
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