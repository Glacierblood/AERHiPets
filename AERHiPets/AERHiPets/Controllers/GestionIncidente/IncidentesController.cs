using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AERHiPets.DAL.GestionAdopcionApadrinamiento;
using AERHiPets.Models.GestionIncidentes;

namespace AERHiPets.Controllers.GestionIncidente
{
    public class IncidentesController : Controller
    {
        private GestionAdopApaDb db = new GestionAdopApaDb();

        // GET: Incidentes
        public ActionResult Index()
        {
            var incidentes = db.Incidentes.Include(i => i.raza).Include(i => i.tamanio).Include(i => i.tipoIncidente);
            return View(incidentes.ToList());
        }

        // GET: Incidentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidente incidente = db.Incidentes.Find(id);
            if (incidente == null)
            {
                return HttpNotFound();
            }
            return View(incidente);
        }

        // GET: Incidentes/Create
        public ActionResult Create()
        {
            ViewBag.razaId = new SelectList(db.Razas, "Id", "nombre");
            ViewBag.tamanioId = new SelectList(db.Tamanios, "Id", "nombre");
            ViewBag.tipoIncidenteId = new SelectList(db.TipoIncidentes, "Id", "tipoIncidente");
            return View();
        }

        // POST: Incidentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,descripcion,tamanioId,razaId,Nombre,Apellido,telefono,fechaFin,fechaAlta,fechaBaja,EstadoIncidente,tipoIncidenteId")] Incidente incidente)
        {
            if (ModelState.IsValid)
            {
                db.Incidentes.Add(incidente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.razaId = new SelectList(db.Razas, "Id", "nombre", incidente.razaId);
            ViewBag.tamanioId = new SelectList(db.Tamanios, "Id", "nombre", incidente.tamanioId);
            ViewBag.tipoIncidenteId = new SelectList(db.TipoIncidentes, "Id", "tipoIncidente", incidente.tipoIncidenteId);
            return View(incidente);
        }

        // GET: Incidentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidente incidente = db.Incidentes.Find(id);
            if (incidente == null)
            {
                return HttpNotFound();
            }
            ViewBag.razaId = new SelectList(db.Razas, "Id", "nombre", incidente.razaId);
            ViewBag.tamanioId = new SelectList(db.Tamanios, "Id", "nombre", incidente.tamanioId);
            ViewBag.tipoIncidenteId = new SelectList(db.TipoIncidentes, "Id", "tipoIncidente", incidente.tipoIncidenteId);
            return View(incidente);
        }

        // POST: Incidentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,descripcion,tamanioId,razaId,Nombre,Apellido,telefono,fechaFin,fechaAlta,fechaBaja,EstadoIncidente,tipoIncidenteId")] Incidente incidente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incidente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.razaId = new SelectList(db.Razas, "Id", "nombre", incidente.razaId);
            ViewBag.tamanioId = new SelectList(db.Tamanios, "Id", "nombre", incidente.tamanioId);
            ViewBag.tipoIncidenteId = new SelectList(db.TipoIncidentes, "Id", "tipoIncidente", incidente.tipoIncidenteId);
            return View(incidente);
        }

        // GET: Incidentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidente incidente = db.Incidentes.Find(id);
            if (incidente == null)
            {
                return HttpNotFound();
            }
            return View(incidente);
        }

        // POST: Incidentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Incidente incidente = db.Incidentes.Find(id);
            db.Incidentes.Remove(incidente);
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
    }
}
