using FluentValidation;
using SiteExpensesManagement.App.Contracts.Dtos.Dues;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Business.Validations.FluentValidation.DuesValidations
{
    public class DuesForAddDtoValidator:AbstractValidator<DuesForAddDto>
    {
        public DuesForAddDtoValidator()
        {
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0).WithMessage("Aidat tutarı en az 0 olabilir!");
        }
    }
}
