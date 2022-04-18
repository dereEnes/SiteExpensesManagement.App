using SiteExpensesManagement.App.Contracts.Dtos.Bills;
using SiteExpensesManagement.App.Contracts.Dtos.Result;
using SiteExpensesManagement.App.Contracts.ViewModels.Bills;
using System.Collections.Generic;

namespace SiteExpensesManagement.App.Business.Abstracts
{
    public interface IBillService
    {
        IResult Add(BillForAddDto billForAddDto);
        IResult Delete(int id);
        IResult Update(BillForUpdateDto billForUpdateDto);
        BillViewModel GetById(int id);
        List<BillViewModel> GetAll();
    }
}
