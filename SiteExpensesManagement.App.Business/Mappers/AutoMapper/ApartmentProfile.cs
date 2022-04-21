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
                .ForMember(dest => dest.Block, opt => opt.MapFrom(src => src.Block.ToString()))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.lastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.RoomType.CountOfRooms))
                .ForMember(dest => dest.RoomTypeId, opt => opt.MapFrom(src => src.RoomType.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id));


            CreateMap<Apartment, ApartmentBillsDto>()
                .ForMember(dest => dest.Bills, opt => opt.MapFrom(src => src.Bills))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Block, opt => opt.MapFrom(src => src.Block.ToString()));

            CreateMap<Apartment, ApartmentDuesDto>()
                .ForMember(dest => dest.Dues, opt => opt.MapFrom(src => src.Dues))
                .ForMember(dest => dest.Block, src => src.MapFrom(src => src.Block.ToString()))
                .ForMember(dest => dest.User, src => src.MapFrom(src => src.User));

            CreateMap<ApartmentForUpdateDto, Apartment>()
                .ForMember(dest => dest.RoomTypeId, opt => opt.MapFrom(src => src.RoomTypeId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));


        }
    }
}
