using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.Business.Validations.FluentValidation.MessageValidations;
using SiteExpensesManagement.App.Contracts.Dtos.Message;
using SiteExpensesManagement.App.Domain.Entities;

namespace SiteExpensesManagement.App.Controllers
{
    public class MessagesController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<ApplicationUser> UserManager;

        public MessagesController(IMessageService messageService, UserManager<ApplicationUser> userManager)
        {
            _messageService = messageService;
            UserManager = userManager;
        }

       // [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: MessagesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

       // [Authorize(Roles = "Basic")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MessageForAddDto messageForAddDto)
        {
            messageForAddDto.SenderId = UserManager.GetUserId(User);
            MessageForAddDtoValidator validator = new MessageForAddDtoValidator();
            var validationResult = validator.Validate(messageForAddDto);
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
             _messageService.Add(messageForAddDto);
            return View();
        }

        // GET: MessagesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MessagesController/Edit/5
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

        // GET: MessagesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MessagesController/Delete/5
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
