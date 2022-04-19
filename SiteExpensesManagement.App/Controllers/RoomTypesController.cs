using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.Business.Validations.FluentValidation.RoomTypeValidations;
using SiteExpensesManagement.App.Contracts.Dtos;

namespace SiteExpensesManagement.App.Controllers
{
    public class RoomTypesController : Controller
    {
        private readonly IRoomTypeService _roomTypeService;

        public RoomTypesController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        public IActionResult Index()
        {
            return View(_roomTypeService.GetAll().Data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RoomTypeForAddDto roomTypeForAddDto)
        {
            if (!ModelState.IsValid)
            {
                return View(roomTypeForAddDto);
            }
            var result = _roomTypeService.Add(roomTypeForAddDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var result = _roomTypeService.GetById(id.Value);
            return View(result.Data);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _roomTypeService.Delete(id);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
