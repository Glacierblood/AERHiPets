namespace AERHiPets.DAL.GestionAnimalesDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GA2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FilePaths",
                c => new
                    {
                        FilePathId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        FileType = c.Int(nullable: false),
                        animalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilePathId)
                .ForeignKey("dbo.Animals", t => t.animalId, cascadeDelete: true)
                .Index(t => t.animalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilePaths", "animalId", "dbo.Animals");
            DropIndex("dbo.FilePaths", new[] { "animalId" });
            DropTable("dbo.FilePaths");
        }
    }
}
