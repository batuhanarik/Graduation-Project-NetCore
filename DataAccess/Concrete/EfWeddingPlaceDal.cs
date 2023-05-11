using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfWeddingPlaceDal : EfEntityRepositoryBase<WeddingPlace, MarryUsContext>, IWeddingPlaceDal
    {
        public List<WeddingPlaceDetailDto> GetWeddingPlaceDetails(Expression<Func<WeddingPlaceDetailDto, bool>> filter = null)
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
                                 PriceFirstWeekday = w.PriceFirstWeekday,
                                 PriceLastWeekday = w.PriceLastWeekday,
                                 WeddingPlaceName = w.PlaceName,
                                 ProvinceName = city.PlateName,
                                 ProvinceId = city.PlateCode,
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

        public List<WeddingPlaceDetailDto> GetWeddingPlaceDetailsByCity(int id)
        {
            using (var context = new MarryUsContext())
            {
                var result = from w in context.WeddingPlaces
                             join c in context.Categories
                             on w.CategoryId equals c.CategoryId

                             join city in context.Cities
                             on w.PlateCode equals city.PlateCode
                             where w.PlateCode == id
                             select new WeddingPlaceDetailDto
                             {
                                 WeddingPlaceId = w.WeddingPlaceId,
                                 CategoryName = c.CategoryName,
                                 PriceFirstWeekday = w.PriceFirstWeekday,
                                 PriceLastWeekday = w.PriceLastWeekday,
                                 WeddingPlaceName = w.PlaceName,
                                 ProvinceName = city.PlateName,
                                 ProvinceId = city.PlateCode,
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

        public WeddingPlaceDetailDto GetWeddingPlaceDetail(int wpId)
        {
            using (MarryUsContext context = new())
            {
                var result = from wp in context.WeddingPlaces
                             where wp.WeddingPlaceId == wpId
                             join ctgry in context.Categories on wp.CategoryId equals ctgry.CategoryId
                             join city in context.Cities on wp.PlateCode equals city.PlateCode
                             select new WeddingPlaceDetailDto
                             {
                                 WeddingPlaceId = wp.WeddingPlaceId,
                                 WeddingPlaceName = wp.PlaceName,
                                 CategoryId = wp.CategoryId,
                                 CategoryName = ctgry.CategoryName,
                                 Description = wp.Description,
                                 PriceFirstWeekday = wp.PriceFirstWeekday,
                                 PriceLastWeekday = wp.PriceLastWeekday,
                                 DiscountRate = wp.DiscountRate,
                                 IsAlcoholIncluded = wp.isAlcoholIncluded,
                                 IsFoodIncluded = wp.isFoodIncluded,
                                 ProvinceId = wp.PlateCode,
                                 ProvinceName = city.PlateName,
                                 CapacityFirst = wp.CapacityFirst,
                                 CapacityLast = wp.CapacityLast,
                                 PriceFirstWeekend = wp.PriceFirstWeekend,
                                 PriceLastWeekend = wp.PriceLastWeekend,
                                 Address = wp.Address,
                                 HasAfterPartyArea = wp.HasAfterPartyArea,
                                 HasAnyMeasureAgainstAdverseWeatherConditions = wp.HasAnyMeasureAgainstAdverseWeatherConditions,
                                 HasHandicapEntrance = wp.HasHandicapEntrance,
                                 HasMenuTasting = wp.HasMenuTasting,
                                 HasPrepRoom = wp.HasPrepRoom,
                                 HasSoundLightandStageService = wp.HasSoundLightandStageService,
                                 HasValetService = wp.HasValetService,
                                 IsCocktailIncluded = wp.isCocktailIncluded,
                                 WeddingPlaceImages = context.WeddingPlaceImages.Where(wpi => wpi.WeddingPlaceId == wp.WeddingPlaceId).ToList()
                             };
                var wpDetail = result.FirstOrDefault();
                if (wpDetail.WeddingPlaceImages.Count == 0)
                    wpDetail.WeddingPlaceImages = new List<WeddingPlaceImage> { new WeddingPlaceImage {
                        WeddingPlaceId = wpDetail.WeddingPlaceId,
                        ImagePath = "images/default.jpg"
                    } };
                return wpDetail;
            }
        }
    }
}
