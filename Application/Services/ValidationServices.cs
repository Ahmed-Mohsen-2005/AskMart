using FluentValidation;

namespace Application.Services
{
    public class ValidationServices
    {

        public static void Validate<T>(IValidator<T> validator, T request)
        {
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException($"Validation failed: {errors}");
            }
        }


    }
}
