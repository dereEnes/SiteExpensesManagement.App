using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Domain.Entities
{
    public class BillPayment:BaseEntity
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int BillId { get; set; }
        public Bill Bill { get; set; }
    }
}
