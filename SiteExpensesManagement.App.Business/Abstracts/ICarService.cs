using SiteExpensesManagement.App.Contracts.Dtos.Car;
using SiteExpensesManagement.App.Contracts.Dtos.Result;
using SiteExpensesManagement.App.Contracts.ViewModels.Car;
using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SiteExpensesManagement.App.Business.Abstracts
{
    public interface ICarService
    {
        IResult Add(CarForAddDto carForAddDto);
        IResult Delete(int id);
        IResult Update(CarForUpdateDto carForUpdateDto);
        IDataResult<List<CarViewModel>> GetAll();
        IDataResult<CarViewModel> GetById(int id);
    }
}
