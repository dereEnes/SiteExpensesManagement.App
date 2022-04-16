using SiteExpensesManagement.App.Contracts.Dtos;
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
        IDataResult<RoomTypeViewModel> GetById(int id);
        IResult Delete(int id);
        IResult Add(RoomTypeForAddDto roomTypeForAddDto);
        IResult Update(RoomTypeForUpdateDto roomTypeForUpdateDto);
        
    }
}
