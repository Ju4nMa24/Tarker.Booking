using FluentValidation;

namespace Tarker.Booking.Application.Validators.User
{
    public class GetUserByUserNameAndPaswordValidator : AbstractValidator<(string, string)>
    {
        public GetUserByUserNameAndPaswordValidator()
        {
            RuleFor(x => x.Item1).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.Item2).NotEmpty().NotNull().MaximumLength(20);
        }
    }
}
