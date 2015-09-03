using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AERHiPets.DAL.GestionAdopcionApadrinamiento;
using AERHiPets.Models.GestionAdopcionApadrinamiento.GestionApadrinamiento;

namespace AERHiPets.Controllers.GestionAdopApa.GestionApadrinamiento
{
    public class EstadoApadrinamientoesController : Controller
    {
        private GestionAdopApaDb db = new GestionAdopApaDb();

        // GET: EstadoApadrinamientoes
        public ActionResult Index()
        {
            return View(db.estadosApadrinamientos.ToList());
        }

        // GET: EstadoApadrinamientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoApadrinamiento estadoApadrinamiento = db.estadosApadrinamientos.Find(id);
            if (estadoApadrinamiento == null)
            {
                return HttpNotFound();
            }
            return View(estadoApadrinamiento);
        }

        // GET: EstadoApadrinamientoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoApadrinamientoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre")] EstadoApadrinamiento estadoApadrinamiento)
        {
            if (ModelState.IsValid)
            {
                db.estadosApadrinamientos.Add(estadoApadrinamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoApadrinamiento);
        }

        // GET: EstadoApadrinamientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoApadrinamiento estadoApadrinamiento = db.estadosApadrinamientos.Find(id);
            if (estadoApadrinamiento == null)
            {
                return HttpNotFound();
            }
            return View(estadoApadrinamiento);
        }

        // POST: EstadoApadrinamientoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre")] EstadoApadrinamiento estadoApadrinamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoApadrinamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoApadrinamiento);
        }

        // GET: EstadoApadrinamientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoApadrinamiento estadoApadrinamiento = db.estadosApadrinamientos.Find(id);
            if (estadoApadrinamiento == null)
            {
                return HttpNotFound();
            }
            return View(estadoApadrinamiento);
        }

        // POST: EstadoApadrinamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoApadrinamiento estadoApadrinamiento = db.estadosApadrinamientos.Find(id);
            db.estadosApadrinamientos.Remove(estadoApadrinamiento);
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
