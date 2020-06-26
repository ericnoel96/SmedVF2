using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smed.Models
{
    public class Consulta
    {
        public int ConsultaId { get; set; }
        public string Asunto { get; set; }
        public string Descripcion { get; set; }

        public int EspecialidadId { get; set; }
        public int PacienteId { get; set; }

        public virtual Especialidad Especialidad { get; set; }
        public virtual Paciente Paciente { get; set; }
    }
}