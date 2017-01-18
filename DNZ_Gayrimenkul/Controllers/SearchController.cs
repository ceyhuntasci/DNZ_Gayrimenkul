using DNZ_Gayrimenkul.DAL;
using DNZ_Gayrimenkul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DNZ_Gayrimenkul.Controllers
{
    public class SearchController : Controller
    {


        private DNZContext db = new DNZContext();

        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchRent(int salon, int oda, string minFiyat, string maxFiyat)
        {
            if( minFiyat == "" && maxFiyat == "")
            {
                return RedirectToAction("Index", "Home");
            }
            int min, max;
            if ((minFiyat == "" && maxFiyat != "") || (minFiyat != "" && maxFiyat == ""))
            {
                if( minFiyat == "")
                {
                     minFiyat= "0";
                } 
                if (maxFiyat == "")
                {
                    maxFiyat = "0";
                }
            }
            if (Int32.TryParse(minFiyat, out min) && Int32.TryParse(maxFiyat, out max))
            {
                List<Property> searchResult = db.Properties.Where(x => x.HallCount == salon && x.RoomCount == oda && x.Price <= min && x.Price >= max).ToList();

                return View("Index", searchResult);
            } else
            {
                return RedirectToAction("Index", "Home");
            }

           
        }
    }
}