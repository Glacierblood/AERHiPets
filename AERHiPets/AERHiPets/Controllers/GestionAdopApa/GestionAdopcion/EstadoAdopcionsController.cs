using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AERHiPets.DAL.GestionAdopcionApadrinamiento;
using AERHiPets.Models.GestionAdopcionApadrinamiento.GestionAdopcion;

namespace AERHiPets.Controllers.GestionAdopApa.GestionAdopcion
{
    public class EstadoAdopcionsController : Controller
    {
        private GestionAdopApaDb db = new GestionAdopApaDb();

        // GET: EstadoAdopcions
        public ActionResult Index()
        {
            return View(db.estadosAdopciones.ToList());
        }

        // GET: EstadoAdopcions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoAdopcion estadoAdopcion = db.estadosAdopciones.Find(id);
            if (estadoAdopcion == null)
            {
                return HttpNotFound();
            }
            return View(estadoAdopcion);
        }

        // GET: EstadoAdopcions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoAdopcions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,descripcion")] EstadoAdopcion estadoAdopcion)
        {
            if (ModelState.IsValid)
            {
                db.estadosAdopciones.Add(estadoAdopcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoAdopcion);
        }

        // GET: EstadoAdopcions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoAdopcion estadoAdopcion = db.estadosAdopciones.Find(id);
            if (estadoAdopcion == null)
            {
                return HttpNotFound();
            }
            return View(estadoAdopcion);
        }

        // POST: EstadoAdopcions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,descripcion")] EstadoAdopcion estadoAdopcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoAdopcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoAdopcion);
        }

        // GET: EstadoAdopcions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoAdopcion estadoAdopcion = db.estadosAdopciones.Find(id);
            if (estadoAdopcion == null)
            {
                return HttpNotFound();
            }
            return View(estadoAdopcion);
        }

        // POST: EstadoAdopcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoAdopcion estadoAdopcion = db.estadosAdopciones.Find(id);
            db.estadosAdopciones.Remove(estadoAdopcion);
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
