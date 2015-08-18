namespace AERHiPets.DAL.GestionAnimalesDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GA3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        animalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Animals", t => t.animalId, cascadeDelete: true)
                .Index(t => t.animalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "animalId", "dbo.Animals");
            DropIndex("dbo.Files", new[] { "animalId" });
            DropTable("dbo.Files");
        }
    }
}
