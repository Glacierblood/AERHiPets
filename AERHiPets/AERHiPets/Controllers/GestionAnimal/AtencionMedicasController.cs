using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AERHiPets.DAL.GestionAnimalesDAL;
using AERHiPets.Models.GestionAnimal;
using AERHiPets.Models.GestionAnimal.GestionAnimalModelos;

namespace AERHiPets.Controllers.GestionAnimal
{
    public class AtencionMedicasController : Controller
    {
        private GestionAnimalDb db = new GestionAnimalDb();

        // GET: AtencionMedicas
        public ActionResult Index()
        {
            var atencionesMedicas = db.AtencionesMedicas.Include(a => a.animal).Include(a => a.productoVeterinaria).Include(a => a.veterinaria).Where(a => a.fechaBaja == null);
            //atencionesMedicas.animal = db.Animales.Include(r => r.raza).SingleOrDefault(i => i.Id == atencionesMedicas.animalId);
            
            return View(atencionesMedicas.ToList());
        }

        // GET: AtencionMedicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtencionMedica atencionMedica = db.AtencionesMedicas.Find(id);
            atencionMedica.animal = db.Animales.Include(r => r.raza).SingleOrDefault(i => i.Id == atencionMedica.animalId);
            atencionMedica.veterinaria = db.Veterinarias.SingleOrDefault(i => i.Id == atencionMedica.veterinariaId);
            atencionMedica.productoVeterinaria = db.ProductosVeterinarias.SingleOrDefault(i => i.Id == atencionMedica.productoVeterinariaId);
            if (atencionMedica == null)
            {
                return HttpNotFound();
            }
            return View(atencionMedica);
        }

        // GET: AtencionMedicas/Create
        public ActionResult Create()
        {
            var animales = db.Animales.Include(a => a.raza).Include(a => a.tamanio).Where(a => a.fechaBaja == null);
            var especies = db.Especies;
            var veterinarias = db.Veterinarias.Where(a => a.fechaBaja == null).ToList();
            var productos = db.ProductosVeterinarias.Where(a => a.fechaBaja == null).ToList();
            AtencionMedicaModelo atencionMedicaModelo = new AtencionMedicaModelo();
            atencionMedicaModelo.animales = animales.ToList();
            atencionMedicaModelo.veterinarias = veterinarias;
            atencionMedicaModelo.productosVeterinarias = productos;
            atencionMedicaModelo.especies = especies.ToList();


            ViewBag.animalId = new SelectList(db.Animales.Where(a => a.fechaBaja == null), "Id", "nombre");
            ViewBag.productoVeterinariaId = new SelectList(db.ProductosVeterinarias.Where(a => a.fechaBaja == null), "Id", "nombre");
            ViewBag.veterinariaId = new SelectList(db.Veterinarias.Where(a => a.fechaBaja == null), "Id", "nombre");
            return View(atencionMedicaModelo);
        }

        // POST: AtencionMedicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,animalId,veterinariaId,productoVeterinariaId,tratamiento,nombreVeterinario")] AtencionMedica atencionMedica)
        {
            //var animales = db.Animales.Include(a => a.raza).Include(a => a.tamanio);
            //AtencionMedicaModelo model = new AtencionMedicaModelo();
            //model.animales = animales.ToList();
            //model.atencionMedica = atencionMedica;
           

            if (ModelState.IsValid)
            {
                db.AtencionesMedicas.Add(atencionMedica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.animalId = new SelectList(db.Animales.Where(a => a.fechaBaja == null), "Id", "nombre", atencionMedica.animalId);
            ViewBag.productoVeterinariaId = new SelectList(db.ProductosVeterinarias.Where(a => a.fechaBaja == null), "Id", "nombre", atencionMedica.productoVeterinariaId);
            ViewBag.veterinariaId = new SelectList(db.Veterinarias.Where(a => a.fechaBaja == null), "Id", "nombre", atencionMedica.veterinariaId);
            return View(atencionMedica);
        }

        // GET: AtencionMedicas/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //---------------------------------------------------

            var animales = db.Animales.Include(a => a.raza).Include(a => a.tamanio).Where(a => a.fechaBaja == null);
            var especies = db.Especies;
            var veterinarias = db.Veterinarias.Where(a => a.fechaBaja == null).ToList();
            var productos = db.ProductosVeterinarias.Where(a => a.fechaBaja == null).ToList();
            AtencionMedicaModelo atencionMedicaModelo = new AtencionMedicaModelo();
            atencionMedicaModelo.animales = animales.ToList();
            atencionMedicaModelo.veterinarias = veterinarias;
            atencionMedicaModelo.productosVeterinarias = productos;
            atencionMedicaModelo.especies = especies.ToList();
            

            //---------------------------------------------------
            AtencionMedica atencionMedica = db.AtencionesMedicas.Find(id);
            atencionMedica.animal = db.Animales.Include(r => r.raza).SingleOrDefault(i => i.Id == atencionMedica.animalId);
            atencionMedica.veterinaria = db.Veterinarias.SingleOrDefault(i => i.Id == atencionMedica.veterinariaId);
            atencionMedica.productoVeterinaria = db.ProductosVeterinarias.SingleOrDefault(i => i.Id == atencionMedica.productoVeterinariaId);

            atencionMedicaModelo.atencionMedica = atencionMedica;

            if (atencionMedica == null)
            {
                return HttpNotFound();
            }
            ViewBag.animalId = new SelectList(db.Animales.Where(a => a.fechaBaja == null), "Id", "nombre", atencionMedica.animalId);
            ViewBag.productoVeterinariaId = new SelectList(db.ProductosVeterinarias.Where(a => a.fechaBaja == null), "Id", "nombre", atencionMedica.productoVeterinariaId);
            ViewBag.veterinariaId = new SelectList(db.Veterinarias.Where(a => a.fechaBaja == null), "Id", "nombre", atencionMedica.veterinariaId);
            //return View(atencionMedica);
            return View(atencionMedicaModelo);
        }

        // POST: AtencionMedicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,animalId,veterinariaId,productoVeterinariaId,tratamiento,nombreVeterinario")] AtencionMedica atencionMedica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atencionMedica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.animalId = new SelectList(db.Animales, "Id", "nombre", atencionMedica.animalId);
            ViewBag.productoVeterinariaId = new SelectList(db.ProductosVeterinarias, "Id", "nombre", atencionMedica.productoVeterinariaId);
            ViewBag.veterinariaId = new SelectList(db.Veterinarias, "Id", "nombre", atencionMedica.veterinariaId);
            return View(atencionMedica);
        }

        // GET: AtencionMedicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtencionMedica atencionMedica = db.AtencionesMedicas.Find(id);
            atencionMedica.animal = db.Animales.Include(r => r.raza).SingleOrDefault(i => i.Id == atencionMedica.animalId);
            atencionMedica.veterinaria = db.Veterinarias.SingleOrDefault(i => i.Id == atencionMedica.veterinariaId);
            atencionMedica.productoVeterinaria = db.ProductosVeterinarias.SingleOrDefault(i => i.Id == atencionMedica.productoVeterinariaId);
            if (atencionMedica == null)
            {
                return HttpNotFound();
            }
            return View(atencionMedica);
        }

        // POST: AtencionMedicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AtencionMedica atencionMedica = db.AtencionesMedicas.Find(id);
            
            atencionMedica.fechaBaja = System.DateTime.Now;
            db.Entry(atencionMedica).State = EntityState.Modified;
            //db.AtencionesMedicas.Remove(atencionMedica);
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
