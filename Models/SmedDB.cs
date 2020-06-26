using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Smed.Models
{
    public class SmedDB : DbContext
    {
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }

        public DbSet<Estado> Estados { get; set; }

        public DbSet<Covid> Covids { get; set; }
    }
}