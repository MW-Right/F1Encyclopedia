using F1Encyclopedia.Data.Models.Drivers;
using FluentValidation;

namespace F1Encyclopedia.Validators.Drivers
{
    public class DriverValidator : AbstractValidator<Driver>
    {
        public DriverValidator()
        {
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.LastName).NotNull();
        }
    }
}