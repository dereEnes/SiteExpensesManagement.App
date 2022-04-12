using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Domain.Entities
{
    public class RoomType:BaseEntity
    {
        public string CountOfRooms { get; set; }
        public List<Apartment> Apartments { get; set; } = new List<Apartment>();
    }
}
