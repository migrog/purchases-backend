using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using user.domain.entities;

namespace user.domain.core.validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ingrese Name");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Ingrese Email");
        }
    }
}
