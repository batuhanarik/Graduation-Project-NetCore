using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IWeddingPlaceService
    {
        IDataResult<List<WeddingPlace>> GetAll();
        IDataResult<WeddingPlace> GetById(int id);
        IDataResult<List<WeddingPlace>> GetAllByCategoryId(int id);
        IDataResult<List<WeddingPlace>> GetAllByPriceRange(int minPrice, int maxPrice);
        IDataResult<List<WeddingPlaceDetailDto>> GetWeddingPlaceDetails();
        IDataResult<List<WeddingPlaceDetailDto>> GetWeddingPlaceDetailsByCity(int id);
        IDataResult<WeddingPlaceDetailDto> GetWeddingPlaceDetail(int wpId);
        IResult Add(WeddingPlace weddingPlace);
        IResult Update(WeddingPlace weddingPlace);
        IResult Delete(WeddingPlace weddingPlace);
    }
}
