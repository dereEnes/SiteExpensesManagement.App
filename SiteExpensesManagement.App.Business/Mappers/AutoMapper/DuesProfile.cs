using AutoMapper;
using SiteExpensesManagement.App.Contracts.Dtos.DuesDtos;
using SiteExpensesManagement.App.Contracts.ViewModels.Dues;
using SiteExpensesManagement.App.Domain.Entities;

namespace SiteExpensesManagement.App.Business.Mappers.AutoMapper
{
    public class DuesProfile:Profile
    {
        public DuesProfile()
        {
            CreateMap<DuesForAddDto,Dues>();
            CreateMap<DuesForUpdateDto, Dues>();
            CreateMap<Dues, DuesViewModel>()
                .ForMember(dest => dest.Month, src=> src.MapFrom(src => src.Month))
                .ForMember(dest => dest.Apartment, src => src.MapFrom(src => src.Apartment));


        }
    }
}
