using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using purchase.domain.entities;

namespace purchase.domain.core.valitators
{
    public class PurchaseValidator: AbstractValidator<Purchase>
    {
        public PurchaseValidator() 
        {
            RuleFor(x => x.CurrencyTypeEnum).NotEmpty().WithMessage("Ingrese CurrencyTypeEnum");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Ingrese UserId");
        }
    }
    public class PurchaseDetailValidator : AbstractValidator<PurchaseDetail>
    {
        public PurchaseDetailValidator()
        {

        }
    }
}
