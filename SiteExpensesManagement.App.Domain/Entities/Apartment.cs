using SiteExpensesManagement.App.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Domain.Entities
{
    public class Apartment:BaseEntity
    {
        public Apartment()
        {
            Dues = new List<Dues>();
            Bills = new List<Bill>();
        }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Blocks Block { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public int ApartmentNo { get; set; }
        public byte FloorNumber { get; set; }
        public bool IsEmpty { get; set; }
        public List<Dues> Dues { get; set; } 
        public List<Bill> Bills { get; set; }
    } 
}
