using FluentValidation;
using Rideshare.Business.DTOs;
using Rideshare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rideshare.Validators
{
    public class AddCarViewModelValidator : AbstractValidator<AddCarViewModel>
    {
        public AddCarViewModelValidator() 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.SelectedBrand)
                .NotEmpty().WithMessage("Brand is required.");
            RuleFor(x => x.SelectedModel.Value)
               .NotEmpty().WithMessage("Model is required.");
            RuleFor(x => x.SelectedYear.Value)
               .NotEmpty().WithMessage("Registration is required.");
            RuleFor(x => x.SelectedColor.Value)
               .NotEmpty().WithMessage("Color is required.");
            RuleFor(x => x.LicencePlate.Value)
               .NotEmpty().WithMessage("Licence plate is required.");
            RuleFor(x => x.SelectedNumberOfSeats.Value)
               .NotEmpty().WithMessage("Number of seats is required.");
            RuleFor(x => x.SelectedType.Value)
               .NotEmpty().WithMessage("Type is required.");
        }
    }
}
