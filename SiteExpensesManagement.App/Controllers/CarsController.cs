using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.Business.Validations.CarValidations;
using SiteExpensesManagement.App.Business.Validations.FluentValidation.CarValidations;
using SiteExpensesManagement.App.Contracts.Dtos.Car;
using SiteExpensesManagement.App.Contracts.Dtos.User;
using SiteExpensesManagement.App.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SiteExpensesManagement.App.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _carService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CarsController(ICarService carService, UserManager<ApplicationUser> userManager)
        {
            _carService = carService;
            _userManager = userManager;
        }

        // GET: CarsController
        public ActionResult Index()
        {
            var result = _carService.GetAll();
            return View(result.Data);
        }

        // GET: CarsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarForAddDto carForAddDto)
        {
            CarForAddDtoValidator categoryValidator = new CarForAddDtoValidator();
            ValidationResult validationResult = categoryValidator.Validate(carForAddDto);
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            var result = _carService.Add(carForAddDto);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            ViewBag.Users = getUsers();
            return View();
        }
        [NonAction]// Ortak kullanım için oluşturulmalı
        public List<UserForSelectItem> getUsers()
        {
            return _userManager.Users.Select(u =>
                new UserForSelectItem
                {
                    Value = u.Id,
                    Text = $"{u.FirstName} {u.LastName}"
                }).ToList();
        }
        // GET: CarsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_carService.GetById(id));
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CarForUpdateDto carForUpdateDto)
        {
            CarForUpdateDtoValidator categoryValidator = new CarForUpdateDtoValidator();
            ValidationResult validationResult = categoryValidator.Validate(carForUpdateDto);
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            var result = _carService.Update(carForUpdateDto);
            return RedirectToAction("Index");
        }

        // GET: CarsController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var result = _carService.GetById(id.Value);
            return View(result.Data);
        }

        // POST: CarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var result = _carService.Delete(id);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
