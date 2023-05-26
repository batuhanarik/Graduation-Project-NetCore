using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class WeddingPlaceImageManager : IWeddingPlaceImageService
    {
        IWeddingPlaceImageDal _weddingPlaceImageDal;
        public WeddingPlaceImageManager(IWeddingPlaceImageDal weddingPlaceImageDal)
        {
            _weddingPlaceImageDal = weddingPlaceImageDal;
        }
        [ValidationAspect(typeof(WeddingPlaceImageValidator))]
        public IResult Add(WeddingPlaceImage wpImage, IFormFile file)
        {
            var result = BusinessRules.Run(CheckIfImageLimitExceeded(wpImage.WeddingPlaceId));
            if (result != null)
            {
                return result;
            }
            string imageName = string.Format(@"{0}.jpg", Guid.NewGuid());
            wpImage.ImagePath = Paths.WpImagePath + imageName;
            wpImage.Date = DateTime.Now;
            FileHelper.Write(file, Paths.WpImagePath);
            _weddingPlaceImageDal.Add(wpImage);
            return new SuccessResult(Messages.WeddingPlaceImageAdded);
        }

        //[SecuredOperation("admin")]
        public IResult AddMultiple(IFormFile[] files, WeddingPlaceImage weddingPlaceImage)
        {
            var result = BusinessRules.Run(CheckIfImageLimitExceeded(weddingPlaceImage.WeddingPlaceId));
            if (result != null)
            {
                return result;
            }
            foreach (var file in files)
            {
                string imageName = string.Format(@"{0}.jpg", Guid.NewGuid());
                weddingPlaceImage.ImagePath = Paths.WpImagePath + imageName;
                weddingPlaceImage.Date = DateTime.Now;
                weddingPlaceImage.PlacePhotoId = 0;
                FileHelper.Write(file, Paths.RootPath + weddingPlaceImage.ImagePath);

                _weddingPlaceImageDal.Add(weddingPlaceImage);
            }
            return new SuccessResult(Messages.WeddingPlaceImageAdded);
        }

        public IResult Delete(WeddingPlaceImage wpImage)
        {
            WeddingPlaceImage willDeleteImage = _weddingPlaceImageDal.Get(wpI => wpI.PlacePhotoId == wpImage.PlacePhotoId);
            string path =willDeleteImage.ImagePath;

            _weddingPlaceImageDal.Delete(willDeleteImage);
            FileHelper.Delete(Paths.RootPath+path);

            return new SuccessResult(Messages.WeddingPlaceImageDeleted);
        }

        public IResult DeleteByWeddingPlaceId(int wpId)
        {
            var result = GetAllByWeddingPlaceId(wpId);
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Delete(item);
                }
            }
            return new SuccessResult();
        }

        public IDataResult<List<WeddingPlaceImage>> GetAll()
        {
            return new SuccessDataResult<List<WeddingPlaceImage>>(_weddingPlaceImageDal.GetAll());
        }

        public IDataResult<List<WeddingPlaceImage>> GetAllByWeddingPlaceId(int wpId)
        {
            var images = _weddingPlaceImageDal.GetAll(wpI => wpI.WeddingPlaceId== wpId);
            return new SuccessDataResult<List<WeddingPlaceImage>>(images);
        }

        public IDataResult<WeddingPlaceImage> GetById(int id)
        {
            return new SuccessDataResult<WeddingPlaceImage>(_weddingPlaceImageDal.Get(wpI => wpI.PlacePhotoId == id));
        }

        public IDataResult<List<WeddingPlaceImage>> GetImagesByWeddingPlaceId(int weddingPlaceId)
        {
            var wpImage = _weddingPlaceImageDal.GetAll().Where(wpI => wpI.WeddingPlaceId == weddingPlaceId).ToList();
            if (wpImage.Count == 0)
            {
                List<WeddingPlaceImage> weddingPlaceImages = new List<WeddingPlaceImage>();
                weddingPlaceImages.Add(new WeddingPlaceImage { WeddingPlaceId = weddingPlaceId, ImagePath = @"\Images\noimage.png", Date = DateTime.Now });
                return new SuccessDataResult<List<WeddingPlaceImage>>(weddingPlaceImages);
            }
            return new SuccessDataResult<List<WeddingPlaceImage>>(_weddingPlaceImageDal.GetAll(wpI => wpI.WeddingPlaceId == weddingPlaceId));
        }

        [ValidationAspect(typeof(WeddingPlaceImageValidator))]
        public IResult Update(WeddingPlaceImage wpImage, IFormFile file)
        {
            //wpImage.ImagePath = FileHelper.(_weddingPlaceImageDal.Get(wpI => wpI.PlacePhotoId == wpImage.PlacePhotoId).ImagePath, file);
            wpImage.Date = DateTime.Now;
            _weddingPlaceImageDal.Update(wpImage);
            return new SuccessResult(Messages.WeddingPlaceImageUpdated);
        }
        private IResult CheckIfImageLimitExceeded(int weddingPlaceId)
        {
            var wpImageCount = _weddingPlaceImageDal.GetAll(wp => wp.WeddingPlaceId == weddingPlaceId).Count;
            if (wpImageCount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }
    }
}
