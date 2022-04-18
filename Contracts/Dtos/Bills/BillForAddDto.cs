using SiteExpensesManagement.App.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Contracts.Dtos.Bills
{
    public class BillForAddDto
    {
        public Targets Target { get; set; }
        public int ApartmentNo { get; set; }
        public BillTypes Category { get; set; }
        public Blocks Block { get; set; }
        public decimal Price { get; set; }
        public Months Month { get; set; }
        public short Year { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
