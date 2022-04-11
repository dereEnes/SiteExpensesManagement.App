using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Domain.Entities
{
    public class Car:BaseEntity
    {
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string LicencePlate { get; set; }
    }
}
