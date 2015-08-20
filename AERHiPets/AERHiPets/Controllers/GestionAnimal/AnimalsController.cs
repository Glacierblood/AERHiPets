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
using AERHiPets.Models.GestionAnimal.GestionAnimalImagenes;
using System.IO;
using System.Data.Entity.Infrastructure;
using AERHiPets.Models.GestionAnimal.GestionAnimalModelos;

namespace AERHiPets.Controllers.GestionAnimal
{
    public class AnimalsController : Controller
    {
        private GestionAnimalDb db = new GestionAnimalDb();

        // GET: Animal
        public ActionResult Index()
        {

            var animales = db.Animales.Include(a => a.raza).Include(a => a.tamanio).Where(a => a.fechaBaja == null);
            var especies = db.Especies;
            AnimalModel modelo = new AnimalModel();
            modelo.animales = animales.ToList();
            modelo.especies = especies.ToList();
          
            return View(modelo);
        }

        // GET: Animal/Details/5
        /*Recibe como parametro el Id de un animal, comprueba que este no se encuentre nulo, de ser asi busca
         * y trae el animal de la BD, le incorpora la referencia a la entidad animal a la que apunta la FK razaId
         * Comprueba que el animal devuelto no sea null y devuelve a la vista para que se muestre*/
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animales.Find(id);
            animal.raza = db.Razas.Include(r => r.especie).SingleOrDefault(i => i.Id == animal.razaId);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: Animal/Create
        public ActionResult Create()
        {
            ViewBag.razaId = new SelectList(db.Razas, "Id", "nombre");
            ViewBag.tamanioId = new SelectList(db.Tamanios, "Id", "nombre");
            return View();
        }

        // POST: Animal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,fechaNac,caracteristicas,tamanioId,razaId,enAdopcion")] Animal animal, HttpPostedFileBase upload)
        {
            animal.fechaAlta = DateTime.Now;
            animal.edad = DateTime.Now.Year - animal.fechaNac.Year;
            try
                {
            
            if (ModelState.IsValid)//Verifica que el formulario sea valido
            {
                if (upload != null && upload.ContentLength > 0)//verifica se cargo una foto para en animal
                {
                    var avatar = new AERHiPets.Models.GestionAnimal.GestionAnimalImagenes.File//instancia la clase encargada de mapear la foto en la BD
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Avatar,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))//transforma la foto en una cadena de bytes para guardar en la BD
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    animal.Files = new List<AERHiPets.Models.GestionAnimal.GestionAnimalImagenes.File> { avatar };//aniade la referencia de la foto guardada al atributo correspondiente en animal
                }
                db.Animales.Add(animal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
    }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            ViewBag.razaId = new SelectList(db.Razas, "Id", "nombre", animal.razaId);
            ViewBag.tamanioId = new SelectList(db.Tamanios, "Id", "nombre", animal.tamanioId);
            return View(animal);
        }

        // GET: Animal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animales.Find(id);
            animal.raza = db.Razas.Include(r => r.especie).SingleOrDefault(i => i.Id == animal.razaId);
            if (animal == null)
            {
                return HttpNotFound();
            }
            ViewBag.razaId = new SelectList(db.Razas, "Id", "nombre", animal.razaId);
            ViewBag.tamanioId = new SelectList(db.Tamanios, "Id", "nombre", animal.tamanioId);
            return View(animal);
        }

        // POST: Animal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,fechaNac,caracteristicas,tamanioId,razaId,enAdopcion")] Animal animal, HttpPostedFileBase upload)
        {
            animal.fechaAlta = DateTime.Now;
            animal.edad = DateTime.Now.Year - animal.fechaNac.Year;
            
            var animalToUpdate = db.Animales.Find(animal.Id);
            animalToUpdate.nombre = animal.nombre;
            animalToUpdate.fechaNac = animal.fechaNac;
            animalToUpdate.caracteristicas = animal.caracteristicas;
            animalToUpdate.tamanioId = animal.tamanioId;
            animalToUpdate.razaId = animal.razaId;
            animalToUpdate.enAdopcion = animal.enAdopcion;
            animalToUpdate.edad = animal.edad;
            animalToUpdate.fechaAlta = animal.fechaAlta;

            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    if (animalToUpdate.Files.Any(f => f.FileType == FileType.Avatar))
                    {
                        db.Files.Remove(animalToUpdate.Files.First(f => f.FileType == FileType.Avatar));
                    }
                    var avatar = new AERHiPets.Models.GestionAnimal.GestionAnimalImagenes.File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Avatar,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    animalToUpdate.Files = new List<AERHiPets.Models.GestionAnimal.GestionAnimalImagenes.File> { avatar };
                }
                db.Entry(animalToUpdate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.razaId = new SelectList(db.Razas, "Id", "nombre", animal.razaId);
            ViewBag.tamanioId = new SelectList(db.Tamanios, "Id", "nombre", animal.tamanioId);
            return View(animal);
        }

        // GET: Animal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animales.Find(id);
            animal.raza = db.Razas.Include(r => r.especie).SingleOrDefault(i => i.Id == animal.razaId);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animal animal = db.Animales.Find(id);
            animal.fechaBaja = System.DateTime.Now;
            db.Entry(animal).State = EntityState.Modified;
            //db.Animales.Remove(animal);
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

        public ActionResult getEspecies()
        {
            //AerDb db = new AerDb();
            var especies = db.Especies
                .Select(e => new { e.Id, e.nombre })
                .OrderBy(e => e.nombre);
            return Json(especies, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getRazas(int intEspID)
        {

            //AerDb db = new AerDb();
            var razas = db.Razas
                .Where(p => p.especieID == intEspID)
                .Select(p => new { p.Id, p.nombre })
                .OrderBy(p => p.nombre);
            return Json(razas, JsonRequestBehavior.AllowGet);
        }
    }
}
