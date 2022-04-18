using SiteExpensesManagement.App.Domain.Entities;
using System;

namespace SiteExpensesManagement.App.Contracts.ViewModels.Apartments
{
    public class ApartmentViewModel
    {
        public ApplicationUser User { get; set; }
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Block { get; set; }
        public RoomType RoomType { get; set; }
        public byte FloorNumber { get; set; }
        public int ApartmentNo { get; set; }
    }
}
