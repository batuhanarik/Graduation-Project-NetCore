using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class WeddingPlaceValidator:AbstractValidator<WeddingPlace>
    {
        public WeddingPlaceValidator()
        {

            RuleFor(w=>w.PlateCode).NotEmpty();
            RuleFor(w=>w.PlateCode).GreaterThan(0);

            RuleFor(w => w.PlaceName).NotEmpty();
            RuleFor(w => w.PlaceName).MinimumLength(3);


            RuleFor(w => w.PhoneNumber).NotEmpty();
            RuleFor(w => w.PhoneNumber).Must(RegExPhoneNumber).WithMessage("Telefon Numarası Doğru Formatta Olmalıdır.");

            RuleFor(w => w.Description).NotEmpty();
            RuleFor(w => w.Description).Length(0, 15000);

            RuleFor(w => w.CapacityFirst).NotEmpty();
            RuleFor(w => w.CapacityLast).GreaterThan(0);

            RuleFor(w => w.PriceWeekday).NotEmpty();
            RuleFor(w => w.PriceWeekday).GreaterThan(0);

            RuleFor(w => w.PriceWeekend).NotEmpty();
            RuleFor(w => w.PriceWeekend).GreaterThan(0);

            RuleFor(w => w.DiscountRate).GreaterThanOrEqualTo(0);

            //RuleFor(w => w.isAlcoholIncluded).NotEmpty();
            //RuleFor(w=>w.isFoodIncluded).NotEmpty();

            RuleFor(w => w.PlaceStatus).NotEmpty();

        }

        private bool RegExPhoneNumber(string arg)
        {
            var validatePhoneNumberRegex = new Regex("^\\+?[1-9][0-9]{7,14}$");
            return validatePhoneNumberRegex.IsMatch(arg);
        }
    }
}
