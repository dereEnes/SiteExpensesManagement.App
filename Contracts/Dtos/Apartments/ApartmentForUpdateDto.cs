using SiteExpensesManagement.App.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Contracts.Dtos.Apartments
{
    public class ApartmentForUpdateDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Blocks Block { get; set; }
        public int RoomTypeId { get; set; }
        public byte FloorNumber { get; set; }
        public int ApartmentNo { get; set; }
        public bool IsEmpty { get; set; }
    }
}
