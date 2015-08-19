namespace AERHiPets.DAL.GestionAnimalesDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GA4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "especieID", c => c.Int());
            AddColumn("dbo.Animals", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Animals", "especieID");
            AddForeignKey("dbo.Animals", "especieID", "dbo.Especies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "especieID", "dbo.Especies");
            DropIndex("dbo.Animals", new[] { "especieID" });
            DropColumn("dbo.Animals", "Discriminator");
            DropColumn("dbo.Animals", "especieID");
        }
    }
}
