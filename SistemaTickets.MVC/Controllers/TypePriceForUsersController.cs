using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaTickets.MVC.Controllers
{
    public class TypePriceForUsersController : Controller
    {
        // GET: TypePriceForUsersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TypePriceForUsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TypePriceForUsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypePriceForUsersController/Create
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

        // GET: TypePriceForUsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TypePriceForUsersController/Edit/5
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

        // GET: TypePriceForUsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TypePriceForUsersController/Delete/5
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
