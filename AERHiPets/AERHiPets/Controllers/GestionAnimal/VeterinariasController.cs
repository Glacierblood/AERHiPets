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

namespace AERHiPets.Controllers.GestionAnimal
{
    public class VeterinariasController : Controller
    {
        private GestionAnimalDb db = new GestionAnimalDb();

        // GET: Veterinarias
        public ActionResult Index()
        {
            return View(db.Veterinarias.Where(a => a.fechaBaja == null).ToList());
        }

        // GET: Veterinarias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinaria veterinaria = db.Veterinarias.Find(id);
            if (veterinaria == null)
            {
                return HttpNotFound();
            }
            return View(veterinaria);
        }

        // GET: Veterinarias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Veterinarias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,direccion,telefono")] Veterinaria veterinaria)
        {
            if (ModelState.IsValid)
            {
                db.Veterinarias.Add(veterinaria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(veterinaria);
        }

        // GET: Veterinarias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinaria veterinaria = db.Veterinarias.Find(id);
            if (veterinaria == null)
            {
                return HttpNotFound();
            }
            return View(veterinaria);
        }

        // POST: Veterinarias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,direccion,telefono")] Veterinaria veterinaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veterinaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(veterinaria);
        }

        // GET: Veterinarias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinaria veterinaria = db.Veterinarias.Find(id);
            if (veterinaria == null)
            {
                return HttpNotFound();
            }
            return View(veterinaria);
        }

        // POST: Veterinarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Veterinaria veterinaria = db.Veterinarias.Find(id);
            
            veterinaria.fechaBaja = System.DateTime.Now;
            db.Entry(veterinaria).State = EntityState.Modified;
           // db.Veterinarias.Remove(veterinaria);
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
