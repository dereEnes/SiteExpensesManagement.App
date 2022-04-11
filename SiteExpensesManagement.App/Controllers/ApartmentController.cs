using Microsoft.AspNetCore.Mvc;
using SiteExpensesManagement.App.Business.Abstracts;

namespace SiteExpensesManagement.App.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly IApartmentService apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            this.apartmentService = apartmentService;
        }

        public IActionResult Index()
        {
            var result = apartmentService.GetAll();
            return View(result);
        }
    }
}
