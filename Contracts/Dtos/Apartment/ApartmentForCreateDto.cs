using SiteExpensesManagement.App.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Contracts.Dtos.Apartment
{
    public class ApartmentForCreateDto
    {
        public string UserId { get; set; }
        public Blocks Block { get; set; }
        public int RoomTypeId { get; set; }
        public int ApartmentNo { get; set; }
        public byte FloorNumber { get; set; }
        public bool IsEmpty { get; set; }

    }
    
    public class ApartmentDto
    {
        //public string UserId { get; set; }
        //public ApplicationUser User { get; set; }
        //public Blocks Block { get; set; }
        //public int RoomTypeId { get; set; }
        //public Rooms RoomType { get; set; }
        //public int ApartmenNo { get; set; }
        //public byte FloorNumber { get; set; }
        //public bool IsEmpty { get; set; }
        //public List<Dues> Dues { get; set; } = new List<Dues>();
        //public List<Bill> Bills { get; set; } = new List<Bill>();
    }

}
