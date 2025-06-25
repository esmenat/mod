using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTickets.Modelos
{
    public enum Type
    {
        Niño = 1,
        Adulto = 2,
        TerceraEdad = 3
    }

    public class TypePriceForUser
    {
        [Key] public int Codigo { get; set; }
        public Type Type { get; set; }
        public double Price { get; set; }
        public List<Seat>? Seats { get; set; }
        

    }
}
