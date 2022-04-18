using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Contracts.Dtos.Apartments
{
    public class ApartmentForUpdateDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Block { get; set; }
        public int RoomTypeId { get; set; }
        public byte FloorNumber { get; set; }
        public int ApartmentNo { get; set; }
    }
}
