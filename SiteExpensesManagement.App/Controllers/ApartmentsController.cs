using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.Business.Validations.FluentValidation;
using SiteExpensesManagement.App.Contracts.Dtos.Apartment;
using SiteExpensesManagement.App.Contracts.Dtos;
using SiteExpensesManagement.App.Contracts.Dtos.User;
using SiteExpensesManagement.App.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SiteExpensesManagement.App.Controllers
{
    public class ApartmentsController : Controller
    {
        private readonly IApartmentService _apartmentService;
        private readonly IRoomTypeService _roomTypeService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApartmentsController(IApartmentService apartmentService, UserManager<ApplicationUser> userManager, IRoomTypeService roomTypeService)
        {
            _apartmentService = apartmentService;
            _userManager = userManager;
            _roomTypeService = roomTypeService;
        }

        public ActionResult Index()
        {

            return View(_apartmentService.GetAll().Data);
        }

        public ActionResult Details(int? id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Users = GetUsers();
            ViewBag.RoomTypes = GetRoomTypes();
            return View();
        }
        [NonAction]
        public List<RoomTypeForSelectItem> GetRoomTypes()
        {
            return _roomTypeService.GetAll().Data.Select(x => new RoomTypeForSelectItem
            {
                Value = x.Id,
                Text = x.CountOfRooms
            }).ToList();
        }
        [NonAction]
        public List<UserForSelectItem> GetUsers()
        {
            return _userManager.Users.Select(u =>
                new UserForSelectItem
                {
                    Value = u.Id,
                    Text = $"{u.FirstName} {u.LastName}"
                }).ToList();
        }
        
        [HttpPost]
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

        public ActionResult Edit(int id)
        {
            var result = _apartmentService.GetById(id);
            if (result.Success)
            {
                ViewBag.Users = GetUsers();
                ViewBag.RoomTypes = GetRoomTypes();
                return View(result.Data);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ApartmentForUpdateDto apartmentForUpdateDto)
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
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var result = _apartmentService.GetById(id);
            if (result.Success)
            {
                return View(result.Data);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            _apartmentService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
