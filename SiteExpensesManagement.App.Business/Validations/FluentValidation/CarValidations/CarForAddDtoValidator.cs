using FluentValidation;
using SiteExpensesManagement.App.Contracts.Dtos.Car;
using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Business.Validations.CarValidations
{
    public class CarForAddDtoValidator:AbstractValidator<CarForAddDto>
    {
        public CarForAddDtoValidator()
        {
            RuleFor(x => x.UserId)
                .MinimumLength(30)
                .MaximumLength(70)
                .WithMessage("Hatalı kullanıcı seçimi");

            RuleFor(x => x.LicencePlate)
                .MaximumLength(20)
                .MinimumLength(7)
                .WithMessage("Geçersiz Plaka Numarası");
        }
    }
}
