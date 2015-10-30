using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AERHiPets.DAL.GestionAdopcionApadrinamiento;
using AERHiPets.Models.GestionIncidentes;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Infrastructure;
using AERHiPets.DAL.GestionVoluntariosDAL;
using AERHiPets.Models.GestionUsuarios;
using System.Net.Mail;

namespace AERHiPets.Controllers.GestionIncidente
{
    public class IncidentesController : Controller
    {
        private GestionAdopApaDb db = new GestionAdopApaDb();

        // GET: Incidentes
        public ActionResult Index()
        {
            var incidentes = db.Incidentes.Include(i => i.Especie).Include(i => i.estadoIncidente).Include(i => i.raza).Include(i => i.tamanio).Include(i => i.tipoIncidente).Where(i => i.estadoIncidenteId == 1);
            ViewBag.especieId = new SelectList(db.Especies, "Id", "nombre");
            ViewBag.estadoIncidenteId = new SelectList(db.estadoIncidentes, "Id", "estadoInc");
            ViewBag.razaId = new SelectList(db.Razas, "Id", "nombre");
            ViewBag.tamanioId = new SelectList(db.Tamanios, "Id", "nombre");
            ViewBag.tipoIncidenteId = new SelectList(db.TipoIncidentes, "Id", "tipoIncidente");
            return View(incidentes.ToList());
        }

        // GET: Incidentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidente incidente = db.Incidentes.Find(id);
            incidente.raza = db.Razas.Include(r => r.especie).SingleOrDefault(i => i.Id == incidente.razaId);
            incidente.Especie = db.Especies.SingleOrDefault(i => i.Id == incidente.especieId);
            incidente.tamanio = db.Tamanios.SingleOrDefault(i => i.Id == incidente.tamanioId);
            incidente.estadoIncidente = db.estadoIncidentes.SingleOrDefault(i => i.Id == incidente.estadoIncidenteId);
            incidente.tipoIncidente = db.TipoIncidentes.SingleOrDefault(i => i.Id == incidente.tipoIncidenteId);
            if (incidente == null)
            {
                return HttpNotFound();
            }
            return View(incidente);
        }

        [HttpPost, ActionName("Detalle")]
        [ValidateAntiForgeryToken]
        public ActionResult Detalle(int? id, String usrId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidente incidente = db.Incidentes.Find(id);
            if (incidente == null)
            {
                return HttpNotFound();
            }
            incidente.estadoIncidenteId = 2;
            incidente.VoluntarioSolucionUsrId = usrId;
            db.Entry(incidente).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            //return View(incidente);
        }



        // GET: Incidentes/Create
        public ActionResult Create()
        {
            Incidente incidente = new Incidente();
            if (HttpContext.User != null)
            {   
                var UsrName = User.Identity.GetUserId();
                if (UsrName != null) { 
                
                GestionVoluntarioDb dbGV = new GestionVoluntarioDb();
                Persona per = dbGV.personas.FirstOrDefault(p => p.UsrId == UsrName);
                incidente.Apellido = per.Apellido;
                incidente.Nombre = per.Nombre;
                incidente.telefono = per.telefonoCel;
                incidente.calle = per.calleGmaps;
                incidente.Email = User.Identity.Name;
                }
            }

            ViewBag.especieId = new SelectList(db.Especies, "Id", "nombre");
            ViewBag.estadoIncidenteId = new SelectList(db.estadoIncidentes, "Id", "estadoInc");
            ViewBag.razaId = new SelectList(db.Razas, "Id", "nombre");
            ViewBag.tamanioId = new SelectList(db.Tamanios, "Id", "nombre");
            ViewBag.tipoIncidenteId = new SelectList(db.TipoIncidentes, "Id", "tipoIncidente");
            return View(incidente);
        }

