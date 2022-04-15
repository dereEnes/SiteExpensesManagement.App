using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Contracts.ViewModels.Car
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public string LicencePlate { get; set; }
    }
}
