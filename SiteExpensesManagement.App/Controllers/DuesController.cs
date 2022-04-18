using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.Business.Validations.FluentValidation.DuesValidations;
using SiteExpensesManagement.App.Contracts.Dtos.Dues;
using SiteExpensesManagement.App.Domain.Entities;

namespace SiteExpensesManagement.App.Controllers
{
    public class DuesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDuesService _duesService;
        private readonly IApartmentService _apartmentService;

        public DuesController(IDuesService duesService, UserManager<ApplicationUser> userManager, IApartmentService apartmentService)
        {
            _duesService = duesService;
            _userManager = userManager;
            _apartmentService = apartmentService;
        }
        //[Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var result = _duesService.GetAll().Data;
            return View(result);
        }

        // GET: DuesController/Details/5
        public ActionResult ApartmentDues()
        {
            var user = _userManager.GetUserId(User);
            var result = _apartmentService.GetDuesByUserId(user);
            return View();

        }
        //[Authorize(Roles = "Admin")]
        // GET: DuesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DuesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DuesForAddDto duesForAddDto)
        {
            DuesForAddDtoValidator categoryValidator = new DuesForAddDtoValidator();
            ValidationResult validationResult = categoryValidator.Validate(duesForAddDto);
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            var result = _duesService.Add(duesForAddDto);
            return RedirectToAction("Index");
        }

        // GET: DuesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DuesController/Edit/5
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

        // GET: DuesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DuesController/Delete/5
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
