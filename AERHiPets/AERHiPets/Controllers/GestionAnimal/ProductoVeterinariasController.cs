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
    public class ProductoVeterinariasController : Controller
    {
        private GestionAnimalDb db = new GestionAnimalDb();

        // GET: ProductoVeterinarias
        public ActionResult Index()
        {
            return View(db.ProductosVeterinarias.ToList());
        }

        // GET: ProductoVeterinarias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoVeterinaria productoVeterinaria = db.ProductosVeterinarias.Find(id);
            if (productoVeterinaria == null)
            {
                return HttpNotFound();
            }
            return View(productoVeterinaria);
        }

        // GET: ProductoVeterinarias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoVeterinarias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,cantidad,descripcion")] ProductoVeterinaria productoVeterinaria)
        {
            if (ModelState.IsValid)
            {
                db.ProductosVeterinarias.Add(productoVeterinaria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productoVeterinaria);
        }

        // GET: ProductoVeterinarias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoVeterinaria productoVeterinaria = db.ProductosVeterinarias.Find(id);
            if (productoVeterinaria == null)
            {
                return HttpNotFound();
            }
            return View(productoVeterinaria);
        }

        // POST: ProductoVeterinarias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,cantidad,descripcion")] ProductoVeterinaria productoVeterinaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productoVeterinaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productoVeterinaria);
        }

        // GET: ProductoVeterinarias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoVeterinaria productoVeterinaria = db.ProductosVeterinarias.Find(id);
            if (productoVeterinaria == null)
            {
                return HttpNotFound();
            }
            return View(productoVeterinaria);
        }

        // POST: ProductoVeterinarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductoVeterinaria productoVeterinaria = db.ProductosVeterinarias.Find(id);
            db.ProductosVeterinarias.Remove(productoVeterinaria);
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
