using FluentValidation;
using WeatherApi.Models.Request;

namespace WeatherApi.Models.Validators
{
    public class RequestWeatherModelValidator : AbstractValidator<RequestWeatherModel>
    {
        public RequestWeatherModelValidator()
        {
            RuleFor(p => p.Latitude)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .InclusiveBetween(-90, 90)
                .WithMessage("Value must be number Beetween -90 , 90"); 

            RuleFor(p => p.Longitude)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .NotNull()
              .InclusiveBetween(-180, 180)
              .WithMessage("Value must be number Beetween -180 , 180");


        }
    }
}
