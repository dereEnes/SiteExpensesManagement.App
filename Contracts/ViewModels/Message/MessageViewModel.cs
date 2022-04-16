using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Contracts.ViewModels.Message
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        public bool HasRead { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public string SenderFirstName { get; set; }
        public string SenderLastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string SenderPhoneNumber { get; set; }
    }
}
