namespace SistemaTickets.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Agregar el servicio HttpClient
            builder.Services.AddHttpClient();

            // Agregar almacenamiento en memoria para las sesiones
            builder.Services.AddDistributedMemoryCache();

            // Configuraci�n de sesi�n (Tiempo de expiraci�n, 10 minutos)
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=Start}/{action=Index}/{id?}"); 
            app.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=Home}/{action=Index}/{id?}"); 
            // Ruta para RoutesController
            app.MapControllerRoute(
                name: "routes",
                pattern: "Routes/{action=ViewRoute}/{id?}",
                defaults: new { controller = "Routes" });
            // Ruta para SeatsController (a�adida)
            app.MapControllerRoute(
                name: "seats",
                pattern: "Seats/{action=ViewSeats}/{id?}",
                defaults: new { controller = "Seats" });
            // Aseg�rate de agregar la ruta espec�fica para el controlador de reservas si es necesario
            app.MapControllerRoute(
                name: "reservations",
                pattern: "Reservations/{action=Create}/{id?}", // Ruta para la acci�n 'Create' de 'ReservationsController'
                defaults: new { controller = "Reservations" }
            );


            app.Run();
        }
    }
}
