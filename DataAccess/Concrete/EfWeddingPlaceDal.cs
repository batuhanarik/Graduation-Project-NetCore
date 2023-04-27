using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfWeddingPlaceDal : EfEntityRepositoryBase<WeddingPlace, MarryUsContext>, IWeddingPlaceDal
    {
        public List<WeddingPlaceDetailDto> GetWeddingPlaceDetails()
        {
            using (var context = new MarryUsContext())
            {
                var result = from w in context.WeddingPlaces
                             join c in context.Categories 
                             on w.CategoryId equals c.CategoryId

                             join city in context.Cities
                             on w.PlateCode equals city.PlateCode
                             select new WeddingPlaceDetailDto
                             {
                                 WeddingPlaceId = w.WeddingPlaceId,
                                 CategoryName = c.CategoryName,
                                 PriceFirst = w.PriceFirst,
                                 PriceLast = w.PriceLast,
                                 WeddingPlaceName = w.PlaceName,
                                 Province=city.PlateName,
                                 WeddingPlaceImages = context.WeddingPlaceImages.Count(wpI => wpI.WeddingPlaceId == w.WeddingPlaceId) != 0
                                 ? context.WeddingPlaceImages.Where(wpI => wpI.WeddingPlaceId == w.WeddingPlaceId).ToList()
                                 : new List<WeddingPlaceImage> { new WeddingPlaceImage {
                                        WeddingPlaceId = w.WeddingPlaceId,
                                        ImagePath = "images/default.jpg"
                                    } }


                             };
                return result.ToList();
            }
        }
    }
}
