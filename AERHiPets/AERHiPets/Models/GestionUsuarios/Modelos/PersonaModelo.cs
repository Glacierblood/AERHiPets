using AERHiPets.Models.GestionDireccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionUsuarios.Modelos
{
    public class PersonaModelo
    {
        public Persona persona { get; set; }
        public List<Acciones> listaAcciones { get; set; }
        public RegistroAcciones MyProperty { get; set; }
        public RegisterViewModel registerViewModel { get; set; }
        public Direccion direccion { get; set; }
        public Barrio barrio { get; set; }
        public Localidad localidad { get; set; }
        public Provincia provincia { get; set; }
    }
}