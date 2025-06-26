using Newtonsoft.Json;
using SistemaTickets.Modelos;

namespace SistemaTickets.MVC.Services
{
    public class AdminService
    {
        private readonly HttpClient _httpClient;

        public AdminService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Método para autenticar al admin
        public async Task<Admin> AuthenticateAdminAsync(string email, string password)
        {
            // Usar la URL de tu API local para autenticar al admin
            var response = await _httpClient.GetAsync($"https://localhost:7087/api/Admins?email={email}&password={password}");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var admin = JsonConvert.DeserializeObject<Admin>(jsonString);
                return admin;
            }

            return null;
        }
    }
}
