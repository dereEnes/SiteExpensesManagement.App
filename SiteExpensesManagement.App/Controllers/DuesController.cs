using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.Business.Validations.FluentValidation.DuesValidations;
using SiteExpensesManagement.App.Contracts.Dtos.DuesDtos;
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
        public IActionResult Index()
        {
            var result = _duesService.GetAll().Data;
            return View(result);
        }

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
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
