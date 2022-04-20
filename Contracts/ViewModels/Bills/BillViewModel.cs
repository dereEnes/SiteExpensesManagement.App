using SiteExpensesManagement.App.Domain.Enums;
using SiteExpensesManagement.App.Domain.Entities;
using System;

namespace SiteExpensesManagement.App.Contracts.ViewModels.Bills
{
    public class BillViewModel
    {
        public int Id { get; set; }
        public Apartment Apartment { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Month { get; set; }
        public short Year { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsPayed { get; set; }
    }
}
