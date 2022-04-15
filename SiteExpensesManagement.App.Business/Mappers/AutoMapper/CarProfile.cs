using AutoMapper;
using SiteExpensesManagement.App.Contracts.Dtos.Car;
using SiteExpensesManagement.App.Contracts.ViewModels.Car;
using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Business.Mappers.AutoMapper
{
    public class CarProfile: Profile
    {
        public CarProfile()
        {
            CreateMap<CarForUpdateDto,Car>();
            CreateMap<CarForAddDto, Car>();
            CreateMap<Car, CarViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.LicencePlate, opt => opt.MapFrom(src => src.LicencePlate));
           // CreateMap<List<Car>, List<CarViewModel>>();
        }
    }
}
