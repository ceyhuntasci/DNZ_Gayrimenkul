﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DNZ_Gayrimenkul.DAL;
using DNZ_Gayrimenkul.Models;
using System.IO;
using DNZ_Gayrimenkul.Areas.Admin.ViewModels;

namespace DNZ_Gayrimenkul.Areas.Admin.Controllers
{
    public class PropertiesController : Controller
    {
        private DNZContext db = new DNZContext();

        // GET: Admin/Properties
        public ActionResult Index()
        {
            var properties = db.Properties.Include(p => p.Address).Include(p => p.AdType).Include(p => p.BuildingType).Include(p => p.ConstructionType).Include(p => p.CreditType).Include(p => p.DeedStatus).Include(p => p.Floor).Include(p => p.FuelType).Include(p => p.HeatingType).Include(p => p.PropertyStatus).Include(p => p.PropertyType).Include(p => p.UsageStatus).Include(p => p.User);
            return View(properties.ToList());
        }

        // GET: Admin/Properties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // GET: Admin/Properties/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Addresses, "PropertyID", "Country");
            ViewBag.AdTypeID = new SelectList(db.AdTypes, "ID", "Name");
            ViewBag.BuildingTypeID = new SelectList(db.BuildingTypes, "ID", "Name");
            ViewBag.ConstructionTypeID = new SelectList(db.ConstructionTypes, "ID", "Name");
            ViewBag.CreditTypeID = new SelectList(db.CreditTypes, "ID", "Name");
            ViewBag.DeedStatusID = new SelectList(db.DeedStatuses, "ID", "Name");
            ViewBag.FloorID = new SelectList(db.Floors, "ID", "Name");
            ViewBag.FuelTypeID = new SelectList(db.FuelTypes, "ID", "Name");
            ViewBag.HeatingTypeID = new SelectList(db.HeatingTypes, "ID", "Name");
            ViewBag.PropertyStatusID = new SelectList(db.PropertyStatuses, "ID", "Name");
            ViewBag.PropertyTypeID = new SelectList(db.PropertyTypes, "ID", "Name");
            ViewBag.UsageStatusID = new SelectList(db.UsageStatuses, "ID", "Name");
            ViewBag.UserID = new SelectList(db.Users, "ID", "FullName");
            List<Specification> specs = db.Specifications.ToList();

            ViewBag.InnerSpecs = specs.Where(x => x.SpecType == "İç Özellikler").ToList();
            ViewBag.OuterSpecs = specs.Where(x => x.SpecType == "Dış Özellikler").ToList();
            ViewBag.LocationSpecs = specs.Where(x => x.SpecType == "Konum").ToList();
            return View();
        }

