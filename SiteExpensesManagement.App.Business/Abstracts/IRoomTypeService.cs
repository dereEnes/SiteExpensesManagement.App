using SiteExpensesManagement.App.Contracts.Dtos.Result;
using SiteExpensesManagement.App.Contracts.ViewModels;
using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Business.Abstracts
{
    public interface IRoomTypeService
    {
        IDataResult<List<RoomTypeViewModel>> GetAll();
        IResult Delete(int id);
        IDataResult<RoomTypeViewModel> GetById(int id);
    }
}
