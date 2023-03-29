using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CityManager : ICityService
    {
        private ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }


        public IResult Add(City city)
        {
            _cityDal.Add(city);
            return new SuccessResult("City Added");
        }

        public IResult Delete(City city)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<City>> GetAll()
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetAll(), "Cities listed");
        }

        public IDataResult<City> GetByPlateCode(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(City city)
        {
            throw new NotImplementedException();
        }
    }
}
