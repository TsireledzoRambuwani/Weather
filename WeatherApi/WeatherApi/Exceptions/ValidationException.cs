

using FluentValidation.Results;

namespace WeatherApi.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base("One or more validation failures occurred.")
        {
            Errors = new List<string>();
        }
        public ValidationException(IEnumerable<ValidationFailure> failures) 
            : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }
        public List<string> Errors  { get; }
    }
}
