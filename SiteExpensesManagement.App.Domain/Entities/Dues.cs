using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Domain.Entities
{
    public class Dues:BaseEntity
    {
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
        public decimal Amount { get; set; }
        public DateTime DuesDate { get; set; }
        public bool IsPayed { get; set; }
    }
}