        // POST: Admin/Properties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,UserID,AdTypeID,BuildingTypeID,ConstructionTypeID,CreditTypeID,DeedStatusID,FloorID,FuelTypeID,HeatingTypeID,PropertyStatusID,PropertyTypeID,UsageStatusID,Title,Price,ImageUrl,Description,RoomCount,HallCount,BathCount,M2,Age,BuildingFloors,TradeAvailable,StudentAvailable,LocatedInSite,North,South,East,West,IsFeatured,RentRevenue,MonthlyFee")] Property property, string descr, string Country, string City, string District, string Street, List<bool> InnerSpecs, List<bool> OuterSpecs, List<bool> LocationSpecs)
        {
            if (ModelState.IsValid)
            {
               
                List<Specification> specs = db.Specifications.ToList();

                List<Specification> innerlist = specs.Where(x => x.SpecType == "İç Özellikler").ToList();
                List<Specification> outerlist = specs.Where(x => x.SpecType == "Dış Özellikler").ToList();
                List<Specification> locationlist = specs.Where(x => x.SpecType == "Konum").ToList();

                List<Specification> propertySpecList = new List<Specification>();

                for (int i=0; i < InnerSpecs.Count; i++)
                {
                    if (InnerSpecs[i])
                    {
                        Specification spec = innerlist[i];
                        propertySpecList.Add(spec);
                    }

                }
                for (int i = 0; i < OuterSpecs.Count; i++)
                {
                    if (OuterSpecs[i])
                    {
                        Specification spec = outerlist[i];
                        propertySpecList.Add(spec);
                    }

                }
                for (int i = 0; i < LocationSpecs.Count; i++)
                {
                    if (LocationSpecs[i])
                    {
                        Specification spec = locationlist[i];
                        propertySpecList.Add(spec);
                    }

                }
                property.Specifications = propertySpecList;
                db.Properties.Add(property);
                db.SaveChanges();

                Address propAddress = new Address();
                propAddress.Country = Country;
                propAddress.City = City;
                propAddress.District = District;
                propAddress.Street = Street;
                propAddress.PropertyID = property.ID;

                db.Addresses.Add(propAddress);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: Admin/Properties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Addresses, "PropertyID", "Country", property.ID);
            ViewBag.AdTypeID = new SelectList(db.AdTypes, "ID", "Name", property.AdTypeID);
            ViewBag.BuildingTypeID = new SelectList(db.BuildingTypes, "ID", "Name", property.BuildingTypeID);
            ViewBag.ConstructionTypeID = new SelectList(db.ConstructionTypes, "ID", "Name", property.ConstructionTypeID);
            ViewBag.CreditTypeID = new SelectList(db.CreditTypes, "ID", "Name", property.CreditTypeID);
            ViewBag.DeedStatusID = new SelectList(db.DeedStatuses, "ID", "Name", property.DeedStatusID);
            ViewBag.FloorID = new SelectList(db.Floors, "ID", "Name", property.FloorID);
            ViewBag.FuelTypeID = new SelectList(db.FuelTypes, "ID", "Name", property.FuelTypeID);
            ViewBag.HeatingTypeID = new SelectList(db.HeatingTypes, "ID", "Name", property.HeatingTypeID);
            ViewBag.PropertyStatusID = new SelectList(db.PropertyStatuses, "ID", "Name", property.PropertyStatusID);
            ViewBag.PropertyTypeID = new SelectList(db.PropertyTypes, "ID", "Name", property.PropertyTypeID);
            ViewBag.UsageStatusID = new SelectList(db.UsageStatuses, "ID", "Name", property.UsageStatusID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "FullName", property.UserID);

            List<Specification> specs = db.Specifications.ToList();

            foreach (var i in property.Specifications)
            {
                int index = specs.FindIndex(a => a.ID == i.ID);
                specs[index].Selected = "checked";
            }
          
            ViewBag.InnerSpecs = specs.Where(x => x.SpecType == "İç Özellikler").ToList();
            ViewBag.OuterSpecs = specs.Where(x => x.SpecType == "Dış Özellikler").ToList();
            ViewBag.LocationSpecs = specs.Where(x => x.SpecType == "Konum").ToList();

            return View(property);
        }

