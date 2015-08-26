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
using AERHiPets.Models.GestionUsuarios.Modelos;

namespace AERHiPets.Controllers.GestionUsuarios
{
    public class PersonasController : Controller
    {
        private GestionVoluntarioDb db = new GestionVoluntarioDb();

        // GET: Personas
        public ActionResult Index()
        {
            var personas = db.personas.Include(p => p.direccion);
            return View(personas.ToList());
        }

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            GestionVoluntarioDb bd = new GestionVoluntarioDb();
            var listaacc = bd.acciones.ToList();
            PersonaModelo pm = new PersonaModelo();
            pm.listaAcciones = listaacc;            
            ViewBag.direccionId = new SelectList(db.direcciones, "Id", "calle");
            return View(pm);
        }

        // POST: Personas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,fechaNac,fechaAlta,fechaBaja,telefono,telefonoCel,puntaje,direccionId")] Persona persona)
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido")] Persona persona, PersonaModelo pm)
        {
            
           

            if (ModelState.IsValid)
            {
                persona.fechaAlta = DateTime.Now;
                persona.fechaNac = DateTime.Now;

                db.personas.Add(persona);
                db.SaveChanges();

                foreach (var item in pm.listaAcciones)
                {
                    if (item.isSelected) { 
                    RegistroAcciones RA = new RegistroAcciones();
                    RA.accionesId = item.Id;
                    RA.personaId = persona.Id;
                    RA.fechaAlta = DateTime.Now;
                    db.registroAcciones.Add(RA);
                    db.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }

            return View(persona);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.direccionId = new SelectList(db.direcciones, "Id", "calle", persona.direccionId);
            return View(persona);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,fechaNac,fechaAlta,fechaBaja,telefono,telefonoCel,puntaje,direccionId")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.direccionId = new SelectList(db.direcciones, "Id", "calle", persona.direccionId);
            return View(persona);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = db.personas.Find(id);
            db.personas.Remove(persona);
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
