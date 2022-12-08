using Core.Entities;
using System;

namespace Entities.DTOs
{
    public class WeddingPlaceDetailDto : IDto
    {
        public int WeddingPlaceId { get; set; }
        public string WeddingPlaceName { get; set; }
        public string CategoryName { get; set; }
        public double PriceFirst { get; set; }
        public double PriceLast { get; set; }
    }
}
