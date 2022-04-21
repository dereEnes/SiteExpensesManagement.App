using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Contracts.Dtos.Payments
{
    public class PaymentForDuesDto
    {
        public string UserId { get; set; }
        public int DuesId { get; set; }
        public CreditCard CreditCard { get; set; }
        public decimal Amount { get; set; }
    }
}
