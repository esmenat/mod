using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaTickets.MVC.Controllers
{
    public class SeatsController : Controller
    {
        // GET: SeatsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SeatsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SeatsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SeatsController/Create
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

        // GET: SeatsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SeatsController/Edit/5
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

        // GET: SeatsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SeatsController/Delete/5
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
