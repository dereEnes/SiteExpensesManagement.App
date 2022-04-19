using FluentValidation;
using SiteExpensesManagement.App.Contracts.Dtos.Apartments;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Business.Validations.FluentValidation.ApartmentValidations
{
    public class ApartmentForAddDtoValidator : AbstractValidator<ApartmentForCreateDto>
    {
        public ApartmentForAddDtoValidator()
        {
            RuleFor(x => x.UserId)
                .MinimumLength(30)
                .MaximumLength(70)
                .WithMessage("Hatalı kullanıcı seçimi");

            RuleFor(x => x.ApartmentNo)
                .GreaterThan(0)
                .WithMessage("Apartman numarası 0 dan büyük olmalıdır.");

            RuleFor(x => x.FloorNumber)
                .GreaterThan((byte)0)
                .WithMessage("Kat numarası 0 dan büyük olmalıdır.");

            RuleFor(x => (int)x.Block)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Hatalı blok seçimi");
        }
    }
}
