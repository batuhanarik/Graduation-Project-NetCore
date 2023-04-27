using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public IDataResult<List<WeddingPlaceImage>> GetAll()
        {
            return new SuccessDataResult<List<WeddingPlaceImage>>(_weddingPlaceImageDal.GetAll());
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
            return new SuccessResult(Messages.CarImageUpdated);
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
