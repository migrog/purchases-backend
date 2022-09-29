using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using product.domain.entities;

namespace product.domain.core.validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ingrese Name");
            RuleFor(x => x.UnitPrice).NotEmpty().WithMessage("Ingrese UnitPrice");
            RuleFor(x => x.CurrencyTypeEnum).NotEmpty().WithMessage("Ingrese CurrencyTypeEnum");
        }
    }
}
