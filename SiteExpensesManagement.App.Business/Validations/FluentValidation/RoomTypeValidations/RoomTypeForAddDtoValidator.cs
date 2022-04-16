using FluentValidation;
using SiteExpensesManagement.App.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Business.Validations.FluentValidation.RoomTypeValidations
{
    public class RoomTypeForAddDtoValidator:AbstractValidator<RoomTypeForAddDto>
    {
        public RoomTypeForAddDtoValidator()
        {
            RuleFor(x => x.CountOfRooms).MaximumLength(30).WithMessage("30 Karakterden fazla girmeyin lütfen!");
            RuleFor(x => x.CountOfRooms).NotEmpty().NotNull().WithMessage("Oda sayısı boş girilemez!");
        }
    }
}
