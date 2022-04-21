using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.Business.Validations.FluentValidation;
using SiteExpensesManagement.App.Contracts.Dtos.Apartments;
using SiteExpensesManagement.App.Contracts.Dtos;
using SiteExpensesManagement.App.Contracts.Dtos.User;
using SiteExpensesManagement.App.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using UserIdentityManagement.Web.Enums;
using Microsoft.AspNetCore.Authorization;

namespace SiteExpensesManagement.App.Controllers
{
    [Authorize(Roles = "Admin")]
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
        
        public IActionResult Index()
        {
            return View(_apartmentService.GetAll().Data);
        }

        public IActionResult Details(int? id)
        {
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

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Users = GetUsers();
            ViewBag.RoomTypes = GetRoomTypes();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApartmentForCreateDto apartmentForCreateDto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Users = GetUsers();
                ViewBag.RoomTypes = GetRoomTypes();
                return View(apartmentForCreateDto);
            }
            var result = _apartmentService.Add(apartmentForCreateDto);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
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
        public IActionResult Edit(int id, ApartmentForUpdateDto apartmentForUpdateDto)
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
        public IActionResult Delete(int id)
        {
            var result = _apartmentService.GetById(id);
            if (result.Success)
            {
                return View(result.Data);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _apartmentService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
