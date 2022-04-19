using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Contracts.Dtos.Payments
{
    public class PaymentForAddDto
    {
        public int BillId { get; set; }
        public CreditCard CreditCard { get; set; }
        public decimal Amount { get; set; }

    }
}
