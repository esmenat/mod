using SistemaTickets.Modelos; // Asegúrate de que esto esté presente para acceder a tu modelo
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaTickets.Services
{
    public class TicketFactory
    {
        private readonly List<TypePriceForUser> _typePriceForUsers;

        // Constructor que recibe los precios de los tipos de usuario
        public TicketFactory(List<TypePriceForUser> typePriceForUsers)
        {
            _typePriceForUsers = typePriceForUsers;
        }

        // Método para crear un ticket basado en el tipo de usuario
        public Ticket CreateTicket(string clientName, SistemaTickets.Modelos.Type type, List<string> seatNumbers) // Usamos el alias "SistemaTickets.Modelos.Type"
        {
            // Buscar el precio correspondiente al tipo de usuario
            var typePrice = _typePriceForUsers.FirstOrDefault(t => t.Type == type);

            if (typePrice == null)
                throw new ArgumentException("Tipo de usuario no válido");

            // Crear los asientos con el precio correspondiente según el tipo de usuario
            var seats = seatNumbers.Select(seatNumber => new Seat
            {
                Number = seatNumber,
                TypePriceForUserCodigo = typePrice.Codigo,  // Relación con TypePriceForUser
                TypePriceForUser = typePrice  // Relacionamos el asiento con el precio
            }).ToList();

            // Crear el ticket con los asientos asignados
            return new Ticket
            {
                ClientName = clientName,
                PurchasDate = DateTime.Now,
                AssignedDate = DateTime.Now.AddDays(2), // Ejemplo de asignación
                Seats = seats
            };
        }
    }
}
