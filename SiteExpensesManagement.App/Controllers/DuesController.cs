using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.Business.Validations.FluentValidation.DuesValidations;
using SiteExpensesManagement.App.Contracts.Dtos.DuesDtos;
using SiteExpensesManagement.App.Contracts.Dtos.Payments;
using SiteExpensesManagement.App.Domain.Entities;
using System.Threading.Tasks;

namespace SiteExpensesManagement.App.Controllers
{
    public class DuesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDuesService _duesService;
        private readonly IApartmentService _apartmentService;
        private readonly IPaymentService _paymentService;

        public DuesController(
            IDuesService duesService,
            UserManager<ApplicationUser> userManager,
            IApartmentService apartmentService,
            IPaymentService paymentService)
        {
            _duesService = duesService;
            _userManager = userManager;
            _apartmentService = apartmentService;
            _paymentService = paymentService;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var result = _duesService.GetAll().Data;
            return View(result);
        }
        [Authorize(Roles ="Basic")]
        public IActionResult ApartmentDues()
        {
            var user = _userManager.GetUserId(User);
            var result = _apartmentService.GetDuesByUserId(user);
            return View(result);

        }
        //[Authorize(Roles = "Admin")]
        // GET: DuesController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DuesForAddDto duesForAddDto)
        {
            if (!ModelState.IsValid)
            {
                return View(duesForAddDto);
            }
            var result = _duesService.Add(duesForAddDto);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Basic")]
        [HttpGet]
        public IActionResult Pay(int id)
        {
            ViewBag.Card = GetUserCards().Result;
            ViewBag.Dues = _duesService.GetById(id).Data;
            return View();
        }
        private async Task<CreditCard> GetUserCards()
        {
            return await _paymentService.GetUserCard(_userManager.GetUserId(User));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Pay([FromForm] PaymentForDuesDto paymentForDuesDto)
        {
            if (!ModelState.IsValid && !paymentForDuesDto.UseSavedCard)
            {
                ViewBag.Card = GetUserCards().Result;
                ViewBag.Dues = _duesService.GetById(paymentForDuesDto.DuesId);
                return View(paymentForDuesDto);
            }
            var card = GetUserCards().Result;
            paymentForDuesDto.CreditCard.CardNumber = card.CardNumber;
            paymentForDuesDto.CreditCard.Cvv = card.Cvv;
            paymentForDuesDto.CreditCard.ExpiryMonth = card.ExpiryMonth;
            paymentForDuesDto.CreditCard.ExpiryYear = card.ExpiryYear;
            paymentForDuesDto.CreditCard.NameOnCard = card.NameOnCard;
            paymentForDuesDto.UserId = _userManager.GetUserId(User);

            var result = await _paymentService.Add(paymentForDuesDto);
            
            return RedirectToAction("ApartmentDues");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult PaidDues()
        {
            var result = _duesService.Get(x => x.IsPayed == true);
            return View(result);
        }
    }
}
