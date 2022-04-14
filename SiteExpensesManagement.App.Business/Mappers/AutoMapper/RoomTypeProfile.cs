using AutoMapper;
using SiteExpensesManagement.App.Contracts.ViewModels;
using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Business.Mappers.AutoMapper
{
    public class RoomTypeProfile:Profile
    {
        public RoomTypeProfile()
        {
            CreateMap<RoomType,RoomTypeViewModel>();
        }
    }
}
