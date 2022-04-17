using SiteExpensesManagement.App.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Domain.Entities
{
    public class Bill:BaseEntity
    {
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
        public BillTypes Category { get; set; }
        public decimal Price { get; set; }
        public Months Month { get; set; }
        public short Year { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsPayed { get; set; }
    }
}
