using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Entities.DTOs
{
    public class WeddingPlaceDetailDto : IDto
    {
        public int WeddingPlaceId { get; set; }
        public string WeddingPlaceName { get; set; }
        public string Province { get; set; }
        public string CategoryName { get; set; }
        public double PriceFirst { get; set; }
        public double PriceLast { get; set; }
        public List<WeddingPlaceImage> WeddingPlaceImages { get; set; }
    }
}
