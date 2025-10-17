namespace GestionEscolarMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estudiantes",
                c => new
                    {
                        EstudianteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EstudianteId);
            
            CreateTable(
                "dbo.Materias",
                c => new
                    {
                        MateriaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MateriaId);
            
            CreateTable(
                "dbo.MateriaEstudiantes",
                c => new
                    {
                        Materia_MateriaId = c.Int(nullable: false),
                        Estudiante_EstudianteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Materia_MateriaId, t.Estudiante_EstudianteId })
                .ForeignKey("dbo.Materias", t => t.Materia_MateriaId, cascadeDelete: true)
                .ForeignKey("dbo.Estudiantes", t => t.Estudiante_EstudianteId, cascadeDelete: true)
                .Index(t => t.Materia_MateriaId)
                .Index(t => t.Estudiante_EstudianteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MateriaEstudiantes", "Estudiante_EstudianteId", "dbo.Estudiantes");
            DropForeignKey("dbo.MateriaEstudiantes", "Materia_MateriaId", "dbo.Materias");
            DropIndex("dbo.MateriaEstudiantes", new[] { "Estudiante_EstudianteId" });
            DropIndex("dbo.MateriaEstudiantes", new[] { "Materia_MateriaId" });
            DropTable("dbo.MateriaEstudiantes");
            DropTable("dbo.Materias");
            DropTable("dbo.Estudiantes");
        }
    }
}
