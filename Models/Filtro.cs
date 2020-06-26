using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smed.Models
{
    public class Filtro
    {
        public int Estado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
    }
}