using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class WeddingPlace : IEntity
    {
        [Key]
        public int WeddingPlaceId { get; set; }
        public int PlateCode { get; set; } //Şehir kodu : örn : 22 - 39 - 34
        public int CategoryId { get; set; }
        public string PlaceName { get; set; } //Örn: Edirne Kır Bahçesi
        public string Description { get; set; } //Mekan Açıklaması
        public int CapacityFirst { get; set; } //Minimum Kapasitesi
        public int CapacityLast { get; set; } //Minimum Kapasitesi
        public double PriceFirstWeekday { get; set; }//Fiyat aralığı min.
        public double PriceLastWeekday { get; set; } //Fiyat aralığı max.
        public double PriceFirstWeekend { get; set; }//Fiyat aralığı min. haftasonu
        public double PriceLastWeekend { get; set; } //Fiyat aralığı max. haftasonu
        public double PriceAlcohol { get; set; } //Fiyat aralığı max. haftasonu
        public double PriceFood { get; set; } //Fiyat aralığı max. haftasonu
        public double PriceCocktail { get; set; } //Fiyat aralığı max. haftasonu
        public int DiscountRate { get; set; } //İndirim Oranı
        public int PlaceOwnerId { get; set; } //Mekan sahibi user id'si.
        public bool isReserved { get; set; } //Rezerve edildi mi?
        public bool isFoodIncluded { get; set; } //Yemekli mi?
        public bool isAlcoholIncluded { get; set; } //Alkollü mü?
        public bool isCocktailIncluded { get; set; } //Kokteylli mi?
        public bool HasAfterPartyArea { get; set; } //After parti alanı var mı?
        public bool HasMenuTasting { get; set; } //Menü tatma var mı?
        public bool HasSoundLightandStageService { get; set; } //Işık, ses ve sahne hizmeti var mı?
        public bool HasValetService { get; set; } //Vale servisi var mı?
        public bool HasHandicapEntrance { get; set; } //engelli girişi var mı?
        public bool HasPrepRoom { get; set; } //hazırlık odası var mı?
        public bool HasAnyMeasureAgainstAdverseWeatherConditions { get; set; } //olumsuz hava koşullarına karşı önlem var mı?
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string AuthorizedPersonName { get; set; }
        public bool PlaceStatus { get; set; } //Aktif mi pasif mi?
    }
}
