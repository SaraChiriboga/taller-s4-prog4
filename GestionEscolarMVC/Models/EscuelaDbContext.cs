using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GestionEscolarMVC.Models
{
    public class EscuelaDbContext:DbContext
    {
        public EscuelaDbContext() : base("name=EscuelaDbContext") { }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Materia> Materias { get; set; }
    }
}