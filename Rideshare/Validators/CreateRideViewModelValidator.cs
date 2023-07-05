using FluentValidation;
using Rideshare.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rideshare.Validators
{
    public class CreateRideViewModelValidator : AbstractValidator<CreateRideDto>
    {
        public CreateRideViewModelValidator() 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.StartCity)
                .NotEmpty().WithMessage("Start city is required.");
            RuleFor(x => x.DestinationCity)
                .NotEmpty().WithMessage("Destination city is required.");
            RuleFor(x => x.CarId)
                .NotEmpty().WithMessage("Car is required");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price is required.");
            RuleFor(x => x.StartTime)
                .NotEmpty().WithMessage("Start time is required.");
        }
    }
}
