using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IWeddingPlaceDal : IEntityRepository<WeddingPlace>
    {
        List<WeddingPlaceDetailDto> GetWeddingPlaceDetails(Expression<Func<WeddingPlaceDetailDto, bool>> filter = null);
        List<WeddingPlaceDetailDto> GetWeddingPlaceDetailsByCity(int id);
        public WeddingPlaceDetailDto GetWeddingPlaceDetail(int wpId);

    }
}
