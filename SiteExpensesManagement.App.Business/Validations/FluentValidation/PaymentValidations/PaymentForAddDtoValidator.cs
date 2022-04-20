using FluentValidation;
using SiteExpensesManagement.App.Contracts.Dtos.Payments;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Business.Validations.FluentValidation.PaymentValidations
{
    public class PaymentForAddDtoValidator:AbstractValidator<PaymentForBillDto>
    {
        public PaymentForAddDtoValidator()
        {
            RuleFor(x => x.CreditCard.CardNumber)
                .NotEmpty()
                .WithMessage("Kart numarası boş girilemez!")
                .MinimumLength(16)
                .MaximumLength(16)
                .WithMessage("Lütfen 16 karakter giriniz!");

            RuleFor(x => x.CreditCard.ExpiryMonth)
                .NotEmpty()
                .WithMessage("Son kullanma yılı boş girilemez")
                .GreaterThanOrEqualTo((byte)1)
                .LessThanOrEqualTo((byte)12)
                .WithMessage("Kart son kullanma ayı hatalı!");

            RuleFor(x => x.CreditCard.ExpiryYear)
                .NotEmpty()
                .WithMessage("Son kullanma yılı boş girilemez")
                .GreaterThanOrEqualTo(((short)DateTime.Today.Year))
                .WithMessage("Kart son kullanma yılı geçersiz!");

            RuleFor(x => x.CreditCard.NameOnCard)
                .NotNull()
                .WithMessage("Kart üzerindeki isim boş girilemez")
                .MinimumLength(4)
                .MaximumLength(30)
                .WithMessage("Kart üzerindeki isim en az 4, en fazla 30 karakter olabilir!");

            RuleFor(x => x.CreditCard.Cvv)
                .NotEmpty()
                .NotNull()
                .WithMessage("Cvv değeri boş girilemez")
                .GreaterThanOrEqualTo((short)0)
                .LessThanOrEqualTo((short)999)
                .WithMessage("Cvv numarası hatalı");

            RuleFor(x => x.BillId)
                .GreaterThan(0)
                .WithMessage("Fatura hatalı");

            RuleFor(x => x.Amount)
                .GreaterThan(0)
                .WithMessage("Fatura Tutar Hatası");
        }
    }
}