        // POST: Admin/Properties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,AdTypeID,BuildingTypeID,ConstructionTypeID,CreditTypeID,DeedStatusID,FloorID,FuelTypeID,HeatingTypeID,PropertyStatusID,PropertyTypeID,UsageStatusID,Title,Price,ImageUrl,Description,RoomCount,HallCount,BathCount,M2,Age,BuildingFloors,TradeAvailable,StudentAvailable,LocatedInSite,North,South,East,West,IsFeatured,RentRevenue,MonthlyFee")] Property property, string descr, string Country, string City, string District, string Street, List<bool> InnerSpecs, List<bool> OuterSpecs, List<bool> LocationSpecs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(property).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Addresses, "PropertyID", "Country", property.ID);
            ViewBag.AdTypeID = new SelectList(db.AdTypes, "ID", "Name", property.AdTypeID);
            ViewBag.BuildingTypeID = new SelectList(db.BuildingTypes, "ID", "Name", property.BuildingTypeID);
            ViewBag.ConstructionTypeID = new SelectList(db.ConstructionTypes, "ID", "Name", property.ConstructionTypeID);
            ViewBag.CreditTypeID = new SelectList(db.CreditTypes, "ID", "Name", property.CreditTypeID);
            ViewBag.DeedStatusID = new SelectList(db.DeedStatuses, "ID", "Name", property.DeedStatusID);
            ViewBag.FloorID = new SelectList(db.Floors, "ID", "Name", property.FloorID);
            ViewBag.FuelTypeID = new SelectList(db.FuelTypes, "ID", "Name", property.FuelTypeID);
            ViewBag.HeatingTypeID = new SelectList(db.HeatingTypes, "ID", "Name", property.HeatingTypeID);
            ViewBag.PropertyStatusID = new SelectList(db.PropertyStatuses, "ID", "Name", property.PropertyStatusID);
            ViewBag.PropertyTypeID = new SelectList(db.PropertyTypes, "ID", "Name", property.PropertyTypeID);
            ViewBag.UsageStatusID = new SelectList(db.UsageStatuses, "ID", "Name", property.UsageStatusID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "FullName", property.UserID);
            return View(property);
        }

        // GET: Admin/Properties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // POST: Admin/Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Property property = db.Properties.Find(id);

            Address address = property.Address;
            db.Addresses.Remove(address);
            
            if (property.Specifications.ToList().FirstOrDefault() != null)
            {
                foreach (var i in property.Specifications.ToList())
                {
                    i.Properties.Remove(property);
                    if (i.Properties.FirstOrDefault() == null)
                    {
                        db.Specifications.Remove(i);
                    }
                }
            }


            db.Properties.Remove(property);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
       

     
        public JsonResult UploadGallery()
        {
            try
            {
                HttpPostedFileBase file = Request.Files[0];
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                fileName += DateTime.Now.Day;
                fileName += DateTime.Now.Month;
                fileName += DateTime.Now.Year;
                fileName += DateTime.Now.Hour;
                fileName += DateTime.Now.Minute;
                fileName += DateTime.Now.Second;
                fileName += Path.GetExtension(file.FileName);

                var path = Path.Combine(Server.MapPath("~/Images/Uploads/"), fileName);

                //if (System.IO.File.Exists(path))
                //{
                //    fileName = Path.GetFileNameWithoutExtension(file.FileName) + "-x10" + Path.GetExtension(file.FileName);
                //    path = Path.Combine(Server.MapPath("~/Images/Temp/"), fileName);
                //}
                Directory.CreateDirectory(Server.MapPath("~/Images/Uploads/"));

                file.SaveAs(path);

                return Json(path + " yüklendi");
            }
            catch
            {
                return Json("Bir hata oluştu. Lütfen tekrar deneyin");
            }
        }

        public JsonResult UploadImage()
        {
            try
            {
                HttpPostedFileBase file = Request.Files[0];
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                fileName += DateTime.Now.Day;
                fileName += DateTime.Now.Month;
                fileName += DateTime.Now.Year;
                fileName += DateTime.Now.Hour;
                fileName += DateTime.Now.Minute;
                fileName += DateTime.Now.Second;
                fileName += Path.GetExtension(file.FileName);

                var path = Path.Combine(Server.MapPath("~/Images/Uploads/"), fileName);

                //if (System.IO.File.Exists(path))
                //{
                //    fileName = Path.GetFileNameWithoutExtension(file.FileName) + "-x10" + Path.GetExtension(file.FileName);
                //    path = Path.Combine(Server.MapPath("~/Images/Temp/"), fileName);
                //}
                Directory.CreateDirectory(Server.MapPath("~/Images/Uploads/"));

                file.SaveAs(path);

                return Json(path);
            }
            catch
            {
                return Json("Bir hata oluştu. Lütfen tekrar deneyin");
            }
          
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
