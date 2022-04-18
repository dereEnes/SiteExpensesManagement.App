using AutoMapper;
using SiteExpensesManagement.App.Contracts.Dtos.Bills;
using SiteExpensesManagement.App.Contracts.ViewModels.Bills;
using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Business.Mappers.AutoMapper
{
    public class BillProfile:Profile
    {
        public BillProfile()
        {
            CreateMap<BillForAddDto,Bill>();
            CreateMap<BillForUpdateDto,Bill>();

            CreateMap<Bill,BillViewModel>()
                .ForMember(dest => dest.Month, opt => opt.MapFrom(src => src.Month.ToString()))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString()));
        }
    }
}
