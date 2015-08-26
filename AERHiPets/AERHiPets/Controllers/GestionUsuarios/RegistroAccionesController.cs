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
    public class RegistroAccionesController : Controller
    {
        private GestionVoluntarioDb db = new GestionVoluntarioDb();

        // GET: RegistroAcciones
        public ActionResult Index()
        {
            var registroAcciones = db.registroAcciones.Include(r => r.acciones).Include(r => r.persona);
            return View(registroAcciones.ToList());
        }

        // GET: RegistroAcciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroAcciones registroAcciones = db.registroAcciones.Find(id);
            if (registroAcciones == null)
            {
                return HttpNotFound();
            }
            return View(registroAcciones);
        }

        // GET: RegistroAcciones/Create
        public ActionResult Create()
        {
            ViewBag.accionesId = new SelectList(db.acciones, "Id", "nombre");
            ViewBag.personaId = new SelectList(db.personas, "Id", "Nombre");
            return View();
        }

        // POST: RegistroAcciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,fechaAlta,fechcaBaja,comentario,personaId,accionesId")] RegistroAcciones registroAcciones)
        {
            if (ModelState.IsValid)
            {
                db.registroAcciones.Add(registroAcciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.accionesId = new SelectList(db.acciones, "Id", "nombre", registroAcciones.accionesId);
            ViewBag.personaId = new SelectList(db.personas, "Id", "Nombre", registroAcciones.personaId);
            return View(registroAcciones);
        }

        // GET: RegistroAcciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroAcciones registroAcciones = db.registroAcciones.Find(id);
            if (registroAcciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.accionesId = new SelectList(db.acciones, "Id", "nombre", registroAcciones.accionesId);
            ViewBag.personaId = new SelectList(db.personas, "Id", "Nombre", registroAcciones.personaId);
            return View(registroAcciones);
        }

        // POST: RegistroAcciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,fechaAlta,fechcaBaja,comentario,personaId,accionesId")] RegistroAcciones registroAcciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registroAcciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.accionesId = new SelectList(db.acciones, "Id", "nombre", registroAcciones.accionesId);
            ViewBag.personaId = new SelectList(db.personas, "Id", "Nombre", registroAcciones.personaId);
            return View(registroAcciones);
        }

        // GET: RegistroAcciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroAcciones registroAcciones = db.registroAcciones.Find(id);
            if (registroAcciones == null)
            {
                return HttpNotFound();
            }
            return View(registroAcciones);
        }

        // POST: RegistroAcciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroAcciones registroAcciones = db.registroAcciones.Find(id);
            db.registroAcciones.Remove(registroAcciones);
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
