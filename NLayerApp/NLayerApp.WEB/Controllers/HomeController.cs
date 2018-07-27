using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using NLayerApp.BLL.DTO;
using NLayerApp.BLL.Interfaces;
using NLayerApp.WEB.Models;

namespace NLayerApp.WEB.Controllers
{
    public class HomeController : Controller
    {
        private IOrderService orderService;

        public HomeController(IOrderService serv)
        {
            orderService = serv;
        }
        public ActionResult Index()
        {
            Mapper.CreateMap<PhoneDTO, PhoneViewModel>();
            var phones = Mapper.Map<IEnumerable<PhoneDTO>,
                List<PhoneViewModel>>(orderService.GetPhones());
            return View(phones);
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