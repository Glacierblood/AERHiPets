namespace AERHiPets.DAL.GestionAdopcionApadrinamiento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADOP27 : DbMigration
    {
        public override void Up()
        {
            /*RenameTable(name: "dbo.Localidads", newName: "Localidades");
            CreateTable(
                "dbo.Paises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        pais_nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Provincias", "paisId", c => c.Int());*/
            AddColumn("dbo.Incidentes", "barrioId", c => c.Int());
           /* CreateIndex("dbo.Provincias", "paisId");*/
            CreateIndex("dbo.Incidentes", "barrioId");
           /* AddForeignKey("dbo.Provincias", "paisId", "dbo.Paises", "Id");*/
            AddForeignKey("dbo.Incidentes", "barrioId", "dbo.Barrios", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incidentes", "barrioId", "dbo.Barrios");
           /* DropForeignKey("dbo.Provincias", "paisId", "dbo.Paises");*/
            DropIndex("dbo.Incidentes", new[] { "barrioId" });
           // DropIndex("dbo.Provincias", new[] { "paisId" });
            DropColumn("dbo.Incidentes", "barrioId");
           // DropColumn("dbo.Provincias", "paisId");
           // DropTable("dbo.Paises");
           // RenameTable(name: "dbo.Localidades", newName: "Localidads");
        }
    }
}
