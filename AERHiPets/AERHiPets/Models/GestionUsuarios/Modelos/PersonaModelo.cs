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
        public RegisterViewModel registerViewModel { get; set; }
       
    }
}