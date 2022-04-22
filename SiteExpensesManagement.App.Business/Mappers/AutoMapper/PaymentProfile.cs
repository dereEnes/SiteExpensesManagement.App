using AutoMapper;
using SiteExpensesManagement.App.Contracts.Dtos.Payments;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Business.Mappers.AutoMapper
{
    public class PaymentProfile:Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentForBillDto, PaymentDto>()
                .ForMember(dest => dest.BillId, opt => opt.MapFrom(src => src.BillId))
                .ForMember(dest => dest.CardNumber, opt => opt.MapFrom(src => src.CreditCard.CardNumber))
                .ForMember(dest => dest.Cvv, opt => opt.MapFrom(src => src.CreditCard.Cvv))
                .ForMember(dest => dest.ExpiryMonth, opt => opt.MapFrom(src => src.CreditCard.ExpiryMonth))
                .ForMember(dest => dest.ExpiryYear, opt => opt.MapFrom(src => src.CreditCard.ExpiryYear))
                .ForMember(dest => dest.NameOnCard, opt => opt.MapFrom(src => src.CreditCard.NameOnCard))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<PaymentForDuesDto, PaymentDto>()
                .ForMember(dest => dest.BillId, opt => opt.MapFrom(src => src.DuesId))
                .ForMember(dest => dest.CardNumber, opt => opt.MapFrom(src => src.CreditCard.CardNumber))
                .ForMember(dest => dest.Cvv, opt => opt.MapFrom(src => src.CreditCard.Cvv))
                .ForMember(dest => dest.ExpiryMonth, opt => opt.MapFrom(src => src.CreditCard.ExpiryMonth))
                .ForMember(dest => dest.ExpiryYear, opt => opt.MapFrom(src => src.CreditCard.ExpiryYear))
                .ForMember(dest => dest.NameOnCard, opt => opt.MapFrom(src => src.CreditCard.NameOnCard))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
        }
    }
}
