using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Domain.Entities
{
    public class Apartment:BaseEntity
    {
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int BlockId { get; set; }
        public Block Block { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public int ApartmenNo { get; set; }
        public byte FloorNumber { get; set; }
        public bool IsEmpty { get; set; } 
    }
}
