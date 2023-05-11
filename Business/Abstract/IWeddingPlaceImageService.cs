using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWeddingPlaceImageService
    {
        IDataResult<List<WeddingPlaceImage>> GetAll();
        IDataResult<WeddingPlaceImage> GetById(int id);
        IDataResult<List<WeddingPlaceImage>> GetImagesByWeddingPlaceId(int weddingPlaceId);

        IResult Add(WeddingPlaceImage wpImage, IFormFile file);
        IResult Delete(WeddingPlaceImage wpImage);
        IResult DeleteByWeddingPlaceId(int wpId);
        IResult Update(WeddingPlaceImage wpImage, IFormFile file);
        IResult AddMultiple(IFormFile[] files, WeddingPlaceImage weddingPlaceImage);
    }
}
