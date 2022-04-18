using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SiteExpensesManagement.App.Controllers
{
    public class DuesController : Controller
    {
        // GET: DuesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DuesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DuesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DuesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: DuesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DuesController/Edit/5
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

        // GET: DuesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DuesController/Delete/5
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
