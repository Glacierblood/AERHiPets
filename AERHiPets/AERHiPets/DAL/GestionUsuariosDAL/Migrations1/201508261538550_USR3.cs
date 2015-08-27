namespace AERHiPets.DAL.GestionUsuariosDAL.Migrations1
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class USR3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Personas", "Nombre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Personas", "Apellido", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Personas", "fechaAlta", c => c.DateTime());
            AlterColumn("dbo.Personas", "telefono", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Personas", "telefonoCel", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Direccions", "calle", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Direccions", "piso", c => c.String(maxLength: 50));
            AlterColumn("dbo.Direccions", "Torre", c => c.String(maxLength: 50));
            AlterColumn("dbo.Barrios", "nombre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Barrios", "codigoPostal", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Localidads", "nombre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Provincias", "nombre", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Provincias", "nombre", c => c.String());
            AlterColumn("dbo.Localidads", "nombre", c => c.String());
            AlterColumn("dbo.Barrios", "codigoPostal", c => c.String());
            AlterColumn("dbo.Barrios", "nombre", c => c.String());
            AlterColumn("dbo.Direccions", "Torre", c => c.Int(nullable: false));
            AlterColumn("dbo.Direccions", "piso", c => c.Int(nullable: false));
            AlterColumn("dbo.Direccions", "calle", c => c.String());
            AlterColumn("dbo.Personas", "telefonoCel", c => c.Int(nullable: false));
            AlterColumn("dbo.Personas", "telefono", c => c.Int(nullable: false));
            AlterColumn("dbo.Personas", "fechaAlta", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Personas", "Apellido", c => c.String());
            AlterColumn("dbo.Personas", "Nombre", c => c.String());
        }
    }
}
