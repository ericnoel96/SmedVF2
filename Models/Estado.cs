using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smed.Models
{
    public class Estado
    {
        public int EstadoId { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Estado> Estados { get; set; }
    }
}