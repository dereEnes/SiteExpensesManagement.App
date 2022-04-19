using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Domain.Entities
{
    public class CreditCard
    {
        public string _Id { get; set; }
        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public byte ExpiryMonth { get; set; }
        public short ExpiryYear { get; set; }
        public short Cvv { get; set; }
    }
}
