using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Domain.Entities
{
    public class Message:BaseEntity
    {
        public bool hasRead { get; set; }
        public string SenderId { get; set; }
        public ApplicationUser Sender { get; set; }
    }
}
