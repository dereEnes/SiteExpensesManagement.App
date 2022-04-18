using SiteExpensesManagement.App.Domain.Enums;
using System;


namespace SiteExpensesManagement.App.Contracts.Dtos.Bills
{
    public class BillForUpdateDto
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ApartmentId { get; set; }
        public BillTypes Category { get; set; }
        public decimal Price { get; set; }
        public Months Month { get; set; }
        public short Year { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsPayed { get; set; }
    }
}
