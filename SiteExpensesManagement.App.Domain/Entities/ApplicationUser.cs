using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SiteExpensesManagement.App.Domain.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TcNo { get; set; }
        public List<Car> Cars { get; set; }
    }
}
