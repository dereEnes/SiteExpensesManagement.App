using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.Contracts.ViewModels
{
    public class RoomTypeViewModel
    {
        public int Id { get; set; }
        public string CountOfRooms { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
