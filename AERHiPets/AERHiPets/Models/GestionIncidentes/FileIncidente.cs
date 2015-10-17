using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionIncidentes
{
    public class FileIncidente
    {
       
            public int FileIncidenteId { get; set; }
            [StringLength(255)]
            public string FileName { get; set; }
            [StringLength(100)]
            public string ContentType { get; set; }
            public byte[] Content { get; set; }
            public FileTypeIncidente FileType { get; set; }
            public int incidentelId { get; set; }
            public virtual Incidente incidente { get; set; }
       
    }
}