using Microsoft.AspNet.Identity.EntityFramework;
using AERHiPets.Models.GestionUsuarios;
using System.Data.Entity;

namespace AERHiPets.DAL.GestionUsuariosDAL
{
    public class GestionUsuarioDb : IdentityDbContext<ApplicationUser>
    {
        public GestionUsuarioDb() : base("DefaultConnection")
        {
        }

        public static GestionUsuarioDb Create()
        {
            return new GestionUsuarioDb();
        }
        
    }
}

