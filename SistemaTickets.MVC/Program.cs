namespace SistemaTickets.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            // Ruta para RoutesController
            app.MapControllerRoute(
                name: "routes",
                pattern: "Routes/{action=ViewRoute}/{id?}",
                defaults: new { controller = "Routes" });
            // Ruta para SeatsController (añadida)
            app.MapControllerRoute(
                name: "seats",
                pattern: "Seats/{action=ViewSeats}/{id?}",
                defaults: new { controller = "Seats" });
            // Asegúrate de agregar la ruta específica para el controlador de reservas si es necesario
            app.MapControllerRoute(
                name: "reservations",
                pattern: "Reservations/{action=Create}/{id?}", // Ruta para la acción 'Create' de 'ReservationsController'
                defaults: new { controller = "Reservations" }
            );


            app.Run();
        }
    }
}
