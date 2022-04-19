using FluentValidation;
using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Business.Validations.FluentValidation.CreditCardValidations
{
    public class CreditCardValidator:AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(x => x.CardNumber)
                .NotEmpty()
                .WithMessage("Kart numarası boş girilemez!")
                .MinimumLength(16)
                .MaximumLength(16)
                .WithMessage("Kart Numarası Hatalı");

            RuleFor(x => x.ExpiryMonth)
                .NotEmpty()
                .WithMessage("Son kullanma yılı boş girilemez")
                .GreaterThanOrEqualTo((byte)1)
                .LessThanOrEqualTo((byte)12)
                .WithMessage("Kart son kullanma ayı hatalı!");

            RuleFor(x => x.ExpiryYear)
                .NotEmpty()
                .WithMessage("Son kullanma yılı boş girilemez")
                .GreaterThanOrEqualTo(((short)DateTime.Today.Year))
                .WithMessage("Kart son kullanma yılı geçersiz!");

            RuleFor(x => x.NameOnCard)
                .NotNull()
                .WithMessage("Kart üzerindeki isim boş girilemez")
                .MinimumLength(4)
                .MaximumLength(30)
                .WithMessage("Kart üzerindeki isim en az 4, en fazla 30 karakter olabilir!");

            RuleFor(x => x.Cvv)
                .NotEmpty()
                .NotNull()
                .WithMessage("Cvv değeri boş girilemez")
                .GreaterThanOrEqualTo((short)0)
                .LessThanOrEqualTo((short)999)
                .WithMessage("Cvv numarası hatalı");
            
        }
    }
}
