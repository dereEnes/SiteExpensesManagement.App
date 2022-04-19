using FluentValidation;
using SiteExpensesManagement.App.Contracts.Dtos.Bills;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Business.Validations.FluentValidation.BillValidations
{
    public class BillForUpdateDtoValidator:AbstractValidator<BillForUpdateDto>
    {
        public BillForUpdateDtoValidator()
        {
            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Fatura tutarı en az 0 olabilir!");
        }
    }
}
