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
    public class TipoAdopcionsController : Controller
    {
        private GestionAdopApaDb db = new GestionAdopApaDb();

        // GET: TipoAdopcions
        public ActionResult Index()
        {
            return View(db.tiposAdopciones.ToList());
        }

        // GET: TipoAdopcions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAdopcion tipoAdopcion = db.tiposAdopciones.Find(id);
            if (tipoAdopcion == null)
            {
                return HttpNotFound();
            }
            return View(tipoAdopcion);
        }

        // GET: TipoAdopcions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoAdopcions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,tipoAdopcion")] TipoAdopcion model)
        {
            if (ModelState.IsValid)
            {
                db.tiposAdopciones.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: TipoAdopcions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAdopcion tipoAdopcion = db.tiposAdopciones.Find(id);
            if (tipoAdopcion == null)
            {
                return HttpNotFound();
            }
            return View(tipoAdopcion);
        }

        // POST: TipoAdopcions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,tipoAdopcion")] TipoAdopcion tipoAdopcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoAdopcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoAdopcion);
        }

        // GET: TipoAdopcions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAdopcion tipoAdopcion = db.tiposAdopciones.Find(id);
            if (tipoAdopcion == null)
            {
                return HttpNotFound();
            }
            return View(tipoAdopcion);
        }

        // POST: TipoAdopcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoAdopcion tipoAdopcion = db.tiposAdopciones.Find(id);
            db.tiposAdopciones.Remove(tipoAdopcion);
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
