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
        Task<List<CreditCard>> Add(PaymentForAddDto paymentForAddDto);
        Task<List<CreditCard>> GetUserCards(string id);
    }
}
