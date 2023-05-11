using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
namespace Business.Concrete
{
    public class WeddingPlaceManager : IWeddingPlaceService
    {
        IWeddingPlaceDal _weddingPlaceDal;
        IWeddingPlaceImageService _weddingPlaceImageService;
        ICategoryService _categoryService;

        public WeddingPlaceManager(IWeddingPlaceDal weddingPlaceDal, ICategoryService categoryService, IWeddingPlaceImageService weddingPlaceImageService)
        {
            _weddingPlaceDal = weddingPlaceDal;
            _categoryService = categoryService;
            _weddingPlaceImageService = weddingPlaceImageService;
        }

        //[CacheRemoveAspect("IWeddingPlaceService.Get")]
        //[SecuredOperation("add")]
        [ValidationAspect(typeof(WeddingPlaceValidator))]
        public IResult Add(WeddingPlace weddingPlace)
        {
            IResult result = BusinessRules.Run(CheckIfWeddingplaceCountOfCategoryCorrect(weddingPlace.CategoryId), CheckIfWeddingPlaceNameExist(weddingPlace.PlaceName), CheckIfCategoryLimitExceded());

            if (result != null)
            {
                return result;
            }
            _weddingPlaceDal.Add(weddingPlace);
            return new SuccessDataResult<int>(weddingPlace.WeddingPlaceId, Messages.WeddingPlaceAdded);
        }

        public IDataResult<List<WeddingPlace>> GetAll()
        {
            Thread.Sleep(3000);
            return new SuccessDataResult<List<WeddingPlace>>(_weddingPlaceDal.GetAll(), Messages.WeddingPlacesListed);
        }

        public IDataResult<List<WeddingPlace>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<WeddingPlace>>(_weddingPlaceDal.GetAll(w => w.CategoryId == id), Messages.GetAllWeddingPlacesByCategory);
        }
        public IDataResult<List<WeddingPlaceDetailDto>> GetWeddingPlaceDetailsByCity(int id)
        {
            return new SuccessDataResult<List<WeddingPlaceDetailDto>>(_weddingPlaceDal.GetWeddingPlaceDetailsByCity(id), Messages.WeddingPlacesListedByCity);
        }

        public IDataResult<List<WeddingPlace>> GetAllByPriceRange(int minPrice, int maxPrice)
        {
            return new SuccessDataResult<List<WeddingPlace>>(_weddingPlaceDal.GetAll(w => w.PriceFirstWeekday >= minPrice && w.PriceLastWeekday <= maxPrice));
        }

        public IDataResult<WeddingPlace> GetById(int id)
        {
            return new SuccessDataResult<WeddingPlace>(_weddingPlaceDal.Get(wP => wP.WeddingPlaceId == id));
        }

        public IDataResult<WeddingPlaceDetailDto> GetWeddingPlaceDetail(int wpId)
        {
            return new SuccessDataResult<WeddingPlaceDetailDto>(_weddingPlaceDal.GetWeddingPlaceDetail(wpId));
        }

        public IDataResult<List<WeddingPlaceDetailDto>> GetWeddingPlaceDetails()
        {
            return new SuccessDataResult<List<WeddingPlaceDetailDto>>(_weddingPlaceDal.GetWeddingPlaceDetails());
        }

        private IResult CheckIfWeddingplaceCountOfCategoryCorrect(int categoryId)
        {
            var result = _weddingPlaceDal.GetAll(w => w.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult("Bu kategoride en fazla 15 düğün yeri eklenebilir.");
            }
            return new SuccessResult();
        }
        private IResult CheckIfWeddingPlaceNameExist(string weddingPlaceName)
        {
            var result = _weddingPlaceDal.GetAll(w => w.PlaceName == weddingPlaceName).Any();
            if (result)
            {
                return new ErrorResult(Messages.WeddingPlaceNameAlreadyExists);
            }
            return new SuccessResult();
        }
        //Uydurma Kural
        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult("Kategori Limiti Aşıldı");
            }
            return new SuccessResult();
        }

        public IResult Delete(WeddingPlace weddingPlace)
        {
            _weddingPlaceImageService.DeleteByWeddingPlaceId(weddingPlace.WeddingPlaceId);
            _weddingPlaceDal.Delete(weddingPlace);
            return new SuccessResult(Messages.WeddingPlaceDeleted);
        }

        public IResult Update(WeddingPlace weddingPlace)
        {
            _weddingPlaceDal.Update(weddingPlace);
            return new SuccessResult(Messages.WeddingPlaceUpdate);
        }
    }
}
