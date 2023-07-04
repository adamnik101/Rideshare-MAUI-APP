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
    public class SearchRideViewModelValidator : AbstractValidator<RidesViewModel>
    {
        public SearchRideViewModelValidator() 
        {
            RuleFor(x => x.DestinationCity.Value)
                .NotEmpty().WithMessage("You must choose destination city.");
            RuleFor(x => x.StartCity.Value)
                .NotEmpty().WithMessage("You must choose start city.");
            RuleFor(x => x.Date.Value)
                .NotEmpty().WithMessage("You must choose ride date.");
        }
    }
}
