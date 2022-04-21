using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.Business.Validations.FluentValidation.BillValidations;
using SiteExpensesManagement.App.Contracts.Dtos.Bills;
using SiteExpensesManagement.App.Contracts.Dtos.Payments;
using SiteExpensesManagement.App.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteExpensesManagement.App.Controllers
{
    public class BillsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBillService _billService;
        private readonly IApartmentService _apartmentService;
        private readonly IPaymentService _paymentService;

        public BillsController(IBillService billService,
            UserManager<ApplicationUser> userManager,
            IApartmentService apartmentService,
            IPaymentService paymentService)
        {
            _billService = billService;
            _userManager = userManager;
            _apartmentService = apartmentService;
            _paymentService = paymentService;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(_billService.GetAll());
        }
        [Authorize(Roles = "Basic")]
        public IActionResult ApartmentBills()
        {
            string userId = _userManager.GetUserId(User);
            var apartment = _apartmentService.GetBillsByUserId(userId);
            return View(apartment);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BillForAddDto billForAddDto)
        {
            if (!ModelState.IsValid)
            {
                return View(billForAddDto);
            }
            var result = _billService.Add(billForAddDto);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Basic, Admin")]
        [HttpGet]
        public IActionResult Pay(int id)
        {
            //ViewBag.Card = GetUserCards().Result;
            ViewBag.Bill = _billService.GetById(id);
            return View();
        }
        private async Task<CreditCard> GetUserCards()
        {
            return await _paymentService.GetUserCard(_userManager.GetUserId(User));
        }
        [Authorize(Roles = "Basic, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Pay([FromForm]PaymentForBillDto paymentForAddDto)
        {
            if (!ModelState.IsValid)
            {
              //  ViewBag.Card = GetUserCards().Result;
                ViewBag.Bill = _billService.GetById(paymentForAddDto.BillId);
                return View(paymentForAddDto);
            }
            paymentForAddDto.UserId = _userManager.GetUserId(User);
            var result = await _paymentService.Add(paymentForAddDto);
            return RedirectToAction("ApartmentBills");
        }
        public IActionResult PaidBills()
        {
            var result = _billService.Get(x => x.IsPayed == true);
            return View(result);
        }
    }
}
