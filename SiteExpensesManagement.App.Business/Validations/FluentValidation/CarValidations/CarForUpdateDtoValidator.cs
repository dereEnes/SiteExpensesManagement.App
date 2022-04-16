using FluentValidation;
using SiteExpensesManagement.App.Contracts.Dtos.Car;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Business.Validations.FluentValidation.CarValidations
{
    public class CarForUpdateDtoValidator:AbstractValidator<CarForUpdateDto>
    {
        public CarForUpdateDtoValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().MinimumLength(30).MaximumLength(70).WithMessage("Hatalı kullanıcı seçimi");
            RuleFor(x => x.LicencePlate).NotNull().MaximumLength(20).MinimumLength(7).WithMessage("Geçersiz Plaka Numarası");
        }
    }
}
