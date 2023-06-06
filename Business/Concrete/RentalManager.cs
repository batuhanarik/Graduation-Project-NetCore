using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        IWeddingPlaceService _weddingPlaceService;
        IPaymentService _paymentService;
        ICustomerService _customerService;
        IInvoiceService _invoiceService;
        public RentalManager(IRentalDal rentalDal, IPaymentService paymentService, IWeddingPlaceService wpService, ICustomerService customerService, IInvoiceService invoiceService)
        {
            _rentalDal = rentalDal;
            _paymentService = paymentService;
            _weddingPlaceService = wpService;
            _customerService = customerService;
            _invoiceService = invoiceService;
        }
        //[CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental, CreditCard card)
        {
            var businessResult = BusinessRules.Run(
                CheckIfWeddingPlaceRented(rental)
                );
            if (businessResult != null)
            {
                return businessResult;
            }
            var weddingPlace =
                _weddingPlaceService.GetById(rental.WeddingPlaceId).Data;
            var cocktailPrice = weddingPlace.IsCocktailIncluded ? weddingPlace.PriceCocktail : 0;
            var alcoholPrice = weddingPlace.IsAlcoholIncluded ? weddingPlace.PriceAlcohol : 0;
            var foodPrice = weddingPlace.IsFoodIncluded ? weddingPlace.PriceFood : 0;
            rental.RentDate = rental.RentDate.AddHours(3);
            rental.ReturnDate = rental.RentDate;
            var rentalDateDay = rental.RentDate.DayOfWeek;
            var rentalPrice = (rentalDateDay == DayOfWeek.Saturday) || (rentalDateDay == DayOfWeek.Sunday) ? weddingPlace.PriceWeekend
                   : weddingPlace.PriceWeekday;

            rental.TotalPrice = (int)(cocktailPrice + alcoholPrice + foodPrice + rentalPrice);

            var paymentResult = _paymentService.Pay(card, rental.TotalPrice);
            if (!paymentResult.Success)
            {
                return paymentResult;
            }

            var invoice = new InvoiceDto();
            invoice.OrderId = 1;
            invoice.Email = "batuhanarik123@gmail.com";
            _rentalDal.Add(rental);
            //_invoiceService.SendInvoice(invoice);

            return new SuccessResult(Messages.WeddingPlaceRented);
        }

        //[SecuredOperation("admin")]
        //[CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        //[CacheAspect(10)]
        public IDataResult<Rental> Get(int userId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(u => u.Id == userId));
        }

        //[SecuredOperation("admin")]
        //[CacheAspect(10)]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<DateTime>> GetOccupiedDates(int wpId)
        {
            List<DateTime> occupiedDates = new();

            DateTime date = DateTime.Today;
            var lastDate = date.AddDays(30);

            var rentals = _rentalDal.GetAll(r =>
                r.WeddingPlaceId == wpId &&
                r.RentDate >= DateTime.Today
            );
            if(rentals.Count >0) {

                for (; date < lastDate; date = date.AddDays(1))
                {
                    foreach (var rental in rentals)
                    {
                        if (date.Month == rental.RentDate.Month && date.Day == rental.RentDate.Day)
                        {
                            occupiedDates.Add(date);
                            break;
                        }
                    }
                }
            }

            return new SuccessDataResult<List<DateTime>>(occupiedDates);

        }

        //[CacheAspect(10)]
        //[SecuredOperation("admin")]
        public IDataResult<List<RentalDetailDto>> GetDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails().OrderByDescending(r => r.RentDate).ToList());
        }

        //[SecuredOperation("admin")]
        //[CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }



        private IResult CheckIfWeddingPlaceRented(Rental rental)
        {
            var isOccupied = _rentalDal.GetAll(r => r.WeddingPlaceId == rental.WeddingPlaceId&&
                r.ReturnDate >= rental.RentDate && 
                r.RentDate <= rental.ReturnDate 
            ).Any();
            if (isOccupied)
            {
                return new ErrorResult(Messages.WeddingPlaceAlreadyRented);
            }
            return new SuccessResult();
        }

    }
}
