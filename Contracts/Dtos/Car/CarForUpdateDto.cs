using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Contracts.Dtos.Car
{
    public class CarForUpdateDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string LicencePlate { get; set; }
    }
}
