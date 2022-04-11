using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Domain.Entities
{
    public class Block:BaseEntity
    {
        public string BlokName { get; set; }
        public List<Apartment> Apartments { get; set; } = new List<Apartment>();
    }
}
