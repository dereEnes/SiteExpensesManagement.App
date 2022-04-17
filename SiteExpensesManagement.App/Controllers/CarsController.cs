using FluentValidation.Results;
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
        public ActionResult Create(CarForAddDto carForAddDto)
        {
            CarForAddDtoValidator carValidator = new CarForAddDtoValidator();
            ValidationResult validationResult = carValidator.Validate(carForAddDto);
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            var result = _carService.Add(carForAddDto);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("",result.Message);
            ViewBag.Users = GetUsers();
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Users = GetUsers();
            return View();
        }
        [NonAction]// Ortak kullanım için oluşturulmalı
        public List<UserForSelectItem> GetUsers()
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
            var result = _carService.GetById(id);
            if (result.Success)
            {
                return View(result.Data);
            }
            return NotFound();
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarForUpdateDto carForUpdateDto)
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
