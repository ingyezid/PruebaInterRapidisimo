using Microsoft.EntityFrameworkCore;
using PruebaInterRapidisimo.Models;

namespace PruebaInterRapidisimo.DataContext
{
    public class ProjectContext : DbContext
    {
        protected readonly IConfiguration _config;

        public ProjectContext(IConfiguration configuration)
        {
            _config = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("conexionProject"));
        }

        public DbSet<Estudiante> Estudiantes { get; set; }

        public DbSet<Profesor> Profesores { get; set; }

        public DbSet<Materia> Materias { get; set; }

        public DbSet<EstudianteMateria> EstudianteMaterias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Estudiante>(estudiante =>
            {
                estudiante.ToTable("Estudiantes");
                estudiante.HasKey(e => e.Id);
                estudiante.HasIndex(e => e.Identificacion).IsUnique();
                estudiante.Property(e => e.Identificacion).IsRequired().HasMaxLength(10);
                estudiante.Property(e => e.Nombres).IsRequired().HasMaxLength(50);
                estudiante.Property(e => e.Apellidos).IsRequired().HasMaxLength(50);
                estudiante.Property(e => e.ProgramaCreditos).IsRequired();
                estudiante.HasMany(e => e.EstudianteMaterias).WithOne(em => em.Estudiante).HasForeignKey(em => em.EstudianteId);
            });

            modelBuilder.Entity<Profesor>(profesor =>
            {
                profesor.ToTable("Profesores");
                profesor.HasKey(p => p.Id);
                profesor.HasIndex(p => p.Identificacion).IsUnique();
                profesor.Property(p => p.Identificacion).IsRequired().HasMaxLength(10);
                profesor.Property(p => p.Nombres).IsRequired().HasMaxLength(50);
                profesor.Property(p => p.Apellidos).IsRequired().HasMaxLength(50);
                profesor.HasMany(p => p.Materias).WithOne(m => m.Profesor).HasForeignKey(m => m.ProfesorId);
            });

            modelBuilder.Entity<Materia>( materia =>
            {
                materia.ToTable("Materias");
                materia.HasKey(m => m.Id);
                materia.Property(m => m.Nombre).IsRequired().HasMaxLength(100);
                materia.Property(m => m.Creditos).IsRequired().HasDefaultValue(3);
                materia.Property(m => m.ProfesorId).IsRequired();
                materia.HasOne(materia => materia.Profesor).WithMany(profesor => profesor.Materias).HasForeignKey(m => m.ProfesorId);
                materia.HasMany(m => m.EstudianteMaterias).WithOne(em => em.Materia).HasForeignKey(em => em.MateriaId);
            });

            modelBuilder.Entity<EstudianteMateria>( estudianteMateria =>
            {
                estudianteMateria.ToTable("EstudianteMaterias");
                estudianteMateria.HasKey(em => em.Id);
                estudianteMateria.Property(em => em.EstudianteId).IsRequired();
                estudianteMateria.Property(em => em.MateriaId).IsRequired();
                estudianteMateria.HasIndex(em => new { em.EstudianteId, em.MateriaId }).IsUnique();
                estudianteMateria.HasOne(em => em.Estudiante).WithMany(e => e.EstudianteMaterias).HasForeignKey(em => em.EstudianteId);
                estudianteMateria.HasOne(em => em.Materia).WithMany(m => m.EstudianteMaterias).HasForeignKey(em => em.MateriaId);
            });

        }

    }
}
