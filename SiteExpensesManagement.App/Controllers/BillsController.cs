using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.Business.Validations.FluentValidation.BillValidations;
using SiteExpensesManagement.App.Contracts.Dtos.Bills;
using SiteExpensesManagement.App.Domain.Entities;

namespace SiteExpensesManagement.App.Controllers
{
    public class BillsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBillService _billService;
        private readonly IApartmentService _apartmentService;

        public BillsController(IBillService billService, UserManager<ApplicationUser> userManager, IApartmentService apartmentService)
        {
            _billService = billService;
            _userManager = userManager;
            _apartmentService = apartmentService;
        }

        public ActionResult Index()
        {
            return View(_billService.GetAll());
        }

        public ActionResult ApartmentBills()
        {
            string userId = _userManager.GetUserId(User);
            var apartment = _apartmentService.GetBillsByUserId(userId);
            return View(apartment);
        }

        // GET: BillsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BillsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BillForAddDto billForAddDto)
        {
            BillForAddDtoValidator categoryValidator = new BillForAddDtoValidator();
            ValidationResult validationResult = categoryValidator.Validate(billForAddDto);
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            var result = _billService.Add(billForAddDto);
            return RedirectToAction("Index");
        }

        // GET: BillsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BillsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BillsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BillsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
