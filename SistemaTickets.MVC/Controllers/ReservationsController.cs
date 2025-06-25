using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaTickets.Modelos;

namespace SistemaTickets.MVC.Controllers
{
    public class ReservationsController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();  // Esto devolverá la vista Create.cshtml
        }

        // Acción para manejar la lógica de creación de reserva
        [HttpPost]
        public IActionResult Create(Reservation reservation)
        {
            // Lógica para guardar la reserva y el ticket en la base de datos
            // ...

            return RedirectToAction("Index"); // Redirigir a la lista de reservas después de la creación
        }

        // POST: ReservationsController/Create
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

        // GET: ReservationsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservationsController/Edit/5
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

        // GET: ReservationsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservationsController/Delete/5
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
