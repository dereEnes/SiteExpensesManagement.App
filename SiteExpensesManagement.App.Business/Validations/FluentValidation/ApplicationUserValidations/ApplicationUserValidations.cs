using FluentValidation;
using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Business.Validations.FluentValidation.ApplicationUserValidations
{
    public class ApplicationUserValidator:AbstractValidator<ApplicationUser>
    {
        public ApplicationUserValidator()
        {
            RuleFor(x => x.FirstName)
                .MinimumLength(3)
                .WithMessage("İsim en az 3 karakter olmalı")
                .MaximumLength(30)
                .WithMessage("İsim en fazla 30 karakter olabilir.");

            RuleFor(x => x.LastName)
                .MinimumLength(3)
                .WithMessage("Soyisim en az 3 karakter olmalı")
                .MaximumLength(30)
                .WithMessage("Soyisim en fazla 30 karakter olabilir.");

            RuleFor(x => x.PhoneNumber)
                .MinimumLength(11)
                .MaximumLength(11)
                .WithMessage("Geçersiz telefon numarası");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Geçersiz Email adresi");

        }
    }
}
