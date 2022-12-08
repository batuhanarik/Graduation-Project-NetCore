using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class PlaceTypeValidator : AbstractValidator<PlaceType>
    {
        public PlaceTypeValidator()
        {
            RuleFor(p => p.PlaceTypeName).NotNull();
            RuleFor(p => p.PlaceTypeName).MinimumLength(3);
        }
    }
}
