using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.Domain.Entities;

namespace SiteExpensesManagement.App.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBillPaymentService _billPaymentService;
        private readonly IDuesPaymentService _duesPaymentService;

        public PaymentsController(IBillPaymentService billPaymentService, UserManager<ApplicationUser> userManager, IDuesPaymentService duesPaymentService)
        {
            _billPaymentService = billPaymentService;
            _userManager = userManager;
            _duesPaymentService = duesPaymentService;
        }

        [Authorize(Roles = "Basic")]
        public IActionResult UserBillPayments()
        {
            var result = _billPaymentService.GetUserPayments(_userManager.GetUserId(User));
            return View(result);
        }
        [Authorize(Roles = "Basic")]
        public IActionResult UserDuesPayments()
        {
            var result = _duesPaymentService.GetUserPayments(_userManager.GetUserId(User));
            return View(result);
        }
        
        
    }
}
