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
    public class PropertiesController : Controller
    {
        private DNZContext db = new DNZContext();

        // GET: Properties
        public ActionResult Index()
        {
            var properties = db.Properties.Include(p => p.Address).Include(p => p.AdType).Include(p => p.BuildingType).Include(p => p.ConstructionType).Include(p => p.CreditType).Include(p => p.DeedStatus).Include(p => p.Floor).Include(p => p.FuelType).Include(p => p.HeatingType).Include(p => p.PropertyStatus).Include(p => p.PropertyType).Include(p => p.UsageStatus).Include(p => p.User);
            return View(properties.ToList());
        }

        // GET: Properties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyViewModel pvm = new PropertyViewModel();

            Property property = db.Properties.Find(id);
            pvm.Property = property;
            pvm.innerSpecs = property.Specifications.Where(p => p.SpecType == "İç Özellikler").ToList();
            pvm.outerSpecs = property.Specifications.Where(p => p.SpecType == "Dış Özellikler").ToList();
            pvm.locationSpecs = property.Specifications.Where(p => p.SpecType == "Konum").ToList();
            if (property == null)
            {
                return HttpNotFound();
            }

            ViewBag.Property = "active";
            return View(pvm);
        }
     
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
