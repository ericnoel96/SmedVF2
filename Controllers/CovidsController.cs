using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Smed.Models;

namespace Smed.Controllers
{
    [Authorize]
    public class CovidsController : Controller
    {
        private SmedDB db = new SmedDB();

        // GET: Covids
        
        public ActionResult Index()
        {
            var covids = db.Covids.Include(c => c.Estado).Include(c => c.Paciente);
            return View(covids.ToList());
            
        }



        // GET: Covids/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Covid covid = db.Covids.Find(id);
            if (covid == null)
            {
                return HttpNotFound();
            }
            return View(covid);
        }

        // GET: Covids/Create
        [Authorize(Roles = "Med")]
        public ActionResult Create()
        {
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "Tipo");
            ViewBag.PacienteId = new SelectList(db.Pacientes, "PacienteId", "Cedula");
            return View();
        }

        // POST: Covids/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CovidId,PacienteId,FechaIngreso,Observacion,Medicamento,Tratamiento,EstadoId,FechaSalida")] Covid covid)
        {
            if (ModelState.IsValid)
            {
                db.Covids.Add(covid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "Tipo", covid.EstadoId);
            ViewBag.PacienteId = new SelectList(db.Pacientes, "PacienteId", "Cedula", covid.PacienteId);
            return View(covid);
        }

        // GET: Covids/Edit/5
        [Authorize(Roles = "Med")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Covid covid = db.Covids.Find(id);
            if (covid == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "Tipo", covid.EstadoId);
            ViewBag.PacienteId = new SelectList(db.Pacientes, "PacienteId", "Cedula", covid.PacienteId);
            return View(covid);
        }

        // POST: Covids/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CovidId,PacienteId,FechaIngreso,Observacion,Medicamento,Tratamiento,EstadoId,FechaSalida")] Covid covid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(covid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "Tipo", covid.EstadoId);
            ViewBag.PacienteId = new SelectList(db.Pacientes, "PacienteId", "Cedula", covid.PacienteId);
            return View(covid);
        }

        // GET: Covids/Delete/5
        [Authorize(Roles = "Med")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Covid covid = db.Covids.Find(id);
            if (covid == null)
            {
                return HttpNotFound();
            }
            return View(covid);
        }

        // POST: Covids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Covid covid = db.Covids.Find(id);
            db.Covids.Remove(covid);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Dashboard()
        {
            //---------------- Histograma --------------------------
            var list = db.Covids.ToList();
            var listE = db.Estados.ToList();
            List<int> covids = new List<int>();
            List<string> nombres = new List<string>();
            var pacientes = list.Select(x => x.EstadoId).Distinct();
            foreach (var item in pacientes)
            {
                covids.Add(list.Count(x => x.EstadoId == item));
            }
            foreach (var i in listE)
            {
                nombres.Add(i.Tipo.ToString());
            }
            var pac = nombres;
            ViewBag.PACIENTES = nombres;
            ViewBag.COVIDS = covids.ToList();
            return View();
        }
    }
}
