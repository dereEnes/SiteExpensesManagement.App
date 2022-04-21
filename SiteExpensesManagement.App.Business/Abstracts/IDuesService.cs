using SiteExpensesManagement.App.Contracts.Dtos.DuesDtos;
using SiteExpensesManagement.App.Contracts.Dtos.Result;
using SiteExpensesManagement.App.Contracts.ViewModels.Dues;
using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SiteExpensesManagement.App.Business.Abstracts
{
    public interface IDuesService
    {
        IResult Add(DuesForAddDto duesForAddDto);
        IResult Delete(int id);
        IResult Update(DuesForUpdateDto duesForUpdateDto);
        IDataResult<DuesViewModel> GetById(int id);
        IDataResult<List<DuesViewModel>> GetAll();
        List<DuesViewModel> Get(Expression<Func<Dues,bool>> filter);
        void UpdateDuesAsPaid(int id);
        //List<DuesViewModel> GetUsersDues(string id);
    }
}
