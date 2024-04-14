using FluentValidation;
using WeatherApi.Models.Request;

namespace WeatherApi.Models.Validators
{
    public class RequestDurationModelValidator : AbstractValidator<RequestDurationModel>
    {
        public RequestDurationModelValidator()
        {
            RuleFor(p => p.StartDate)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .GreaterThanOrEqualTo(p => DateTime.Now).WithMessage("Date should be Current date or greater")
                .LessThan(p => DateTime.Now.AddDays(7)).WithMessage("Date cannot excedd 7 days from now");

            RuleFor(p => p.EndDate)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .GreaterThan(p => p.StartDate).WithMessage("End date must be greater than Start Date")
              .LessThan(p => DateTime.Now.AddDays(7)).WithMessage("Date cannot excedd 7 days from now");

        }
    }
}

