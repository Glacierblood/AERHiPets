namespace AERHiPets.DAL.GestionAnimalesDAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AERHiPets.DAL.GestionAnimalesDAL.GestionAnimalDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DAL\GestionAnimalesDAL\Migrations";
            ContextKey = "AERHiPets.DAL.GestionAnimalesDAL.GestionAnimalDb";
        }

        protected override void Seed(AERHiPets.DAL.GestionAnimalesDAL.GestionAnimalDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
