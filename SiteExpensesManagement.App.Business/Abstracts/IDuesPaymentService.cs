using SiteExpensesManagement.App.Domain.Entities;
using System.Collections.Generic;

namespace SiteExpensesManagement.App.Business.Abstracts
{
    public interface IDuesPaymentService
    {
        void Add(DuesPayment duesPayment);
        List<DuesPayment> GetUserPayments(string id);
        List<DuesPayment> GetAll();
    }
}
