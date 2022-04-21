using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Domain.Entities
{
    public class DuesPayment:BaseEntity
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int DuesId { get; set; }
        public Dues Dues { get; set; }
    }
}
