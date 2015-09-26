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
    public class TipoIncidentesController : Controller
    {
        private GestionAdopApaDb db = new GestionAdopApaDb();

        // GET: TipoIncidentes
        public ActionResult Index()
        {
            return View(db.TipoIncidentes.ToList());
        }

        // GET: TipoIncidentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoIncidente tipoIncidente = db.TipoIncidentes.Find(id);
            if (tipoIncidente == null)
            {
                return HttpNotFound();
            }
            return View(tipoIncidente);
        }

        // GET: TipoIncidentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoIncidentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,tipoIncidente,descripcion")] TipoIncidente tipoIncidente)
        {
            if (ModelState.IsValid)
            {
                db.TipoIncidentes.Add(tipoIncidente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoIncidente);
        }

        // GET: TipoIncidentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoIncidente tipoIncidente = db.TipoIncidentes.Find(id);
            if (tipoIncidente == null)
            {
                return HttpNotFound();
            }
            return View(tipoIncidente);
        }

        // POST: TipoIncidentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,tipoIncidente,descripcion")] TipoIncidente tipoIncidente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoIncidente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoIncidente);
        }

        // GET: TipoIncidentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoIncidente tipoIncidente = db.TipoIncidentes.Find(id);
            if (tipoIncidente == null)
            {
                return HttpNotFound();
            }
            return View(tipoIncidente);
        }

        // POST: TipoIncidentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoIncidente tipoIncidente = db.TipoIncidentes.Find(id);
            db.TipoIncidentes.Remove(tipoIncidente);
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
