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
    public class RazasController : Controller
    {
        private GestionAnimalDb db = new GestionAnimalDb();

        // GET: Raza
        public ActionResult Index()
        {
            var razas = db.Razas.Include(r => r.especie).Where(a => a.fechaBaja == null);
            return View(razas.ToList());
        }

        // GET: Raza/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raza raza = db.Razas.Find(id);
            raza.especie = db.Especies.SingleOrDefault(i => i.Id == raza.especieID);
            if (raza == null)
            {
                return HttpNotFound();
            }
            return View(raza);
        }

        // GET: Raza/Create
        public ActionResult Create()
        {
            ViewBag.especieID = new SelectList(db.Especies.Where(a => a.fechaBaja == null), "Id", "nombre");
            return View();
        }

        // POST: Raza/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,descripcion,especieID")] Raza raza)
        {
            if (ModelState.IsValid)
            {
                db.Razas.Add(raza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.especieID = new SelectList(db.Especies.Where(a => a.fechaBaja == null), "Id", "nombre", raza.especieID);
            return View(raza);
        }

        // GET: Raza/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raza raza = db.Razas.Find(id);
            if (raza == null)
            {
                return HttpNotFound();
            }
            ViewBag.especieID = new SelectList(db.Especies.Where(a => a.fechaBaja == null), "Id", "nombre", raza.especieID);
            return View(raza);
        }

        // POST: Raza/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,descripcion,especieID")] Raza raza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.especieID = new SelectList(db.Especies.Where(a => a.fechaBaja == null), "Id", "nombre", raza.especieID);
            return View(raza);
        }

        // GET: Raza/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raza raza = db.Razas.Find(id);
            raza.especie = db.Especies.SingleOrDefault(i => i.Id == raza.especieID);
            if (raza == null)
            {
                return HttpNotFound();
            }
            return View(raza);
        }

        // POST: Raza/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Raza raza = db.Razas.Find(id);
            
            raza.fechaBaja = System.DateTime.Now;
            db.Entry(raza).State = EntityState.Modified;
            //db.Razas.Remove(raza);
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
