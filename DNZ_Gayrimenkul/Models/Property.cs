using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DNZ_Gayrimenkul.Models
{
  
    public class Property
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        
        public int AddressID { get; set; }
        public int AdTypeID { get; set; }
        public int BuildingTypeID { get; set; }
        public int ConstructionTypeID { get; set; }
        public int CreditTypeID { get; set; }
        public int DeedStatusID { get; set; }
        public int FloorID { get; set; }
        public int FuelTypeID { get; set; }
        public int HeatingTypeID { get; set; }
        public int PropertyStatusID { get; set; }
        public int PropertyTypeID { get; set; }
        public int UsageStatusID { get; set; }

        public string Title { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int RoomCount { get; set; }
        public int HallCount { get; set; }
        public int BathCount { get; set; }
        public double M2 { get; set; }
        public int Age { get; set; }
        public int BuildingFloors { get; set; }
        public bool TradeAvailable { get; set; }
        public bool StudentAvailable { get; set; }
        public bool LocatedInSite { get; set; }
        public bool North { get; set; }
        public bool South { get; set; }
        public bool East { get; set; }
        public bool West { get; set; }
        public bool IsFeatured { get; set; }
        public double RentRevenue { get; set; }
        public double MonthlyFee { get; set; }
      
        public virtual User User { get; set; }
        public virtual Address Address { get; set; }
        public virtual AdType AdType { get; set; }
        public virtual BuildingType BuildingType { get; set; }
        public virtual ConstructionType ConstructionType { get; set; }
        public virtual CreditType CreditType { get; set; }
        public virtual DeedStatus DeedStatus { get; set; }
        public virtual Floor Floor { get; set; }
        public virtual FuelType FuelType { get; set; }
        public virtual HeatingType HeatingType { get; set; }
        public virtual PropertyStatus PropertyStatus { get; set; }
        public virtual PropertyType PropertyType { get; set; }
        public virtual UsageStatus UsageStatus { get; set; }
        

        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Specification> Specifications { get; set; }
    }
}