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
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchRent(int? salon, int? oda, string minFiyat, string maxFiyat, string emlakTipi, string ilanTipi, string metrekare)
        {
            List<Property> searchResult = db.Properties.Where(x => x.Address.City == "İstanbul").ToList();


            if (salon != null)
            {
                searchResult = searchResult.Where(x => x.HallCount == salon).ToList();
            }
            if (oda != null)
            {
                searchResult = searchResult.Where(x => x.RoomCount == oda).ToList();
            }
            int min, max;

            if (minFiyat == "")
            {
                minFiyat = "0";
            }
            if (maxFiyat == "")
            {
                maxFiyat = "0";
            }

            if (minFiyat != "0")
            {
                if (Int32.TryParse(minFiyat, out min))
                {
                    searchResult = searchResult.Where(x => x.Price >= min).ToList();
                }
                else
                {

                }
            }
            if (maxFiyat != "0")
            {
                if (Int32.TryParse(maxFiyat, out max))
                {
                    searchResult = searchResult.Where(x => x.Price <= max).ToList();
                }
                else
                {

                }
            }
            if (emlakTipi != null)
            {
                searchResult = searchResult.Where(x => x.PropertyType.Name == emlakTipi).ToList();
            }
            if (ilanTipi != null)
            {
                searchResult = searchResult.Where(x => x.AdType.Name == emlakTipi).ToList();
            }
            int metre2;
            if(metrekare == "")
            {
                metrekare = "0";
            }
            if(metrekare != "0")
            {
                if (Int32.TryParse(metrekare, out metre2))
                {
                    searchResult = searchResult.Where(x => x.Price >= metre2).ToList();
                }
                else
                {

                }
            }

            return View("Index", searchResult);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchSale(int? salon, int? oda, string minFiyat, string maxFiyat)
        {
          
            List<Property> searchResult = db.Properties.Where(x => x.AdType.Name == "Konut Satılık").ToList();


            if (salon != null)
            {
                searchResult = searchResult.Where(x => x.HallCount == salon).ToList();
            }
            if (oda != null)
            {
                searchResult = searchResult.Where(x => x.RoomCount == oda).ToList();
            }
            int min, max;

            if (minFiyat == "")
            {
                minFiyat = "0";
            }
            if (maxFiyat == "")
            {
                maxFiyat = "0";
            }

            if ( minFiyat != "0")
            {
                if (Int32.TryParse(minFiyat, out min))
                {
                    searchResult = searchResult.Where(x => x.Price >= min).ToList();
                } else
                {

                }
            }
            if (maxFiyat != "0")
            {
                if (Int32.TryParse(maxFiyat, out max))
                {
                    searchResult = searchResult.Where(x => x.Price <= max).ToList();
                }
                else
                {

                }
            }

            return View("Index", searchResult);
        }
    }
}
