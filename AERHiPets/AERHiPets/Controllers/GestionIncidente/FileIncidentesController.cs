using AERHiPets.DAL.GestionAdopcionApadrinamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AERHiPets.Controllers.GestionIncidente
{
    public class FileIncidentesController : Controller
    {
        GestionAdopApaDb db = new GestionAdopApaDb();
        // GET: File
        public ActionResult Index(int id)
        {
            var fileToRetrieve = db.FileIncidentes.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
        
    }
}