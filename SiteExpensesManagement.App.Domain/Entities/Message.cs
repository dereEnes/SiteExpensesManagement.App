using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Domain.Entities
{
    public class Message:BaseEntity
    {
        public bool HasRead { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public string SenderId { get; set; }
        public ApplicationUser Sender { get; set; }
    }
}