        // POST: Incidentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,descripcion,tamanioId,razaId,especieId,Nombre,Apellido,telefono,fechaFin,fechaAlta,fechaBaja,estadoIncidenteId,tipoIncidenteId,calle,lat,lng,VoluntarioUsrId")] Incidente incidente, HttpPostedFileBase upload)
        {
            incidente.fechaAlta = DateTime.Now;
            incidente.estadoIncidenteId = 1;
            try{
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)//verifica se cargo una foto para en animal
                {
                    var avatar = new AERHiPets.Models.GestionIncidentes.FileIncidente//instancia la clase encargada de mapear la foto en la BD
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileTypeIncidente.Avatar,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))//transforma la foto en una cadena de bytes para guardar en la BD
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    incidente.Files = new List<AERHiPets.Models.GestionIncidentes.FileIncidente> { avatar };//aniade la referencia de la foto guardada al atributo correspondiente en animal
                }
                db.Incidentes.Add(incidente);
                db.SaveChanges();

                //---------------------------------------------------------------------------------------

                System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage();
                m.Sender = new System.Net.Mail.MailAddress("AERHiPets@outlook.com", "Web Registration");
                //m.          new System.Net.Mail.MailAddress(User.Identity.Name));
                GestionVoluntarioDb dbV = new GestionVoluntarioDb();
                var mailList = dbV.personas.Select(p => p.email);
                foreach (String mail in mailList)
                {
                    m.Bcc.Add(mail);
                }
                
                m.Subject = "Nuevo incidente";
                String url = "Https://localhost:44300/Incidentes/Details/" + incidente.Id;
                m.Body = string.Format("Estimado<BR/> Ha ocurrido un nuevo incidente al que usted podria atender, haga click en el siguente link  "+url+"");
                m.IsBodyHtml = true;
                m.From = new System.Net.Mail.MailAddress("AERHiPets@outlook.com");
                SmtpClient smtp = new SmtpClient();
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("AERHiPets@outlook.com", "1Mucho+Facil");
                smtp.Host = "smtp.live.com";

                smtp.Send(m);
                //---------------------------------------------------------------------------------------

                
                return RedirectToAction("Index");
            }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            ViewBag.especieId = new SelectList(db.Especies, "Id", "nombre", incidente.especieId);
            ViewBag.estadoIncidenteId = new SelectList(db.estadoIncidentes, "Id", "estadoInc", incidente.estadoIncidenteId);
            ViewBag.razaId = new SelectList(db.Razas, "Id", "nombre", incidente.razaId);
            ViewBag.tamanioId = new SelectList(db.Tamanios, "Id", "nombre", incidente.tamanioId);
            ViewBag.tipoIncidenteId = new SelectList(db.TipoIncidentes, "Id", "tipoIncidente", incidente.tipoIncidenteId);
            return View(incidente);
        }

        // GET: Incidentes/Edit/5
        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidente incidente = db.Incidentes.Find(id);
            
            if (incidente == null)
            {
                return HttpNotFound();
            }
            ViewBag.especieActual = incidente.especieId;
            ViewBag.razaActual = incidente.razaId;
            ViewBag.especieId = new SelectList(db.Especies, "Id", "nombre", incidente.especieId);
            ViewBag.estadoIncidenteId = new SelectList(db.estadoIncidentes, "Id", "estadoInc", incidente.estadoIncidenteId);
            ViewBag.razaId = new SelectList(db.Razas, "Id", "nombre", incidente.razaId);
            ViewBag.tamanioId = new SelectList(db.Tamanios, "Id", "nombre", incidente.tamanioId);
            ViewBag.tipoIncidenteId = new SelectList(db.TipoIncidentes, "Id", "tipoIncidente", incidente.tipoIncidenteId);
            return View(incidente);
        }

        // POST: Incidentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,descripcion,tamanioId,razaId,especieId,Nombre,Apellido,telefono,fechaFin,fechaBaja,estadoIncidenteId,tipoIncidenteId,calleGmaps,lat,lng")] Incidente incidente, HttpPostedFileBase upload)
        {
            incidente.fechaAlta = DateTime.Now;
            

            var animalToUpdate = db.Incidentes.Find(incidente.Id);
            animalToUpdate.Email = incidente.Email;
            animalToUpdate.descripcion = incidente.descripcion;
            animalToUpdate.tamanioId = incidente.tamanioId;
            animalToUpdate.especieId = incidente.especieId;
            animalToUpdate.razaId = incidente.razaId;
            animalToUpdate.Nombre = incidente.Nombre;
            animalToUpdate.Apellido = incidente.Apellido;
            animalToUpdate.telefono = incidente.telefono;
            animalToUpdate.estadoIncidenteId = incidente.estadoIncidenteId;
            animalToUpdate.tipoIncidenteId = incidente.tipoIncidenteId;

            if (incidente.estadoIncidenteId == 3) {
                incidente.fechaBaja = DateTime.Now;
            } else if (incidente.estadoIncidenteId == 4) {
                incidente.fechaFin = DateTime.Now;
            }

            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    if (animalToUpdate.Files.Any(f => f.FileType == FileTypeIncidente.Avatar))
                    {
                        db.FileIncidentes.Remove(animalToUpdate.Files.First(f => f.FileType == FileTypeIncidente.Avatar));
                    }
                    var avatar = new AERHiPets.Models.GestionIncidentes.FileIncidente
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileTypeIncidente.Avatar,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    animalToUpdate.Files = new List<AERHiPets.Models.GestionIncidentes.FileIncidente> { avatar };
                }
                db.Entry(animalToUpdate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.especieId = new SelectList(db.Especies, "Id", "nombre", incidente.especieId);
            ViewBag.estadoIncidenteId = new SelectList(db.estadoIncidentes, "Id", "estadoInc", incidente.estadoIncidenteId);
            ViewBag.razaId = new SelectList(db.Razas, "Id", "nombre", incidente.razaId);
            ViewBag.tamanioId = new SelectList(db.Tamanios, "Id", "nombre", incidente.tamanioId);
            ViewBag.tipoIncidenteId = new SelectList(db.TipoIncidentes, "Id", "tipoIncidente", incidente.tipoIncidenteId);
            return View(incidente);
        }

        // GET: Incidentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidente incidente = db.Incidentes.Find(id);
            if (incidente == null)
            {
                return HttpNotFound();
            }
            return View(incidente);
        }

        // POST: Incidentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Incidente incidente = db.Incidentes.Find(id);
            db.Incidentes.Remove(incidente);
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
                .Where(e => e.fechaBaja == null)
                .Select(e => new { e.Id, e.nombre })
                .OrderBy(e => e.nombre);
            return Json(especies, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getRazas(int intEspID)
        {

            //AerDb db = new AerDb();
            var razas = db.Razas
                .Where(p => p.especieID == intEspID)
                .Where(p => p.fechaBaja == null)
                .Select(p => new { p.Id, p.nombre })
                .OrderBy(p => p.nombre);
            return Json(razas, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getLatLng()
        {

            //AerDb db = new AerDb();
            var razas = db.Incidentes
                .Where(p => p.fechaBaja == null)
                .Where(p => p.estadoIncidenteId == 1)
                .Select(p => new { p.Id, p.lat, p.lng, p.calle, p.descripcion});
            return Json(razas, JsonRequestBehavior.AllowGet);
        }
    }
}
