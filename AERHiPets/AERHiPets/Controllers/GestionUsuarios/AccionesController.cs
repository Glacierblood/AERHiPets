using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AERHiPets.DAL.GestionVoluntariosDAL;
using AERHiPets.Models.GestionUsuarios;

namespace AERHiPets.Controllers.GestionUsuarios
{
    public class AccionesController : Controller
    {
        private GestionVoluntarioDb db = new GestionVoluntarioDb();

        // GET: Acciones
        public ActionResult Index()
        {
            return View(db.acciones.ToList());
        }

        // GET: Acciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acciones acciones = db.acciones.Find(id);
            if (acciones == null)
            {
                return HttpNotFound();
            }
            return View(acciones);
        }

        // GET: Acciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Acciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,descripcion")] Acciones acciones)
        {
            if (ModelState.IsValid)
            {
                db.acciones.Add(acciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(acciones);
        }

        // GET: Acciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acciones acciones = db.acciones.Find(id);
            if (acciones == null)
            {
                return HttpNotFound();
            }
            return View(acciones);
        }

        // POST: Acciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,descripcion")] Acciones acciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(acciones);
        }

        // GET: Acciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acciones acciones = db.acciones.Find(id);
            if (acciones == null)
            {
                return HttpNotFound();
            }
            return View(acciones);
        }

        // POST: Acciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Acciones acciones = db.acciones.Find(id);
            db.acciones.Remove(acciones);
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
