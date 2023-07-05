using FluentValidation;
using Rideshare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Rideshare.Validators
{
    public class RegisterViewModelValidator : AbstractValidator<MRegisterViewModel>
    {
        public RegisterViewModelValidator() 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.FirstName.Value)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(25).WithMessage("Maximum length is 25 characters.");
            RuleFor(x => x.LastName.Value)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(25).WithMessage("Maximum length is 25 characters.");
            RuleFor(x => x.Email.Value)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email format is not valid.");
            var phoneRegex = "[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}";
            RuleFor(x => x.PhoneNumber.Value)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(phoneRegex).WithMessage("Phone number format is not valid.");
            var pwRegex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            RuleFor(x => x.Password.Value)
                .NotEmpty().WithMessage("Password is required.")
                .Matches(pwRegex).WithMessage("Minimum 8 characters, one upper case, one lower, one number and one symbol.");
        }
    }
}
