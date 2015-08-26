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
    public class LocalidadsController : Controller
    {
        private GestionVoluntarioDb db = new GestionVoluntarioDb();

        // GET: Localidads
        public ActionResult Index()
        {
            var localidades = db.localidades.Include(l => l.provincia);
            return View(localidades.ToList());
        }

        // GET: Localidads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localidad localidad = db.localidades.Find(id);
            if (localidad == null)
            {
                return HttpNotFound();
            }
            return View(localidad);
        }

        // GET: Localidads/Create
        public ActionResult Create()
        {
            ViewBag.provinciaId = new SelectList(db.provincias, "Id", "nombre");
            return View();
        }

        // POST: Localidads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,provinciaId")] Localidad localidad)
        {
            if (ModelState.IsValid)
            {
                db.localidades.Add(localidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.provinciaId = new SelectList(db.provincias, "Id", "nombre", localidad.provinciaId);
            return View(localidad);
        }

        // GET: Localidads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localidad localidad = db.localidades.Find(id);
            if (localidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.provinciaId = new SelectList(db.provincias, "Id", "nombre", localidad.provinciaId);
            return View(localidad);
        }

        // POST: Localidads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,provinciaId")] Localidad localidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(localidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.provinciaId = new SelectList(db.provincias, "Id", "nombre", localidad.provinciaId);
            return View(localidad);
        }

        // GET: Localidads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localidad localidad = db.localidades.Find(id);
            if (localidad == null)
            {
                return HttpNotFound();
            }
            return View(localidad);
        }

        // POST: Localidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Localidad localidad = db.localidades.Find(id);
            db.localidades.Remove(localidad);
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
