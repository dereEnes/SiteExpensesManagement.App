using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteExpensesManagement.App.Contracts.Dtos.User;
using SiteExpensesManagement.App.DataAccess.EntityFramework.Repository.Abstracts;
using SiteExpensesManagement.App.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteExpensesManagement.App.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View( _userManager.Users
                .Where(x=> x.IsDeleted == false)
                .Include(x=> x.Apartment)
                .ToList());
        }
        public List<UserForSelectItem> getUsers()
        {
            return _userManager.Users.Select(u =>
                new UserForSelectItem
                {
                    Value = u.Id,
                    Text = $"{u.FirstName} {u.LastName}"
                }).ToList();
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
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

        public async Task<IActionResult> Edit(string id)
        {
            return View(await _userManager.FindByIdAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ApplicationUser user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            var result = await _userManager.FindByIdAsync(user.Id);
            result.FirstName = user.FirstName;
            result.LastName = user.LastName;
            result.PhoneNumber = user.PhoneNumber;
            result.Email = user.Email;
            await _userManager.UpdateAsync(result);
            Task.WaitAll();
            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (!(user is null))
            {
                user.IsDeleted = true;
                await _userManager.UpdateAsync(user);
                Task.WaitAll();
                _unitOfWork.Commit();
            }
            return RedirectToAction("Index");
        }

        
    }
}
