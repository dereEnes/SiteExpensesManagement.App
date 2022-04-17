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
            return View(_messageService.GetAll().Data);
        }

        // Get : MessagesController/ForwardedMessages -> returns User' Messages
        // [Authorize(Roles = "Basic")]
        public ActionResult ForwardedMessages()
        {
            var result = _messageService.GetUsersMessage(UserManager.GetUserId(User));
            return View(result.Data);
        }

        // GET: MessagesController/Details/5
        public ActionResult Details(int id)
        {
            var result = _messageService.GetById(id);
            return View(result.Data);
        }
        public ActionResult DetailsForSender(int id)
        {
            var result = _messageService.GetByIdForSender(id);
            return View(result.Data);
        }

       // [Authorize(Roles = "Basic")]
        public ActionResult Create()
        {
            return View();
        }
        // [Authorize(Roles = "Basic")]
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
            return RedirectToAction("ForwardedMessages");
        }

        // GET: MessagesController/Delete/5
        public ActionResult Delete(int id)
        {
            _messageService.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: MessagesController/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
