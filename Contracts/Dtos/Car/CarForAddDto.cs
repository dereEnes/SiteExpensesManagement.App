using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Contracts.Dtos.Car
{
    public class CarForAddDto
    {
        public string UserId { get; set; }
        public string LicencePlate { get; set; }
    }
}
