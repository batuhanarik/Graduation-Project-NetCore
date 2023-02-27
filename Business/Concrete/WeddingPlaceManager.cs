﻿using Business.Abstract;
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

namespace Business.Concrete
{
    public class WeddingPlaceManager : IWeddingPlaceService
    {
        IWeddingPlaceDal _weddingPlaceDal;
        ICategoryService _categoryService;

        public WeddingPlaceManager(IWeddingPlaceDal weddingPlaceDal, ICategoryService categoryService)
        {
            _weddingPlaceDal = weddingPlaceDal;
            _categoryService = categoryService;
        }

        [SecuredOperation("weddingplace.add,admin")]
        [ValidationAspect(typeof(WeddingPlaceValidator))]
        public IResult Add(WeddingPlace weddingPlace)
        {
            IResult result =BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(weddingPlace.CategoryId), CheckIfWeddingPlaceNameExist(weddingPlace.PlaceName), CheckIfCategoryLimitExceded());

            if (result!=null)
            {
                return result;
            }
            _weddingPlaceDal.Add(weddingPlace);
                return new SuccessResult(Messages.WeddingPlaceDeleted);
        }

        public IDataResult<List<WeddingPlace>> GetAll()
        {
            return new SuccessDataResult<List<WeddingPlace>>(_weddingPlaceDal.GetAll(), Messages.WeddingPlacesListed);
        }

        public IDataResult<List<WeddingPlace>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<WeddingPlace>>(_weddingPlaceDal.GetAll(w => w.CategoryId == id), Messages.GetAllWeddingPlacesByCategory);
        }

        public IDataResult<List<WeddingPlace>> GetAllByPriceRange(int minPrice, int maxPrice)
        {
            return new SuccessDataResult<List<WeddingPlace>>(_weddingPlaceDal.GetAll(w => w.PriceFirst >= minPrice && w.PriceLast <= maxPrice));
        }

        public IDataResult<WeddingPlace> GetById(int id)
        {
            return new SuccessDataResult<WeddingPlace>(_weddingPlaceDal.Get(wP => wP.WeddingPlaceId == id));
        }

        public IDataResult<List<WeddingPlaceDetailDto>> GetWeddingPlaceDetails()
        {
            return new SuccessDataResult<List<WeddingPlaceDetailDto>>(_weddingPlaceDal.GetWeddingPlaceDetails());
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
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
            if (result.Data.Count>15)
            {
                return new ErrorResult("Kategori Limiti Aşıldı");
            }
            return new SuccessResult();
        }

        public IResult Delete(WeddingPlace weddingPlace)
        {
            _weddingPlaceDal.Delete(weddingPlace);
            return new SuccessResult(Messages.WeddingPlaceDeleted);
        }
    }
}
