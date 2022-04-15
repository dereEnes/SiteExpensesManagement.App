using FluentValidation;
using SiteExpensesManagement.App.Contracts.Dtos.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Business.Validations.FluentValidation.MessageValidations
{
    public class MessageForUpdateDtoValidator : AbstractValidator<MessageForUpdateDto>
    {
        public MessageForUpdateDtoValidator()
        {
            RuleFor(x => x.Content).NotEmpty().NotNull().MinimumLength(1).MaximumLength(250).WithMessage("Mesaj içeriği 1 ile 250 karakter arası olmalı.");
            RuleFor(x => x.Header).NotEmpty().NotNull().MinimumLength(1).MaximumLength(20).WithMessage("Mesaj başlığı 1 ile 250 karakter arası olmalı.");
        }
    }
}
