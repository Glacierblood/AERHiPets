using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AERHiPets.DAL.GestionVoluntariosDAL;
using AERHiPets.Models.GestionDireccion;

namespace AERHiPets.Controllers.GestionDireccion
{
    public class DireccionsController : Controller
    {
        private GestionVoluntarioDb db = new GestionVoluntarioDb();

        // GET: Direccions
        public ActionResult Index()
        {
            var direcciones = db.direcciones.Include(d => d.barrio);
            return View(direcciones.ToList());
        }

        // GET: Direccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.direcciones.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // GET: Direccions/Create
        public ActionResult Create()
        {
            ViewBag.barrioId = new SelectList(db.barrios, "Id", "nombre");
            return View();
        }

        // POST: Direccions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,barrioId,calle,piso,Torre")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.direcciones.Add(direccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.barrioId = new SelectList(db.barrios, "Id", "nombre", direccion.barrioId);
            return View(direccion);
        }

        // GET: Direccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.direcciones.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.barrioId = new SelectList(db.barrios, "Id", "nombre", direccion.barrioId);
            return View(direccion);
        }

        // POST: Direccions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,barrioId,calle,piso,Torre")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.barrioId = new SelectList(db.barrios, "Id", "nombre", direccion.barrioId);
            return View(direccion);
        }

        // GET: Direccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.direcciones.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // POST: Direccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Direccion direccion = db.direcciones.Find(id);
            db.direcciones.Remove(direccion);
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
