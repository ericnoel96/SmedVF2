using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smed.Models
{
    public class Especialidad
    {
        public int EspecialidadID { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}