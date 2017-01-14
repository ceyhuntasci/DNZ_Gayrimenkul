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

            var floors = new List<Floor>
            {
            new Floor{Name="1"},
            new Floor{Name="2"},
            new Floor{Name="3"},
            new Floor{Name="4"},
            new Floor{Name="5"},
            new Floor{Name="6"},
            new Floor{Name="7"},
            new Floor{Name="8"},
            new Floor{Name="9"},
            new Floor{Name="10"},
            new Floor{Name="11"},
            new Floor{Name="12"},
            new Floor{Name="13"},
            new Floor{Name="14"},
            new Floor{Name="15"},
            new Floor{Name="16"},
            new Floor{Name="17"},
            new Floor{Name="18"},
            new Floor{Name="19"},
            new Floor{Name="20"},
            new Floor{Name="21 ve üzeri"},
            new Floor{Name="En Üst Kat"},
            new Floor{Name="Zemin"},
            new Floor{Name="Bahçe Katı"},
            new Floor{Name="Giriş Katı"},
            new Floor{Name="Yüksek Giriş"},
            new Floor{Name="Villa Katı"},
            new Floor{Name="Asma Kat"},
            new Floor{Name="Çatı Katı"},
            new Floor{Name="Teras Katı"},
            new Floor{Name="Bodrum ve Zemin"},
            new Floor{Name="Bodrum"},
            new Floor{Name="Yarı Bodrum"},
            new Floor{Name="Kot 1"},
            new Floor{Name="Kot 2"},
            new Floor{Name="Kot 3"}
            };

            floors.ForEach(s => context.Floors.Add(s));
            context.SaveChanges();

            var fuelTypes = new List<FuelType>
            {
            new FuelType{Name="Doğalgaz"},
            new FuelType{Name="Kömür-Odun"},
            new FuelType{Name="Akaryakıt"},
            new FuelType{Name="Elektrik"}
            };

            fuelTypes.ForEach(s => context.FuelTypes.Add(s));
            context.SaveChanges();

            var heatingTypes = new List<HeatingType>
            {
            new HeatingType{Name="Güneş Enerjisi"},
            new HeatingType{Name="Kat Kaloriferi"},
            new HeatingType{Name="Klima"},
            new HeatingType{Name="Kombi"},
            new HeatingType{Name="Merkezi"},
            new HeatingType{Name="Merkezi (Pay Ölçer)"},
            new HeatingType{Name="Soba"},
            new HeatingType{Name="Jeotermal Isıtma"},
            new HeatingType{Name="Yok"},
            new HeatingType{Name="Belirtilmemiş"}
            };

            heatingTypes.ForEach(s => context.HeatingTypes.Add(s));
            context.SaveChanges();

            var propertyStatuses = new List<PropertyStatus>
            {
            new PropertyStatus{Name="Sıfır"},
            new PropertyStatus{Name="İkinci El"},
            new PropertyStatus{Name="Yapım Aşamasında"}
            };

            propertyStatuses.ForEach(s => context.PropertyStatuses.Add(s));
            context.SaveChanges();

            var propertyTypes = new List<PropertyType>
            {
            new PropertyType{Name="Bahçe Dubleksi"},
            new PropertyType{Name="Bahçe Katı"},
            new PropertyType{Name="Çatı Dubleksi"},
            new PropertyType{Name="Daire"},
            new PropertyType{Name="Dubleks"},
            new PropertyType{Name="İkiz Ev"},
            new PropertyType{Name="Müstakil Ev"},
            new PropertyType{Name="Tripleks"},
            new PropertyType{Name="Fourlex"}
            };

            propertyTypes.ForEach(s => context.PropertyTypes.Add(s));
            context.SaveChanges();

            var usageStatuses = new List<UsageStatus>
            {
            new UsageStatus{Name="Boş"},
            new UsageStatus{Name="Kiracı Oturuyor"},
            new UsageStatus{Name="Ev Sahibi Oturuyor"},
            new UsageStatus{Name="Belirtilmemiş"}
            };

            usageStatuses.ForEach(s => context.UsageStatuses.Add(s));
            context.SaveChanges();

            var specifications = new List<Specification>
            {
            new Specification{Name="ADSL", SpecType="İç Özellikler"},
            new Specification{Name="Çamaşır Odası", SpecType="İç Özellikler"},
            new Specification{Name="Görüntülü Diafon", SpecType="İç Özellikler"},
            new Specification{Name="Kapalı Balkon", SpecType="İç Özellikler"},
            new Specification{Name="Mutfak Doğalgazı", SpecType="İç Özellikler"},
            new Specification{Name="Saten Boya", SpecType="İç Özellikler"},
            new Specification{Name="Yerden Isıtma", SpecType="İç Özellikler"},
            new Specification{Name="Ahşap Doğrama", SpecType="İç Özellikler"},
            new Specification{Name="Çelik Kapı", SpecType="İç Özellikler"},
            new Specification{Name="Halı Kaplama", SpecType="İç Özellikler"},
            new Specification{Name="Kartonpiyer", SpecType="İç Özellikler"},
            new Specification{Name="Panel Kapı", SpecType="İç Özellikler"},
            new Specification{Name="Sauna", SpecType="İç Özellikler"},
            new Specification{Name="Alarm", SpecType="İç Özellikler"},
            new Specification{Name="Duşakabin", SpecType="İç Özellikler"},
            new Specification{Name="Hazır Mutfak", SpecType="İç Özellikler"},
            new Specification{Name="Klima", SpecType="İç Özellikler"},
            new Specification{Name="Panjur", SpecType="İç Özellikler"},
            new Specification{Name="Seramik Zemin", SpecType="İç Özellikler"},
            new Specification{Name="Ankastre Mutfak", SpecType="İç Özellikler"},
            new Specification{Name="Duvar Kağıdı", SpecType="İç Özellikler"},
            new Specification{Name="Hilton Banyo", SpecType="İç Özellikler"},
            new Specification{Name="Laminant Mutfak", SpecType="İç Özellikler"},
            new Specification{Name="Parke", SpecType="İç Özellikler"},
            new Specification{Name="Spot Işık", SpecType="İç Özellikler"},
            new Specification{Name="Balkon", SpecType="İç Özellikler"},
            new Specification{Name="Ebeveyn Banyolu", SpecType="İç Özellikler"},
            new Specification{Name="Isıcam", SpecType="İç Özellikler"},
            new Specification{Name="Marley", SpecType="İç Özellikler"},
            new Specification{Name="Parke - Laminant", SpecType="İç Özellikler"},
            new Specification{Name="Şömine", SpecType="İç Özellikler"},
            new Specification{Name="Barbekü", SpecType="İç Özellikler"},
            new Specification{Name="Giyinme Odası", SpecType="İç Özellikler"},
            new Specification{Name="Jakuzi", SpecType="İç Özellikler"},
            new Specification{Name="Mermer Zemin", SpecType="İç Özellikler"},
            new Specification{Name="Parke - Lamine", SpecType="İç Özellikler"},
            new Specification{Name="Teras", SpecType="İç Özellikler"},
            new Specification{Name="Beyaz Eşyalı", SpecType="İç Özellikler"},
            new Specification{Name="Gömme Dolap", SpecType="İç Özellikler"},
            new Specification{Name="Kablo TV-Uydu", SpecType="İç Özellikler"},
            new Specification{Name="Mobilyalı", SpecType="İç Özellikler"},
            new Specification{Name="Saten Alçı", SpecType="İç Özellikler"},
            new Specification{Name="Vestiyer", SpecType="İç Özellikler"},

            new Specification{Name="Ahşap Doğrama", SpecType="Dış Özellikler"},
            new Specification{Name="Isı Yalıtım", SpecType="Dış Özellikler"},
            new Specification{Name="Siding", SpecType="Dış Özellikler"},
            new Specification{Name="Asansör", SpecType="Dış Özellikler"},
            new Specification{Name="Jeneratör", SpecType="Dış Özellikler"},
            new Specification{Name="Site içerisinde", SpecType="Dış Özellikler"},
            new Specification{Name="Bahçeli", SpecType="Dış Özellikler"},
            new Specification{Name="Kapıcı", SpecType="Dış Özellikler"},
            new Specification{Name="Su deposu", SpecType="Dış Özellikler"},
            new Specification{Name="Cam Mozaik Kaplama", SpecType="Dış Özellikler"},
            new Specification{Name="Otopark - Açık", SpecType="Dış Özellikler"},
            new Specification{Name="Tenis Kortu", SpecType="Dış Özellikler"},
            new Specification{Name="Fitness", SpecType="Dış Özellikler"},
            new Specification{Name="Otopark - Kapalı", SpecType="Dış Özellikler"},
            new Specification{Name="Yangın Merdiveni", SpecType="Dış Özellikler"},
            new Specification{Name="Güvenlik", SpecType="Dış Özellikler"},
            new Specification{Name="Oyun Parkı", SpecType="Dış Özellikler"},
            new Specification{Name="Yüzme Havuzu", SpecType="Dış Özellikler"},
            new Specification{Name="Hidrofor", SpecType="Dış Özellikler"},
            new Specification{Name="PVC Doğrama", SpecType="Dış Özellikler"},

            new Specification{Name="Arka cephe", SpecType="Konum"},
            new Specification{Name="Manzara - Boğaz", SpecType="Konum"},
            new Specification{Name="Metroya Yakın", SpecType="Konum"},
            new Specification{Name="Caddeye Yakın", SpecType="Konum"},
            new Specification{Name="Manzara - Deniz", SpecType="Konum"},
            new Specification{Name="Otobana Yakın", SpecType="Konum"},
            new Specification{Name="Deniz Ulaşımına Yakın", SpecType="Konum"},
            new Specification{Name="Manzara Doğa", SpecType="Konum"},
            new Specification{Name="Ön cephe", SpecType="Konum"},
            new Specification{Name="Denize sıfır", SpecType="Konum"},
            new Specification{Name="MAnzara - Göl", SpecType="Konum"},
            new Specification{Name="Toplu Ulaşıma Yakın", SpecType="Konum"},
            new Specification{Name="Denize Yakın", SpecType="Konum"},
            new Specification{Name="Manzara - Şehir", SpecType="Konum"},
            new Specification{Name="Havaalanına Yakın", SpecType="Konum"},
            new Specification{Name="Merkezde", SpecType="Konum"},
            new Specification{Name="Manzara", SpecType="Konum"},
            new Specification{Name="Metrobüse Yakın", SpecType="Konum"},
            };

            specifications.ForEach(s => context.Specifications.Add(s));
            context.SaveChanges();



        }
    }
}