namespace AERHiPets.DAL.GestionUsuariosDAL.Migrations1
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class USR1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        personaId = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personas", t => t.personaId, cascadeDelete: true)
                .Index(t => t.personaId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        fechaNac = c.DateTime(nullable: false),
                        fechaAlta = c.DateTime(nullable: false),
                        fechaBaja = c.DateTime(),
                        telefono = c.Int(nullable: false),
                        telefonoCel = c.Int(nullable: false),
                        puntaje = c.Int(nullable: false),
                        direccionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Direccions", t => t.direccionId, cascadeDelete: true)
                .Index(t => t.direccionId);
            
            CreateTable(
                "dbo.Direccions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        barrioId = c.Int(nullable: false),
                        calle = c.String(),
                        piso = c.Int(nullable: false),
                        Torre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Barrios", t => t.barrioId, cascadeDelete: true)
                .Index(t => t.barrioId);
            
            CreateTable(
                "dbo.Barrios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        codigoPostal = c.String(),
                        localidadId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Localidads", t => t.localidadId, cascadeDelete: true)
                .Index(t => t.localidadId);
            
            CreateTable(
                "dbo.Localidads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        provinviaId = c.Int(nullable: false),
                        provincia_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provincias", t => t.provincia_Id)
                .Index(t => t.provincia_Id);
            
            CreateTable(
                "dbo.Provincias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RegistroAcciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fechaAlta = c.DateTime(nullable: false),
                        fechcaBaja = c.DateTime(),
                        comentario = c.String(),
                        personaId = c.Int(nullable: false),
                        accionesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Acciones", t => t.accionesId, cascadeDelete: true)
                .ForeignKey("dbo.Personas", t => t.personaId, cascadeDelete: true)
                .Index(t => t.personaId)
                .Index(t => t.accionesId);
            
            CreateTable(
                "dbo.Acciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                        isSelected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "personaId", "dbo.Personas");
            DropForeignKey("dbo.RegistroAcciones", "personaId", "dbo.Personas");
            DropForeignKey("dbo.RegistroAcciones", "accionesId", "dbo.Acciones");
            DropForeignKey("dbo.Personas", "direccionId", "dbo.Direccions");
            DropForeignKey("dbo.Direccions", "barrioId", "dbo.Barrios");
            DropForeignKey("dbo.Barrios", "localidadId", "dbo.Localidads");
            DropForeignKey("dbo.Localidads", "provincia_Id", "dbo.Provincias");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.RegistroAcciones", new[] { "accionesId" });
            DropIndex("dbo.RegistroAcciones", new[] { "personaId" });
            DropIndex("dbo.Localidads", new[] { "provincia_Id" });
            DropIndex("dbo.Barrios", new[] { "localidadId" });
            DropIndex("dbo.Direccions", new[] { "barrioId" });
            DropIndex("dbo.Personas", new[] { "direccionId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "personaId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.Acciones");
            DropTable("dbo.RegistroAcciones");
            DropTable("dbo.Provincias");
            DropTable("dbo.Localidads");
            DropTable("dbo.Barrios");
            DropTable("dbo.Direccions");
            DropTable("dbo.Personas");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
