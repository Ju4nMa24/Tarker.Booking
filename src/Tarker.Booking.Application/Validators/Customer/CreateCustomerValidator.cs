using FluentValidation;
using Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer;

namespace Tarker.Booking.Application.Validators.Customer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerModel>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.DocumentNumber).NotEmpty().NotNull().MaximumLength(20);
            RuleFor(x => x.FullName).NotEmpty().NotNull().MaximumLength(50);
        }
    }
}
