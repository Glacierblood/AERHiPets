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
    public class BarriosController : Controller
    {
        private GestionVoluntarioDb db = new GestionVoluntarioDb();

        // GET: Barrios
        public ActionResult Index()
        {
            var barrios = db.barrios.Include(b => b.localidad);
            return View(barrios.ToList());
        }

        // GET: Barrios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrio barrio = db.barrios.Find(id);
            if (barrio == null)
            {
                return HttpNotFound();
            }
            return View(barrio);
        }

        // GET: Barrios/Create
        public ActionResult Create()
        {
            ViewBag.localidadId = new SelectList(db.localidades, "Id", "nombre");
            return View();
        }

        // POST: Barrios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,codigoPostal,localidadId")] Barrio barrio)
        {
            if (ModelState.IsValid)
            {
                db.barrios.Add(barrio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.localidadId = new SelectList(db.localidades, "Id", "nombre", barrio.localidadId);
            return View(barrio);
        }

        // GET: Barrios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrio barrio = db.barrios.Find(id);
            if (barrio == null)
            {
                return HttpNotFound();
            }
            ViewBag.localidadId = new SelectList(db.localidades, "Id", "nombre", barrio.localidadId);
            return View(barrio);
        }

        // POST: Barrios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,codigoPostal,localidadId")] Barrio barrio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(barrio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.localidadId = new SelectList(db.localidades, "Id", "nombre", barrio.localidadId);
            return View(barrio);
        }

        // GET: Barrios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrio barrio = db.barrios.Find(id);
            if (barrio == null)
            {
                return HttpNotFound();
            }
            return View(barrio);
        }

        // POST: Barrios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Barrio barrio = db.barrios.Find(id);
            db.barrios.Remove(barrio);
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
