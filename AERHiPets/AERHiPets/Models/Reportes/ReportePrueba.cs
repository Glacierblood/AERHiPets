using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.Reportes
{
    public class ReportePrueba
    {
        public Nullable<int> tipoIncidenteId { get; set; }
        public string Zona { get; set; }
        public string tipoIncidente { get; set; }
        public Nullable<int> especieId { get; set; }
        public string nombre { get; set; }
    }
}