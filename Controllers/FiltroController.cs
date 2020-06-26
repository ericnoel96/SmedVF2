using Microsoft.SqlServer.Server;
using Smed.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smed.Controllers
{
    public class FiltroController : Controller
    {
        private SmedDB db = new SmedDB();
        // GET: Filtro
        public ActionResult Index(int Estado = 0, int FechaIngreso = 0, int FechaSalida = 0, int Cedula = 0, int Medicacion = 0, int Observacion = 0, int Tratamiento = 0, int Dias = 0)
        {
            var listaEstados = db.Estados.ToList();
            var listaPacientesCovid = db.Pacientes.ToList();
            var listaCovid = db.Covids.ToList();
            ViewBag.Estado = new SelectList(listaEstados, "EstadoId", "Tipo");
            ViewBag.Cedula = new SelectList(listaPacientesCovid, "PacienteId", "Cedula");
            ViewBag.FechaIngreso = new SelectList(listaCovid, "CovidId", "FechaIngreso");
            ViewBag.FechaSalida = new SelectList(listaCovid, "CovidId", "FechaSalida");
            ViewBag.Medicacion = new SelectList(listaCovid, "CovidId", "Medicamento");
            ViewBag.Observacion = new SelectList(listaCovid, "CovidId", "Observacion");
            ViewBag.Tratamiento = new SelectList(listaCovid, "CovidId", "Tratamiento");
            List<Covid> covids = new List<Covid>();
            if (Cedula != 0)
            {
                foreach (var c in listaCovid)
                {
                    if (c.PacienteId == Cedula)
                    {

                        Covid covid = new Covid();
                        covid.CovidId = c.CovidId;
                        covid.PacienteId = c.PacienteId;
                        covid.FechaIngreso = c.FechaIngreso;
                        covid.Paciente = c.Paciente;
                        covid.Estado = c.Estado;
                        covid.FechaSalida = c.FechaSalida;
                        covid.Observacion = c.Observacion;
                        covid.Tratamiento = c.Tratamiento;
                        covid.EstadoId = c.EstadoId;
                        covids.Add(covid);

                    }
                }
            }
            if (Dias != 0)
            {
                foreach (var c in listaCovid)
                {
                    TimeSpan dia = c.FechaSalida - c.FechaIngreso;
                    if (dia.TotalDays <= Dias)
                    {
                        Covid covid = new Covid();
                        covid.CovidId = c.CovidId;
                        covid.PacienteId = c.PacienteId;
                        covid.FechaIngreso = c.FechaIngreso;
                        covid.Paciente = c.Paciente;
                        covid.Estado = c.Estado;
                        covid.FechaSalida = c.FechaSalida;
                        covid.Observacion = c.Observacion;
                        covid.Tratamiento = c.Tratamiento;
                        covid.EstadoId = c.EstadoId;
                        covids.Add(covid);
                    }
                }
            }
            if (Estado != 0)
            {
                foreach (var c in listaCovid)
                {

                    if (c.EstadoId == Estado)
                    {
                        Covid covid = new Covid();
                        covid.CovidId = c.CovidId;
                        covid.PacienteId = c.PacienteId;
                        covid.FechaIngreso = c.FechaIngreso;
                        covid.Paciente = c.Paciente;
                        covid.Estado = c.Estado;
                        covid.FechaSalida = c.FechaSalida;
                        covid.Observacion = c.Observacion;
                        covid.Tratamiento = c.Tratamiento;
                        covid.EstadoId = c.EstadoId;
                        covids.Add(covid);
                    }
                }

            }
            if (Medicacion != 0)
            {
                Covid co = new Covid();
                foreach (var c in listaCovid)
                {
                    if (c.CovidId == Medicacion)
                    {
                        co.CovidId = c.CovidId;
                        co.PacienteId = c.PacienteId;
                        co.FechaIngreso = c.FechaIngreso;
                        co.Paciente = c.Paciente;
                        co.Estado = c.Estado;
                        co.FechaSalida = c.FechaSalida;
                        co.Observacion = c.Observacion;
                        co.Medicamento = c.Medicamento;
                        co.Tratamiento = c.Tratamiento;
                        co.EstadoId = c.EstadoId;
                    }
                }
                foreach (var c in listaCovid)
                {
                    if (c.Medicamento == co.Medicamento)
                    {
                        Covid covid = new Covid();
                        covid.CovidId = c.CovidId;
                        covid.PacienteId = c.PacienteId;
                        covid.FechaIngreso = c.FechaIngreso;
                        covid.Paciente = c.Paciente;
                        covid.Estado = c.Estado;
                        covid.FechaSalida = c.FechaSalida;
                        covid.Medicamento = c.Medicamento;
                        covid.Observacion = c.Observacion;
                        covid.Tratamiento = c.Tratamiento;
                        covid.EstadoId = c.EstadoId;
                        covids.Add(covid);
                    }
                }
            }
            if (FechaIngreso != 0)
            {
                Covid co = new Covid();
                foreach (var c in listaCovid)
                {
                    if (c.CovidId == FechaIngreso)
                    {
                        co.CovidId = c.CovidId;
                        co.PacienteId = c.PacienteId;
                        co.FechaIngreso = c.FechaIngreso;
                        co.Paciente = c.Paciente;
                        co.Estado = c.Estado;
                        co.FechaSalida = c.FechaSalida;
                        co.Observacion = c.Observacion;
                        co.Tratamiento = c.Tratamiento;
                        co.EstadoId = c.EstadoId;
                    }
                }
                foreach (var c in listaCovid)
                {
                    if (c.FechaIngreso == co.FechaIngreso)
                    {
                        Covid covid = new Covid();
                        covid.CovidId = c.CovidId;
                        covid.PacienteId = c.PacienteId;
                        covid.FechaIngreso = c.FechaIngreso;
                        covid.Paciente = c.Paciente;
                        covid.Estado = c.Estado;
                        covid.FechaSalida = c.FechaSalida;
                        covid.Observacion = c.Observacion;
                        covid.Tratamiento = c.Tratamiento;
                        covid.EstadoId = c.EstadoId;
                        covids.Add(covid);
                    }
                }
            }
            if (FechaSalida != 0)
            {
                Covid co = new Covid();
                foreach (var c in listaCovid)
                {
                    if (c.CovidId == FechaSalida)
                    {
                        co.CovidId = c.CovidId;
                        co.PacienteId = c.PacienteId;
                        co.FechaIngreso = c.FechaIngreso;
                        co.Paciente = c.Paciente;
                        co.Estado = c.Estado;
                        co.FechaSalida = c.FechaSalida;
                        co.Observacion = c.Observacion;
                        co.Tratamiento = c.Tratamiento;
                        co.Medicamento = c.Medicamento;
                        co.EstadoId = c.EstadoId;
                    }
                }
                foreach (var c in listaCovid)
                {
                    if (c.FechaSalida == co.FechaSalida)
                    {
                        Covid covid = new Covid();
                        covid.CovidId = c.CovidId;
                        covid.PacienteId = c.PacienteId;
                        covid.FechaIngreso = c.FechaIngreso;
                        covid.Paciente = c.Paciente;
                        covid.Estado = c.Estado;
                        covid.FechaSalida = c.FechaSalida;
                        covid.Observacion = c.Observacion;
                        covid.Tratamiento = c.Tratamiento;
                        covid.Medicamento = c.Medicamento;
                        covid.EstadoId = c.EstadoId;
                        covids.Add(covid);
                    }
                }
            }
            if (Observacion != 0)
            {
                Covid co = new Covid();
                foreach (var c in listaCovid)
                {
                    if (c.CovidId == Observacion)
                    {
                        co.CovidId = c.CovidId;
                        co.PacienteId = c.PacienteId;
                        co.FechaIngreso = c.FechaIngreso;
                        co.Paciente = c.Paciente;
                        co.Estado = c.Estado;
                        co.FechaSalida = c.FechaSalida;
                        co.Observacion = c.Observacion;
                        co.Medicamento = c.Medicamento;
                        co.Tratamiento = c.Tratamiento;
                        co.EstadoId = c.EstadoId;
                    }
                }
                foreach (var c in listaCovid)
                {
                    if (c.Observacion == co.Observacion)
                    {
                        Covid covid = new Covid();
                        covid.CovidId = c.CovidId;
                        covid.PacienteId = c.PacienteId;
                        covid.FechaIngreso = c.FechaIngreso;
                        covid.Paciente = c.Paciente;
                        covid.Estado = c.Estado;
                        covid.FechaSalida = c.FechaSalida;
                        covid.Observacion = c.Observacion;
                        covid.Tratamiento = c.Tratamiento;
                        covid.EstadoId = c.EstadoId;
                        covids.Add(covid);
                    }
                }
            }
            if (Tratamiento != 0)
            {
                Covid co = new Covid();
                foreach (var c in listaCovid)
                {
                    if (c.CovidId == Tratamiento)
                    {
                        co.CovidId = c.CovidId;
                        co.PacienteId = c.PacienteId;
                        co.FechaIngreso = c.FechaIngreso;
                        co.Paciente = c.Paciente;
                        co.Estado = c.Estado;
                        co.FechaSalida = c.FechaSalida;
                        co.Observacion = c.Observacion;
                        co.Tratamiento = c.Tratamiento;
                        co.EstadoId = c.EstadoId;
                    }
                }
                foreach (var c in listaCovid)
                {
                    if (c.Tratamiento == co.Tratamiento)
                    {
                        Covid covid = new Covid();
                        covid.CovidId = c.CovidId;
                        covid.PacienteId = c.PacienteId;
                        covid.FechaIngreso = c.FechaIngreso;
                        covid.Paciente = c.Paciente;
                        covid.Estado = c.Estado;
                        covid.FechaSalida = c.FechaSalida;
                        covid.Observacion = c.Observacion;
                        covid.Tratamiento = c.Tratamiento;
                        covid.EstadoId = c.EstadoId;
                        covids.Add(covid);
                    }
                }
            }
            ViewBag.MiListado = covids.ToList();
            return View(ViewBag.MiListado = covids);
        }
    }
}