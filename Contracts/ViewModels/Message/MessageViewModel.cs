using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Contracts.ViewModels.Message
{
    public class MessageViewModel
    {
        public bool HasRead { get; set; }
        public string SenderFirstName { get; set; }
        public string SenderLastName { get; set; }
        public DateTime CreateDate { get; set; }
        public string SenderPhoneNumber { get; set; }
    }
}
