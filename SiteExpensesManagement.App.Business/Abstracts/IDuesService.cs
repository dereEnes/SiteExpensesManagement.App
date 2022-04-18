using SiteExpensesManagement.App.Contracts.Dtos.Dues;
using SiteExpensesManagement.App.Contracts.Dtos.Result;
using SiteExpensesManagement.App.Contracts.ViewModels.Dues;
using System.Collections.Generic;

namespace SiteExpensesManagement.App.Business.Abstracts
{
    public interface IDuesService
    {
        IResult Add(DuesForAddDto duesForAddDto);
        IResult Delete(int id);
        IResult Update(DuesForUpdateDto duesForUpdateDto);
        IDataResult<DuesViewModel> GetById(int id);
        IDataResult<List<DuesViewModel>> GetAll();
        //List<DuesViewModel> GetUsersDues(string id);
    }
}
