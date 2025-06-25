using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTickets.Modelos
{
    public enum TypeSeat
    {
        Normal = 1,
        VIP = 2
    }
    public class Seat
    {
        [Key] public int Codigo { get; set; }
        public TypeSeat Type { get; set; }
        public string Number { get; set; }
        public int TicketCodigo { get; set; }
        public int TypePriceForUserCodigo { get; set; }
        public Ticket? Ticket { get; set; }
        public TypePriceForUser? TypePriceForUser { get; set; }

    }
}
