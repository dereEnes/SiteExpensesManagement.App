using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Business.Abstracts
{
    public interface IBillPaymentService
    {
        void Add(BillPayment billPayment);
        List<BillPayment> GetAll();
        List<BillPayment> GetUserPayments(string id);
    }
}
