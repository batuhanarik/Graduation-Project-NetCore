using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, MarryUsContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (MarryUsContext context = new())
            {
                var result = from rental in context.Rentals
                             join wp in context.WeddingPlaces on rental.WeddingPlaceId equals wp.WeddingPlaceId
                             join city in context.Cities on wp.PlateCode equals city.PlateCode
                             join user in context.Users on rental.CustomerId equals user.UserId
                             join category in context.Categories on rental.CategoryId equals category.CategoryId
                             select new RentalDetailDto
                             {
                                 Id = rental.Id,
                                 PlaceName = wp.PlaceName,
                                 CategoryName = category.CategoryName,
                                 PlateName= city.PlateName,
                                 CustomerName = user.Name + " " + user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
