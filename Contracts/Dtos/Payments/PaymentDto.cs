using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Contracts.Dtos.Payments
{
    public class PaymentDto
    {
        public CreditCard CreditCardInfo { get; set; }
        public decimal Price { get; set; }
    }
}
