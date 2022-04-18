using FluentValidation;
using SiteExpensesManagement.App.Contracts.Dtos.Bills;
using SiteExpensesManagement.App.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Business.Validations.FluentValidation.BillValidations
{
    public class BillForAddDtoValidator:AbstractValidator<BillForAddDto>
    {
        public BillForAddDtoValidator()
        {
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0).WithMessage("Fatura tutarı en az 0 olabilir!");
        }
    }
}
