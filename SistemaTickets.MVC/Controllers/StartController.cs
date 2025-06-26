using Microsoft.AspNetCore.Mvc;

namespace SistemaTickets.MVC.Controllers
{
    public class StartController : Controller
    {
        // GET: StartController
        public IActionResult Index()
        {
            return View();
        }
    }
}
