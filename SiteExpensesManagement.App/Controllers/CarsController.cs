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

        public ActionResult Index()
        {
            var result = _carService.GetAll();
            return View(result.Data);
        }

        public IActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CarForAddDto carForAddDto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Users = GetUsers();
                return View(carForAddDto);
            }
            var result = _carService.Add(carForAddDto);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
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
        
        public IActionResult Edit(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
            {
                return View(result.Data);
            }
            return NotFound();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CarForUpdateDto carForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return View(carForUpdateDto);
            }
            var result = _carService.Update(carForUpdateDto);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var result = _carService.GetById(id.Value);
            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
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
