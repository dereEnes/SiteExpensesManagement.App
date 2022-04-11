using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Domain.Entities
{
    public class Car:BaseEntity
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string LicencePlate { get; set; }
    }
}
