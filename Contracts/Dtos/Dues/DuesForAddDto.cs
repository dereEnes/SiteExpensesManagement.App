using SiteExpensesManagement.App.Domain.Enums;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Contracts.Dtos.Dues
{
    public class DuesForAddDto
    {
        public Blocks Block { get; set; }
        public int ApartmentNo { get; set; }
        public decimal Price { get; set; }
        public Months Month { get; set; }
        public short Year { get; set; }
        public Targets Target { get; set; }
    }
}
