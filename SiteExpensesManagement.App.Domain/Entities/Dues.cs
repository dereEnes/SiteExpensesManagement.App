using SiteExpensesManagement.App.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Domain.Entities
{
    public class Dues:BaseEntity
    {
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
        public decimal Price { get; set; }
        public Months Month { get; set; }
        public short Year { get; set; }
        public bool IsPayed { get; set; }
        public DuesPayment DuesPayment { get; set; }
    }
}
