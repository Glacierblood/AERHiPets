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
using AERHiPets.DAL.GestionAnimalesDAL;
using AERHiPets.Models.GestionAdopcionApadrinamiento.Models;
using AERHiPets.DAL.GestionVoluntariosDAL;
using Microsoft.AspNet.Identity.Owin;
using AERHiPets.Models.GestionUsuarios;

namespace AERHiPets.Controllers.GestionAdopApa.GestionAdopcion
{
    [Authorize]
    public class AdopcionsController : Controller
    {
        private GestionAdopApaDb db = new GestionAdopApaDb();
        private GestionAnimalDb dbAni = new GestionAnimalDb();
        private GestionVoluntarioDb dbVol = new GestionVoluntarioDb();

        // GET: Adopcions
        public ActionResult Index()
        {
            var adopciones = db.adopciones.Include(a => a.animal).Include(a => a.estadoAdopcion).Include(a => a.tipoAdopcion);
            return View(adopciones.ToList());
        }

        // GET: Adopcions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adopcion adopcion = db.adopciones.Find(id);
            if (adopcion == null)
            {
                return HttpNotFound();
            }
            return View(adopcion);
        }

        // GET: Adopcions/Create
        public ActionResult Create()
        {
            var animales = dbAni.Animales.Include(a => a.raza).Include(a => a.tamanio).Where(a => a.fechaBaja == null).Where(a => a.enAdopcion == true);
            var especies = dbAni.Especies.Where(a => a.fechaBaja == null);
            var formAdop = new Adoptar();
            formAdop.animales = animales.ToList();
            formAdop.especies = especies.ToList();
           

            ViewBag.animalId = new SelectList(dbAni.Animales.Where(a => a.fechaBaja == null), "Id", "nombre");
                       
            ViewBag.estadoAdopcionId = new SelectList(db.estadosAdopciones, "Id", "estadoAdopcion");
            ViewBag.tipoAdopcionId = new SelectList(db.tiposAdopciones, "Id", "tipoAdopcion");
            return View(formAdop);
        }

        // POST: Adopcions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,fechaFin,esTemporal,tipoAdopcionId")] Adopcion adopcion, Adoptar adop)
        {

            adopcion.VoluntarioUsrId = adop.adopcion.voluntario.UsrId;
            adopcion.animalId = adop.adopcion.animalId;            
            adopcion.esTemporal = adop.adopcion.esTemporal;
            if(adopcion.esTemporal){
                adopcion.fechaFin = adop.adopcion.fechaFin;
            }
            else
            {
                adopcion.fechaFin = null;
            }
            adopcion.voluntarioName = adop.adopcion.voluntario.Nombre;
            adopcion.estadoAdopcionId = 1;

           
            if (ModelState.ContainsKey("adopcion.voluntario.Apellido"))
                ModelState["adopcion.voluntario.Apellido"].Errors.Clear();
            if (ModelState.ContainsKey("adopcion.voluntario.telefonoCel"))
                ModelState["adopcion.voluntario.telefonoCel"].Errors.Clear();
            if (ModelState.ContainsKey("adopcion.voluntario.telefono"))
                ModelState["adopcion.voluntario.telefono"].Errors.Clear();
                        

            if (ModelState.IsValid)
            {
                
                adopcion.fechaAlta = DateTime.Now;
                
                db.adopciones.Add(adopcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var animales = dbAni.Animales.Include(a => a.raza).Include(a => a.tamanio).Where(a => a.fechaBaja == null);
            var especies = dbAni.Especies.Where(a => a.fechaBaja == null);
            var formAdop = new Adoptar();
            formAdop.animales = animales.ToList();
            formAdop.especies = especies.ToList();

            ViewBag.animalId = new SelectList(dbAni.Animales.Where(a => a.fechaBaja == null), "Id", "nombre");

            ViewBag.estadoAdopcionId = new SelectList(db.estadosAdopciones, "Id", "estadoAdopcion");
            ViewBag.tipoAdopcionId = new SelectList(db.tiposAdopciones, "Id", "tipoAdopcion");
            return View(formAdop);
        }

        // GET: Adopcions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adopcion adopcion = db.adopciones.Find(id);
            if (adopcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.direccionId = new SelectList(dbVol.direcciones, "Id", "calle", adopcion.direccionId);
            ViewBag.estadoAdopcionId = new SelectList(db.estadosAdopciones, "Id", "nombre", adopcion.estadoAdopcionId);
            ViewBag.tipoAdopcionId = new SelectList(db.tiposAdopciones, "Id", "tipoAdopcion", adopcion.tipoAdopcionId);
            return View(adopcion);
        }

        // POST: Adopcions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,fechaAlta,fechaFin,fechaEntrega,esTemporal,estadoAdopcionId,voluntarioName,animalId,empleadoUsrId,VoluntarioUsrId,empleadoName")] Adopcion adopcion)
        {
            switch(adopcion.estadoAdopcionId){
                case 1://solicitado
                    adopcion.fechaEntrega = null;
                    break;
                case 2://autorizado
                    break;
                case 3://rechazado
                    adopcion.fechaCancelacion = DateTime.Now;
                    break;
                case 4://entregado
                    break;
                case 5://cancelado
                    adopcion.fechaCancelacion = DateTime.Now;
                    break;
                default: break;
            }

            if (ModelState.IsValid)
            {
                db.Entry(adopcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.direccionId = new SelectList(dbVol.direcciones, "Id", "calle", adopcion.direccionId);
            ViewBag.estadoAdopcionId = new SelectList(db.estadosAdopciones, "Id", "estadoAdopcion", adopcion.estadoAdopcionId);
            ViewBag.tipoAdopcionId = new SelectList(db.tiposAdopciones, "Id", "tipoAdopcion", adopcion.tipoAdopcionId);
            return View(adopcion);
        }

        // GET: Adopcions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adopcion adopcion = db.adopciones.Find(id);
            if (adopcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.direccionId = new SelectList(dbVol.direcciones, "Id", "calle", adopcion.direccionId);
            ViewBag.estadoAdopcionId = new SelectList(db.estadosAdopciones, "Id", "nombre", adopcion.estadoAdopcionId);
            ViewBag.tipoAdopcionId = new SelectList(db.tiposAdopciones, "Id", "tipoAdopcion", adopcion.tipoAdopcionId);
            return View(adopcion);
        }

        // POST: Adopcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adopcion adopcion = db.adopciones.Find(id);
            db.adopciones.Remove(adopcion);
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
