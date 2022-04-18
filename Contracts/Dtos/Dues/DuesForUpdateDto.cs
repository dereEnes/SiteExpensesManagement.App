using SiteExpensesManagement.App.Domain.Enums;
using System;

namespace SiteExpensesManagement.App.Contracts.Dtos.Dues
{
    public class DuesForUpdateDto
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ApartmentId { get; set; }
        public decimal Price { get; set; }
        public Months Month { get; set; }
        public short Year { get; set; }
        public bool IsPayed { get; set; }
    }
}
