using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTickets.Modelos
{
    public class Ticket
    {
        [Key] public int Codigo { get; set; }
        public string ClientName { get; set; }
        public DateTime PurchasDate { get; set; }
        public DateTime AssignedDate { get; set; }
        public int ReservationCodigo { get; set; }
        public int RouteCodigo { get; set; }
        public Route? Route { get; set; }
        public Reservation? Reservation { get; set; }
        public List<Seat>? Seats { get; set; }
    }
}
