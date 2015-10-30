namespace AERHiPets.DAL.GestionVoluntariosDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VOL7 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Localidads", newName: "Localidades");
            CreateTable(
                "dbo.Paises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        pais_nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Provincias", "paisId", c => c.Int());
            CreateIndex("dbo.Provincias", "paisId");
            AddForeignKey("dbo.Provincias", "paisId", "dbo.Paises", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Provincias", "paisId", "dbo.Paises");
            DropIndex("dbo.Provincias", new[] { "paisId" });
            DropColumn("dbo.Provincias", "paisId");
            DropTable("dbo.Paises");
            RenameTable(name: "dbo.Localidades", newName: "Localidads");
        }
    }
}
