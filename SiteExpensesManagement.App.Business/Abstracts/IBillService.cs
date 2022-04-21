using SiteExpensesManagement.App.Contracts.Dtos.Bills;
using SiteExpensesManagement.App.Contracts.Dtos.Result;
using SiteExpensesManagement.App.Contracts.ViewModels.Bills;
using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SiteExpensesManagement.App.Business.Abstracts
{
    public interface IBillService
    {
        IResult Add(BillForAddDto billForAddDto);
        IResult Delete(int id);
        IResult Update(BillForUpdateDto billForUpdateDto);
        List<BillViewModel> Get(Expression<Func<Bill, bool>> filter);
        BillViewModel GetById(int id);
        List<BillViewModel> GetAll();
        void UpdateBillAsPaid(int id);
    }
}
