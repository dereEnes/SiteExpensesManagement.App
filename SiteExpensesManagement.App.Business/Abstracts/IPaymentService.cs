using SiteExpensesManagement.App.Contracts.Dtos.Payments;
using SiteExpensesManagement.App.Contracts.Dtos.Result;
using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SiteExpensesManagement.App.Business.Abstracts
{
    public interface IPaymentService
    {
        Task<List<CreditCard>> Add(PaymentForBillDto paymentForAddDto);
        Task<List<CreditCard>> Add(PaymentForDuesDto paymentForAddDto);
        Task<CreditCard> GetUserCard(string id);
    }
}
