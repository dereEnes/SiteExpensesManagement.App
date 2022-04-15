using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Contracts.Dtos.Message
{
    public class MessageForAddDto
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public string SenderId { get; set; }
    }
}
