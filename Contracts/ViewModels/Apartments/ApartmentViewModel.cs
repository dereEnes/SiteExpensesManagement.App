using SiteExpensesManagement.App.Domain.Entities;
using System;

namespace SiteExpensesManagement.App.Contracts.ViewModels.Apartments
{
    public class ApartmentViewModel
    {
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public string UserId { get; set; }
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Block { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomType { get; set; }
        public byte FloorNumber { get; set; }
        public int ApartmentNo { get; set; }
    }
}
