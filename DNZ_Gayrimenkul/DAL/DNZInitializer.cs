using DNZ_Gayrimenkul.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DNZ_Gayrimenkul.DAL
{
    public class DNZInitializer : DropCreateDatabaseIfModelChanges<DNZContext>
    {
        protected override void Seed(DNZContext context)
        {    

            var adTypes = new List<AdType>
            {
            new AdType{Name="Konut Satılık"},
            new AdType{Name="Konut Kiralık"},
            new AdType{Name="Konuk Günlük Kiralık"},
            new AdType{Name="İş Yeri Satılık"},
            new AdType{Name="İş Yeri Kiralık"},
            new AdType{Name="Arsa Satılık"},
            new AdType{Name="Arsa Kiralık"},
            new AdType{Name="Turistik İşletme Satılık"},
            new AdType{Name="Turistik İşletme Kiralık"},
            new AdType{Name="Devremülk Satılık"},
            new AdType{Name="Devremülk Kiralık"}
            };
                
            adTypes.ForEach(s => context.AdTypes.Add(s));
            context.SaveChanges();

            var buildingTypes = new List<BuildingType>
            {
            new BuildingType{Name="Apartman Dairesi"},
            new BuildingType{Name="Çiftlik Evi"},
            new BuildingType{Name="Dağı Evi"},
            new BuildingType{Name="Bina"},
            new BuildingType{Name="Kooperatif"},
            new BuildingType{Name="Köşk"},
            new BuildingType{Name="Köy Evi"},
            new BuildingType{Name="Loft Daire"},
            new BuildingType{Name="Müstakil Ev"},
            new BuildingType{Name="Residence"},
            new BuildingType{Name="Villa"},
            new BuildingType{Name="Yalı"},
            new BuildingType{Name="Yalı Dairesi"},
            new BuildingType{Name="Yazlık"}
            };

            
            buildingTypes.ForEach(s => context.BuildingTypes.Add(s));
            context.SaveChanges();

            var constructionTypes = new List<ConstructionType>
            {
            new ConstructionType{Name="Ahşap"},
            new ConstructionType{Name="Betonarme"},
            new ConstructionType{Name="Çelik"},
            new ConstructionType{Name="Kagir"},
            new ConstructionType{Name="Kütük"},
            new ConstructionType{Name="Prefabrik"},
            new ConstructionType{Name="Taş Bina"},
            new ConstructionType{Name="Yığma"}   
            };

            constructionTypes.ForEach(s => context.ConstructionTypes.Add(s));
            context.SaveChanges();

            var creditTypes = new List<CreditType>
            {
            new CreditType{Name="Bilinmiyor"},
            new CreditType{Name="Uygun"},
            new CreditType{Name="Uygun Değil"}         
            };

            creditTypes.ForEach(s => context.CreditTypes.Add(s));
            context.SaveChanges();

            var deedStatuses = new List<DeedStatus>
            {
            new DeedStatus{Name="Arsa"},
            new DeedStatus{Name="Kat İrtifakı"},
            new DeedStatus{Name="Kat Mülkiyeti"}
            };

            deedStatuses.ForEach(s => context.DeedStatuses.Add(s));
            context.SaveChanges();
        }
    }
}