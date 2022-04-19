using FluentValidation;
using SiteExpensesManagement.App.Contracts.Dtos.DuesDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Business.Validations.FluentValidation.DuesValidations
{
    public class DuesForUpdateDtoValidator:AbstractValidator<DuesForUpdateDto>
    {
        public DuesForUpdateDtoValidator()
        {
            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Fatura tutarı en az 0 olabilir!");
        }
    }
}
