using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemaTickets.Modelos;

namespace SistemaTickets.MVC.Controllers
{
    public class ClientsController : Controller
    {
        private readonly HttpClient _httpClient;

        // Inyección de HttpClient
        public ClientsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: ClientsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ClientsController/Login
        public ActionResult Login()
        {
            return View("LoginClient");
        }

        // POST: ClientsController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(string email, string password)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                var loginRequest = new LoginRequest
                {
                    Email = email,
                    Password = password
                };

                var content = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:7087/api/Clients/authenticate", content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var client = JsonConvert.DeserializeObject<Client>(jsonString);
                    HttpContext.Session.SetString("ClientEmail", client.Email);
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View("LoginClient");
        }

        // GET: ClientsController/Logout
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }

        // GET: ClientsController/Register
        public ActionResult Register()
        {
            return View("RegisterClient");
        }

        // POST: ClientsController/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(string name, string email, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Passwords do not match.");
                return View("RegisterClient");
            }
            var registerRequest = new RegisterRequest
            {
                Name = name,
                Email = email,
                Password = password
            };
            var content = new StringContent(JsonConvert.SerializeObject(registerRequest), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7087/api/Clients/register", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Login), "Clients");
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError(string.Empty, errorContent);
            return View("RegisterClient");
        }




        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

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

        public ActionResult Edit(int id)
        {
            return View();
        }

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

        public ActionResult Delete(int id)
        {
            return View();
        }

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
