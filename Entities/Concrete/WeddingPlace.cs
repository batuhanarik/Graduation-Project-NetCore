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
        public string PhoneNumber { get; set; }
        public string Description { get; set; } //Mekan Açıklaması
        public int Capacity { get; set; } //Kapasitesi
        public double PriceFirst{ get; set; }//Fiyat aralığı min.
        public double PriceLast{ get; set; } //Fiyat aralığı max.
        public int DiscountRate { get; set; } 
        public int PlaceOwnerId{ get; set; } //Mekan sahibi user id'si.
        public bool isReserved { get; set; } //Rezerve edildi mi?
        public bool isFoodIncluded { get; set; } //Yemekli mi?
        public bool isAlcoholIncluded { get; set; } //Alkollü mü?
        public bool PlaceStatus { get; set; } //Aktif mi pasif mi?
        //public WeddingPlaceImage WeddingPlaceImage { get; set; }
    }
}
