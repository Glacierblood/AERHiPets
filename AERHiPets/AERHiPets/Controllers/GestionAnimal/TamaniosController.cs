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
    [Authorize]
    public class TamaniosController : Controller
    {
        private GestionAnimalDb db = new GestionAnimalDb();

        // GET: Tamanio
        public ActionResult Index()
        {
            return View(db.Tamanios.Where(a => a.fechaBaja == null).ToList());
        }

        // GET: Tamanio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamanio tamanio = db.Tamanios.Find(id);
            if (tamanio == null)
            {
                return HttpNotFound();
            }
            return View(tamanio);
        }

        // GET: Tamanio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tamanio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,descripcion")] Tamanio tamanio)
        {
            if (ModelState.IsValid)
            {
                db.Tamanios.Add(tamanio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tamanio);
        }

        // GET: Tamanio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamanio tamanio = db.Tamanios.Find(id);
            if (tamanio == null)
            {
                return HttpNotFound();
            }
            return View(tamanio);
        }

        // POST: Tamanio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,descripcion")] Tamanio tamanio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tamanio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tamanio);
        }

        // GET: Tamanio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamanio tamanio = db.Tamanios.Find(id);
            if (tamanio == null)
            {
                return HttpNotFound();
            }
            return View(tamanio);
        }

        // POST: Tamanio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tamanio tamanio = db.Tamanios.Find(id);
            
            tamanio.fechaBaja = System.DateTime.Now;
            db.Entry(tamanio).State = EntityState.Modified;
            //db.Tamanios.Remove(tamanio);
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
