using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class FilterOptions
    {
        public string? PlaceName { get; set; }
        public int? CategoryId { get; set; }
        public int? PlateCode { get; set; }
        public int? MinPriceWeekday { get; set; }
        public int? MaxPriceWeekday { get; set; }
        public int? MinPriceWeekend { get; set; }
        public int? MaxPriceWeekend { get; set; }
        public bool? IsAlcoholIncluded { get; set; }
        public bool? IsFoodIncluded { get; set; }
        public bool? IsCocktailIncluded { get; set; }
        public bool? HasValetService { get; set; }
        public bool? HasPrepRoom { get; set; }
        public bool? HasHandicapEntrance { get; set; }
        public bool? HasMenuTasting { get; set; }
        public bool? HasAnyMeasureAgainstAdverseWeatherConditions { get; set; }
    }
}
