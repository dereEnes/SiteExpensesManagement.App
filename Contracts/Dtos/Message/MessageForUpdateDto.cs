using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Contracts.Dtos.Message
{
    public class MessageForUpdateDto
    {
        public int Id { get; set; }
        public bool HasRead { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public string SenderId { get; set; }
    }
}
