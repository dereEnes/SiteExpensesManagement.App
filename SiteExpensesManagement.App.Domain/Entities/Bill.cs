using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Domain.Entities
{
    public class Bill:BaseEntity
    {
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
        public decimal Amount { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsPayed { get; set; }
    }
}
