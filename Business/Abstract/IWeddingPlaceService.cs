using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IWeddingPlaceService
    {
        IDataResult<List<WeddingPlace>> GetAll();
        IDataResult<List<WeddingPlace>> GetAllByCategoryId(int id);
        IDataResult<List<WeddingPlace>> GetAllByPriceRange(int minPrice, int maxPrice);
        IDataResult<List<WeddingPlaceDetailDto>> GetWeddingPlaceDetails();
        IDataResult<WeddingPlace> GetById(int id);

        IResult Add(WeddingPlace weddingPlace);
    }
}
