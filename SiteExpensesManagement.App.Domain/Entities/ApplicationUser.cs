using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SiteExpensesManagement.App.Domain.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public ApplicationUser()
        {
            BillPayments = new List<BillPayment>();
            DuesPayments = new List<DuesPayment>();
            Messages = new List<Message>();
            Cars = new List<Car>();
        }
        public bool IsDeleted { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public List<Car> Cars { get; set; }
        public Apartment Apartment { get; set; }
        public List<Message> Messages { get; set; }
        public List<BillPayment> BillPayments { get; set; }
        public List<DuesPayment> DuesPayments { get; set; }
    }
}
