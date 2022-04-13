using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.Business.Validations.FluentValidation;
using SiteExpensesManagement.App.Contracts.Dtos.Apartment;
using SiteExpensesManagement.App.Contracts.Dtos.User;
using SiteExpensesManagement.App.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SiteExpensesManagement.App.Controllers
{
    public class ApartmentsController : Controller
    {
        private readonly IApartmentService _apartmentService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApartmentsController(IApartmentService apartmentService, UserManager<ApplicationUser> userManager)
        {
            _apartmentService = apartmentService;
            _userManager = userManager;
        }

        // GET: ApartmentsController
        public ActionResult Index()
        {

            return View(_apartmentService.GetAll().Data);
        }

        // GET: ApartmentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApartmentsController/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Users = getUsers();
            return View();
        }
        public List<UserForSelectItem> getUsers()
        {
            return _userManager.Users.Select(u =>
                new UserForSelectItem
                {
                    Value = u.Id,
                    Text = $"{u.FirstName} {u.LastName}"
                }).ToList();
        }
        // POST: ApartmentsController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(ApartmentForCreateDto apartmentForCreateDto)
        {
            ApartmentValidator categoryValidator = new ApartmentValidator();
            ValidationResult validationResult = categoryValidator.Validate(apartmentForCreateDto);
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            var result = _apartmentService.Add(apartmentForCreateDto);
            return RedirectToAction("Index");
        }

        // GET: ApartmentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApartmentsController/Edit/5
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

        // GET: ApartmentsController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = _apartmentService.Delete(id);
            return View();
        }

        // POST: ApartmentsController/Delete/5
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
