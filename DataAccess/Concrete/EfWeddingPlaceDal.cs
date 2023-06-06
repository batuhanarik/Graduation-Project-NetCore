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
            //System.Threading.Thread.Sleep(300000);
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
                                 WeddingPlaceName = w.PlaceName,
                                 PriceWeekday = w.PriceWeekday,
                                 PriceWeekend = w.PriceWeekend,
                                 ProvinceName = city.PlateName,
                                 PlateCode = city.PlateCode,
                                 PriceFood = w.PriceFood,
                                 PriceCocktail = w.PriceCocktail,
                                 PriceAlcohol = w.PriceAlcohol,
                                 IsCocktailIncluded = w.IsCocktailIncluded,
                                 IsAlcoholIncluded = w.IsAlcoholIncluded,
                                 Address = w.Address,
                                 AuthorizedPersonName = w.AuthorizedPersonName,
                                 CapacityFirst = w.CapacityFirst,
                                 CapacityLast = w.CapacityLast,
                                 CategoryId = w.CategoryId,
                                 Description = w.Description,
                                 DiscountRate = w.DiscountRate,
                                 HasAfterPartyArea = w.HasAfterPartyArea,
                                 HasAnyMeasureAgainstAdverseWeatherConditions = w.HasAnyMeasureAgainstAdverseWeatherConditions,
                                 HasHandicapEntrance = w.HasHandicapEntrance,
                                 HasMenuTasting = w.HasMenuTasting,
                                 HasPrepRoom = w.HasPrepRoom,
                                 HasSoundLightandStageService = w.HasSoundLightandStageService,
                                 HasValetService = w.HasValetService,
                                 IsFoodIncluded = w.IsFoodIncluded,
                                 PhoneNumber = w.PhoneNumber,
                                 WeddingPlaceImages = context.WeddingPlaceImages.Count(wpI => wpI.WeddingPlaceId == w.WeddingPlaceId) != 0
                                 ? context.WeddingPlaceImages.Where(wpI => wpI.WeddingPlaceId == w.WeddingPlaceId).ToList()
                                 : new List<WeddingPlaceImage> { new WeddingPlaceImage {
                                        WeddingPlaceId = w.WeddingPlaceId,
                                        ImagePath = "images/default.jpg"
                                    } }


                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
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
                                 PriceWeekday = w.PriceWeekday,
                                 PriceWeekend = w.PriceWeekend,
                                 WeddingPlaceName = w.PlaceName,
                                 ProvinceName = city.PlateName,
                                 PlateCode = city.PlateCode,
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
                                 DiscountRate = wp.DiscountRate,
                                 IsAlcoholIncluded = wp.IsAlcoholIncluded,
                                 IsFoodIncluded = wp.IsFoodIncluded,
                                 PlateCode= wp.PlateCode,
                                 ProvinceName = city.PlateName,
                                 CapacityFirst = wp.CapacityFirst,
                                 CapacityLast = wp.CapacityLast,
                                 PriceWeekday = wp.PriceWeekday,
                                 PriceWeekend = wp.PriceWeekend,
                                 Address = wp.Address,
                                 HasAfterPartyArea = wp.HasAfterPartyArea,
                                 HasAnyMeasureAgainstAdverseWeatherConditions = wp.HasAnyMeasureAgainstAdverseWeatherConditions,
                                 HasHandicapEntrance = wp.HasHandicapEntrance,
                                 HasMenuTasting = wp.HasMenuTasting,
                                 HasPrepRoom = wp.HasPrepRoom,
                                 HasSoundLightandStageService = wp.HasSoundLightandStageService,
                                 HasValetService = wp.HasValetService,
                                 IsCocktailIncluded = wp.IsCocktailIncluded,
                                 AuthorizedPersonName = wp.AuthorizedPersonName,
                                 PhoneNumber= wp.PhoneNumber,
                                 PriceAlcohol = wp.PriceAlcohol,
                                 PriceCocktail = wp.PriceCocktail,
                                 PriceFood = wp.PriceFood,
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

        public WeddingPlaceStatsDto GetWeddingPlaceStats(int wpId)
        {
            using MarryUsContext context = new MarryUsContext();
            int totalIncome = 0;
            var result = from ren in context.Rentals
                         where ren.WeddingPlaceId == wpId
                         select ren;
            foreach (var ren in result)
            {
                totalIncome += ren.TotalPrice;
            }
            return new WeddingPlaceStatsDto
            {
                Id = wpId,
                TotalIncome = totalIncome,
                TotalRentals = result.Count()
            };

        }
    }
}
