
using DNZ_Gayrimenkul.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DNZ_Gayrimenkul.DAL
{
    public class DNZContext : DbContext
    {
        public DNZContext() : base("DNZContext")
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<AdType> AdTypes { get; set; }
        public DbSet<BuildingType> BuildingTypes { get; set; }
        public DbSet<ConstructionType> ConstructionTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<CreditType> CreditTypes { get; set; }
        public DbSet<DeedStatus> DeedStatuses { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<HeatingType> HeatingTypes { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyStatus> PropertyStatuses { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<UsageStatus> UsageStatuses { get; set; }
        public object User { get; internal set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}