using AutoMapper;
using SiteExpensesManagement.App.Contracts.Dtos.Apartment;
using SiteExpensesManagement.App.Domain.Entities;

namespace SiteExpensesManagement.App.Business.Mappers.AutoMapper
{
    public class ApartmentProfile:Profile
    {
        public ApartmentProfile()
        {
            CreateMap<ApartmentForCreateDto, Apartment>();
        }
    }
}
