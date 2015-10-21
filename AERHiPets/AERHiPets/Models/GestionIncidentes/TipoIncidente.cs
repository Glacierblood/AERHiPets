using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionIncidentes
{
	public class TipoIncidente
	{
    public int Id { get; set; }
    public String tipoIncidente { get; set; }
    public String descripcion { get; set; }
	}
}