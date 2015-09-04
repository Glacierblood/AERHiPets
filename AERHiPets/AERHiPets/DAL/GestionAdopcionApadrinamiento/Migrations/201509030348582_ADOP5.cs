namespace AERHiPets.DAL.GestionAdopcionApadrinamiento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADOP5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Adopcions", "animalId", "dbo.Animals");
            DropForeignKey("dbo.Adopcions", "direccionId", "dbo.Direccions");
            DropForeignKey("dbo.Adopcions", "estadoAdopcionId", "dbo.EstadoAdopcions");
            DropForeignKey("dbo.Adopcions", "tipoAdopcionId", "dbo.TipoAdopcions");
            DropIndex("dbo.Adopcions", new[] { "animalId" });
            DropIndex("dbo.Adopcions", new[] { "estadoAdopcionId" });
            DropIndex("dbo.Adopcions", new[] { "tipoAdopcionId" });
            DropIndex("dbo.Adopcions", new[] { "direccionId" });
            AlterColumn("dbo.Adopcions", "animalId", c => c.Int());
            AlterColumn("dbo.Adopcions", "dias", c => c.Int());
            AlterColumn("dbo.Adopcions", "estadoAdopcionId", c => c.Int());
            AlterColumn("dbo.Adopcions", "tipoAdopcionId", c => c.Int());
            AlterColumn("dbo.Adopcions", "direccionId", c => c.Int());
            CreateIndex("dbo.Adopcions", "animalId");
            CreateIndex("dbo.Adopcions", "estadoAdopcionId");
            CreateIndex("dbo.Adopcions", "tipoAdopcionId");
            CreateIndex("dbo.Adopcions", "direccionId");
            AddForeignKey("dbo.Adopcions", "animalId", "dbo.Animals", "Id");
            AddForeignKey("dbo.Adopcions", "direccionId", "dbo.Direccions", "Id");
            AddForeignKey("dbo.Adopcions", "estadoAdopcionId", "dbo.EstadoAdopcions", "Id");
            AddForeignKey("dbo.Adopcions", "tipoAdopcionId", "dbo.TipoAdopcions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Adopcions", "tipoAdopcionId", "dbo.TipoAdopcions");
            DropForeignKey("dbo.Adopcions", "estadoAdopcionId", "dbo.EstadoAdopcions");
            DropForeignKey("dbo.Adopcions", "direccionId", "dbo.Direccions");
            DropForeignKey("dbo.Adopcions", "animalId", "dbo.Animals");
            DropIndex("dbo.Adopcions", new[] { "direccionId" });
            DropIndex("dbo.Adopcions", new[] { "tipoAdopcionId" });
            DropIndex("dbo.Adopcions", new[] { "estadoAdopcionId" });
            DropIndex("dbo.Adopcions", new[] { "animalId" });
            AlterColumn("dbo.Adopcions", "direccionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Adopcions", "tipoAdopcionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Adopcions", "estadoAdopcionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Adopcions", "dias", c => c.Int(nullable: false));
            AlterColumn("dbo.Adopcions", "animalId", c => c.Int(nullable: false));
            CreateIndex("dbo.Adopcions", "direccionId");
            CreateIndex("dbo.Adopcions", "tipoAdopcionId");
            CreateIndex("dbo.Adopcions", "estadoAdopcionId");
            CreateIndex("dbo.Adopcions", "animalId");
            AddForeignKey("dbo.Adopcions", "tipoAdopcionId", "dbo.TipoAdopcions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Adopcions", "estadoAdopcionId", "dbo.EstadoAdopcions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Adopcions", "direccionId", "dbo.Direccions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Adopcions", "animalId", "dbo.Animals", "Id", cascadeDelete: true);
        }
    }
}
