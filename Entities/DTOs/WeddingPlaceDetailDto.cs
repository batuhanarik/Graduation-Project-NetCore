using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Entities.DTOs
{
    public class WeddingPlaceDetailDto : IDto
    {
        public int WeddingPlaceId { get; set; }
        public int CategoryId { get; set; }
        public int ProvinceId { get; set; }
        public string WeddingPlaceName { get; set; }
        public string ProvinceName { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Address
        { get; set; }
        public double PriceFirstWeekday { get; set; }
        public double PriceLastWeekday { get; set; }
        public double PriceFirstWeekend { get; set; }
        public double PriceLastWeekend { get; set; }
        public int DiscountRate { get; set; }
        public int CapacityFirst { get; set; }
        public int CapacityLast { get; set; }
        public bool IsAlcoholIncluded { get; set; }
        public bool IsFoodIncluded { get; set; }
        public bool IsCocktailIncluded { get; set; }
        public bool HasAfterPartyArea { get; set; } //After parti alanı var mı?
        public bool HasMenuTasting { get; set; } //Menü tatma var mı?
        public bool HasSoundLightandStageService { get; set; } //Işık, ses ve sahne hizmeti var mı?
        public bool HasValetService { get; set; } //Vale servisi var mı?
        public bool HasHandicapEntrance { get; set; }
        public bool HasPrepRoom { get; set; } //hazırlık odası var mı?
        public bool HasAnyMeasureAgainstAdverseWeatherConditions { get; set; } //olumsuz hava koşullarına karşı önlem var mı?
        public List<WeddingPlaceImage> WeddingPlaceImages { get; set; }
    }
}
