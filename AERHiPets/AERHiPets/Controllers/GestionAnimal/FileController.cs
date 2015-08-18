using AERHiPets.DAL.GestionAnimalesDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AERHiPets.Controllers.GestionAnimal
{
    public class FileController : Controller
    {
        GestionAnimalDb db = new GestionAnimalDb();
        // GET: File
        public ActionResult Index(int id)
        {
            var fileToRetrieve = db.Files.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}