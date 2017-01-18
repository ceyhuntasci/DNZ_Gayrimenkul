using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DNZ_Gayrimenkul.DAL;
using DNZ_Gayrimenkul.Models;
using DNZ_Gayrimenkul.ViewModels;

namespace DNZ_Gayrimenkul.Controllers
{
    public class HomeController : Controller
    {

        private DNZContext db = new DNZContext();

        public ActionResult Index()
        {      
            HomeViewModel hvm = new HomeViewModel();
            hvm.Properties = db.Properties.Include(p => p.Address).Include(p => p.AdType).Include(p => p.BuildingType).Include(p => p.ConstructionType).Include(p => p.CreditType).Include(p => p.DeedStatus).Include(p => p.Floor).Include(p => p.FuelType).Include(p => p.HeatingType).Include(p => p.PropertyStatus).Include(p => p.PropertyType).Include(p => p.UsageStatus).Include(p => p.User).ToList();
            hvm.Features = hvm.Properties.Where(p => p.IsFeatured == true).ToList();

            ViewBag.Home = "active";
            return View(hvm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            ViewBag.About = "active";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Contact = "active";
            return View();
        }
    }
}