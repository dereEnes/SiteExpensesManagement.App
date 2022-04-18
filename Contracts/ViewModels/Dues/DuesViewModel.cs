using SiteExpensesManagement.App.Domain.Entities;

namespace SiteExpensesManagement.App.Contracts.ViewModels.Dues
{
    public class DuesViewModel
    {
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
        public decimal Price { get; set; }
        public string Month { get; set; }
        public short Year { get; set; }
        public bool IsPayed { get; set; }
    }
}
