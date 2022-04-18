using AutoMapper;
using SiteExpensesManagement.App.Contracts.Dtos.Apartments;
using SiteExpensesManagement.App.Contracts.ViewModels.Apartments;
using SiteExpensesManagement.App.Domain.Entities;

namespace SiteExpensesManagement.App.Business.Mappers.AutoMapper
{
    public class ApartmentProfile:Profile
    {
        public ApartmentProfile()
        {
            CreateMap<ApartmentForCreateDto, Apartment>();

            CreateMap<Apartment, ApartmentViewModel>()
                .ForMember(dest => dest.Block, opt => opt.MapFrom(src => src.Block.ToString()));

            CreateMap<Apartment, ApartmentBillsDto>()
                .ForMember(dest => dest.Bills, opt => opt.MapFrom(src => src.Bills))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Block, opt => opt.MapFrom(src => src.Block.ToString()));
        }
    }
}
