using FluentValidation;
using SiteExpensesManagement.App.Contracts.Dtos.Apartment;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Business.Validations.FluentValidation
{
    public class ApartmentValidator:AbstractValidator<ApartmentForCreateDto>
    {
        public ApartmentValidator()
        {
            RuleFor(x => x.ApartmentNo).GreaterThan(0).WithMessage("Apartman numarası 0 dan büyük olmalıdır.");
            RuleFor(x => x.FloorNumber).GreaterThan((byte)0).WithMessage("Kat numarası 0 dan büyük olmalıdır.");
        }
    }
}
