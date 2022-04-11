using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Domain
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
