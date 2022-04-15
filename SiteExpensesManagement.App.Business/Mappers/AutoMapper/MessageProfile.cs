using AutoMapper;
using SiteExpensesManagement.App.Contracts.Dtos.Message;
using SiteExpensesManagement.App.Contracts.ViewModels.Message;
using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Business.Mappers.AutoMapper
{
    public class MessageProfile:Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageForAddDto, Message>()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.Header, opt => opt.MapFrom(src => src.Header));

            CreateMap<MessageForUpdateDto, Message>();

            CreateMap<Message, MessageViewModel>()
                .ForMember(dest => dest.SenderFirstName, opt => opt.MapFrom(src => src.Sender.FirstName))
                .ForMember(dest => dest.SenderLastName, opt => opt.MapFrom(src => src.Sender.LastName))
                .ForMember(dest => dest.SenderPhoneNumber, opt => opt.MapFrom(src => src.Sender.PhoneNumber));


        }
    }
}
