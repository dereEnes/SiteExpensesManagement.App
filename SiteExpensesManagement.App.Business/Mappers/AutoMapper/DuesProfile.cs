using AutoMapper;
using SiteExpensesManagement.App.Contracts.Dtos.Dues;
using SiteExpensesManagement.App.Contracts.ViewModels.Dues;
using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Business.Mappers.AutoMapper
{
    public class DuesProfile:Profile
    {
        public DuesProfile()
        {
            CreateMap<DuesForAddDto,Dues>();
            CreateMap<DuesForUpdateDto, Dues>();
            CreateMap<Dues, DuesViewModel>()
                .ForMember(dest => dest.Month, src=> src.MapFrom(src => src.Month));
        }
    }
}
