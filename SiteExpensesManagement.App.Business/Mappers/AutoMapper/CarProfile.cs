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
            CreateMap<Car, CarViewModel>();
           // CreateMap<List<Car>, List<CarViewModel>>();
        }
    }
}
