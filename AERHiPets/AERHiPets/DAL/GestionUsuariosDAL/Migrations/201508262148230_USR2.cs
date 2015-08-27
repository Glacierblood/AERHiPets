namespace AERHiPets.DAL.GestionUsuariosDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class USR2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "personaId", "dbo.Personas");
            DropIndex("dbo.AspNetUsers", new[] { "personaId" });
            AlterColumn("dbo.AspNetUsers", "personaId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "personaId");
            AddForeignKey("dbo.AspNetUsers", "personaId", "dbo.Personas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "personaId", "dbo.Personas");
            DropIndex("dbo.AspNetUsers", new[] { "personaId" });
            AlterColumn("dbo.AspNetUsers", "personaId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "personaId");
            AddForeignKey("dbo.AspNetUsers", "personaId", "dbo.Personas", "Id", cascadeDelete: true);
        }
    }
}
