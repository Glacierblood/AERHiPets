using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionAnimal.GestionAnimalImagenes
{
    public class FilePath
    {
        public int FilePathId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        public FileType FileType { get; set; }

        public int animalId { get; set; }
        public virtual Animal animal { get; set; }
    }
}