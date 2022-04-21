using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.Contracts.Dtos.Message;
using SiteExpensesManagement.App.Domain.Entities;

namespace SiteExpensesManagement.App.Controllers
{
    public class MessagesController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<ApplicationUser> _userManager;

        public MessagesController(IMessageService messageService, UserManager<ApplicationUser> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(_messageService.GetAll().Data);
        }

        // MessagesController/ForwardedMessages -> returns User' Messages
        [Authorize(Roles = "Basic")]
        public IActionResult ForwardedMessages()
        {
            var result = _messageService.GetUsersMessage(_userManager.GetUserId(User));
            return View(result.Data);
        }

        public IActionResult Details(int id)
        {
            var result = _messageService.GetById(id);
            return View(result.Data);
        }
        public IActionResult DetailsForSender(int id)
        {
            var result = _messageService.GetByIdForSender(id);
            return View(result.Data);
        }

        [Authorize(Roles = "Basic")]
        public IActionResult Create()
        {
            return View();
        }
         [Authorize(Roles = "Basic")]
        [HttpPost]
        public IActionResult Create(MessageForAddDto messageForAddDto)
        {
            messageForAddDto.SenderId = _userManager.GetUserId(User);
            
            if (!ModelState.IsValid)
            {
                return View(messageForAddDto);
            }
             _messageService.Add(messageForAddDto);
            return RedirectToAction("ForwardedMessages");
        }

        public IActionResult Delete(int id)
        {
            _messageService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
