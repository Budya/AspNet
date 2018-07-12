using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Football.Models;
using System.Data.Entity;

namespace Football.Controllers
{
    public class HomeController : Controller
    {
        SoccerContext db = new SoccerContext();

        public ActionResult Index()
        {
            var players = db.Players.Include(p => p.Team);

            return View(players.ToList());
        }

       
    }
}