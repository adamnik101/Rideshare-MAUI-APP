using FluentValidation;
using Rideshare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rideshare.Validators
{
    public class LoginViewModelValidator : AbstractValidator<MLoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(x => x.Email.Value)
                .NotEmpty().WithMessage("Email je obavezno polje.")
                .EmailAddress().WithMessage("Email nije ispravnog formata.");
            RuleFor(x => x.Password.Value)
                   .NotEmpty()
                   .WithMessage("Lozinka je obavezno polje.")
                   .MinimumLength(5)
                   .WithMessage("Minimalan broj karaktera je 8.");
        }
    }
}
