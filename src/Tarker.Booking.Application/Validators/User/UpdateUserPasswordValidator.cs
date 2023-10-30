﻿using FluentValidation;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword;

namespace Tarker.Booking.Application.Validators.User
{
    public class UpdateUserPasswordValidator : AbstractValidator<UpdateUserPasswordModel>
    {
        public UpdateUserPasswordValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull();
            RuleFor(x => x.Password).NotEmpty().NotNull().MaximumLength(20);
        }
    }
}
