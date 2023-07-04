using FluentValidation;
using Rideshare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rideshare.Validators
{
    public class RegisterViewModelValidator : AbstractValidator<MRegisterViewModel>
    {
        public RegisterViewModelValidator() 
        {
            RuleFor(x => x.FirstName.Value)
                .NotEmpty().WithMessage("First name is required.");
            RuleFor(x => x.LastName.Value)
                .NotEmpty().WithMessage("Last name is required.");
            RuleFor(x => x.Email.Value)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email format is not valid.");
            RuleFor(x => x.PhoneNumber.Value)
                .NotEmpty().WithMessage("Phone number is required.");
        }
    }
}
