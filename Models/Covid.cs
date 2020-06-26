using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Smed.Models
{
    public class Covid
    {
        public int CovidId { get; set; }
        public int PacienteId { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }
        public string Observacion { get; set; }
        public string Medicamento { get; set; }
        public string Tratamiento { get; set; }
        public int EstadoId { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime FechaSalida { get; set; }
       


       





    public virtual Estado Estado { get; set; }
        public virtual Paciente Paciente { get; set; }

    }
}