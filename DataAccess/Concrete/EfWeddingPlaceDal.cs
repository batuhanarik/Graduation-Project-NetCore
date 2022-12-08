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
                             select new WeddingPlaceDetailDto 
                             { 
                                 WeddingPlaceId=w.WeddingPlaceId,CategoryName=c.CategoryName,
                                 PriceFirst=w.PriceFirst,PriceLast=w.PriceLast,WeddingPlaceName=w.PlaceName,
                             };
                return result.ToList();
            }
        }
    }
}
