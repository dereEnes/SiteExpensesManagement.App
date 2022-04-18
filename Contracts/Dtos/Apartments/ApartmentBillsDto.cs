using SiteExpensesManagement.App.Domain.Entities;
using SiteExpensesManagement.App.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Contracts.Dtos.Apartments
{
    public class ApartmentBillsDto
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Blocks Block { get; set; }
        public int ApartmentNo { get; set; }
        public bool IsEmpty { get; set; }
        public List<Bill> Bills { get; set; } = new List<Bill>();
    }
}
