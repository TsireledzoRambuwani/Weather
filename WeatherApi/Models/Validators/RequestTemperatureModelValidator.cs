using FluentValidation;
using WeatherApi.Models.Request;

namespace WeatherApi.Models.Validators
{
    public class RequestTemperatureModelValidator : AbstractValidator<RequestTemperatureModel>
    {
        public RequestTemperatureModelValidator()
        {
            RuleFor(p => p.Celsius)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
                //.InclusiveBetween(-90, 90)
                //.WithMessage("Value must be number Beetween -90 , 90");


        }
    }
}

