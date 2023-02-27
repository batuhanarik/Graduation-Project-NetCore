using Core.Entities;
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
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name).NotEmpty();
            RuleFor(u => u.Name).MinimumLength(2);

            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(2);

            RuleFor(u => u.Mail).NotEmpty();
            RuleFor(u => u.Mail).MinimumLength(2);
            RuleFor(u => u.Mail).EmailAddress().WithMessage("Mail Adresi Doğru Formatta Olmalıdır.");

            //RuleFor(u => u.IsWeddingPlaceOwner).NotEmpty();

        //    RuleFor(u => u.PhoneNumber).NotEmpty();
        //    RuleFor(u => u.PhoneNumber).Must(RegExPhoneNumber).WithMessage("Telefon Numarası Doğru Formatta Olmalıdır.");
        }

        private bool RegExPhoneNumber(string arg)
        {
            var validatePhoneNumberRegex = new Regex("^\\+?[1-9][0-9]{7,14}$");
            return validatePhoneNumberRegex.IsMatch(arg);
        }
    }
}
