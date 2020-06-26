using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Smed.Models
{
    public class Paciente
    {
        public int PacienteId { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Genero { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime Fechanac { get; set; }
        public string lugarnac { get; set; }
        public string direccion { get; set; }
        public string alergias { get; set; }
        public string tiposangre { get; set; }

        public virtual ICollection<Consulta> Consultas { get; set; }
        public virtual ICollection<Covid> Covid { get; set; }
    }
}