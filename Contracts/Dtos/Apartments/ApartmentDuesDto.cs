using SiteExpensesManagement.App.Domain.Entities;
using SiteExpensesManagement.App.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Contracts.Dtos.Apartments
{
    public class ApartmentDuesDto
    {
        public ApartmentDuesDto()
        {
            Dues = new List<Dues>();
        }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Blocks Block { get; set; }
        public int ApartmentNo { get; set; }
        public List<Dues> Dues { get; set; }
    }
}
