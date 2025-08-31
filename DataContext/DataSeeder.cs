using PruebaInterRapidisimo.Models;
using static PruebaInterRapidisimo.Enums.UtilEnums;

namespace PruebaInterRapidisimo.DataContext
{
    public static class DataSeeder
    {
        public static void Seed(ProjectContext context)
        {
            if (context == null)
            {
                return;
            }

            if (!context.Estudiantes.Any())
            {
                context.Estudiantes.AddRange(
                    new Estudiante { Id = Guid.Parse("a154637f-7f82-404c-acc9-92c42b7ff111"), Identificacion = "00000101", Nombres = "Sara", Apellidos = "Godoy", ProgramaCreditos = ProgramaCreditos.IngenieriaElectronica },
                    new Estudiante { Id = Guid.Parse("a154637f-7f82-404c-acc9-92c42b7ff222"), Identificacion = "00000102", Nombres = "Hernan", Apellidos = "Orjuela", ProgramaCreditos = ProgramaCreditos.IngenieriaMecanica },
                    new Estudiante { Id = Guid.Parse("a154637f-7f82-404c-acc9-92c42b7ff333"), Identificacion = "00000103", Nombres = "Patricia", Apellidos = "Fernandez", ProgramaCreditos = ProgramaCreditos.IngenieriaQuimica }
                );

            }

            if (!context.Profesores.Any())
            {
                context.Profesores.AddRange(
                    new Profesor { Id = Guid.Parse("fe757115-2619-4483-8171-371453d36111"), Identificacion = "10000111", Nombres = "Alberto", Apellidos = "Herrera" },
                    new Profesor { Id = Guid.Parse("fe757115-2619-4483-8171-371453d36222"), Identificacion = "10000222", Nombres = "Juan", Apellidos = "Pinzon" },
                    new Profesor { Id = Guid.Parse("fe757115-2619-4483-8171-371453d36333"), Identificacion = "10000333", Nombres = "Maria", Apellidos = "Estrella" },
                    new Profesor { Id = Guid.Parse("fe757115-2619-4483-8171-371453d36444"), Identificacion = "10000444", Nombres = "Alexandra", Apellidos = "Cifuentes" },
                    new Profesor { Id = Guid.Parse("fe757115-2619-4483-8171-371453d36555"), Identificacion = "10000555", Nombres = "Pedro", Apellidos = "Cordoba" }
                );

            }

            if (!context.Materias.Any())
            {
                context.Materias.AddRange(
                    new Materia() { Id = Guid.Parse("06a1dfd3-0754-4730-adc7-5d8d587b6111"), ProfesorId = Guid.Parse("fe757115-2619-4483-8171-371453d36111"), Nombre = "Cálculo Diferencial" },
                    new Materia() { Id = Guid.Parse("06a1dfd3-0754-4730-adc7-5d8d587b6222"), ProfesorId = Guid.Parse("fe757115-2619-4483-8171-371453d36111"), Nombre = "Algebra Lineal" },
                    new Materia() { Id = Guid.Parse("06a1dfd3-0754-4730-adc7-5d8d587b6333"), ProfesorId = Guid.Parse("fe757115-2619-4483-8171-371453d36222"), Nombre = "Modelado de Sistemas de Información" },
                    new Materia() { Id = Guid.Parse("06a1dfd3-0754-4730-adc7-5d8d587b6444"), ProfesorId = Guid.Parse("fe757115-2619-4483-8171-371453d36222"), Nombre = "Programación de Computadores" },
                    new Materia() { Id = Guid.Parse("06a1dfd3-0754-4730-adc7-5d8d587b6555"), ProfesorId = Guid.Parse("fe757115-2619-4483-8171-371453d36333"), Nombre = "Química Básica" },
                    new Materia() { Id = Guid.Parse("06a1dfd3-0754-4730-adc7-5d8d587b6666"), ProfesorId = Guid.Parse("fe757115-2619-4483-8171-371453d36333"), Nombre = "Biología Básica" },
                    new Materia() { Id = Guid.Parse("06a1dfd3-0754-4730-adc7-5d8d587b6777"), ProfesorId = Guid.Parse("fe757115-2619-4483-8171-371453d36444"), Nombre = "Analisis de Circuitos" },
                    new Materia() { Id = Guid.Parse("06a1dfd3-0754-4730-adc7-5d8d587b6888"), ProfesorId = Guid.Parse("fe757115-2619-4483-8171-371453d36444"), Nombre = "Electronica Básica" },
                    new Materia() { Id = Guid.Parse("06a1dfd3-0754-4730-adc7-5d8d587b6999"), ProfesorId = Guid.Parse("fe757115-2619-4483-8171-371453d36555"), Nombre = "Ingles" },
                    new Materia() { Id = Guid.Parse("06a1dfd3-0754-4730-adc7-5d8d587b6000"), ProfesorId = Guid.Parse("fe757115-2619-4483-8171-371453d36555"), Nombre = "Francés" }
                );
            }

            if (!context.EstudianteMaterias.Any())
            {
                context.EstudianteMaterias.AddRange(

                    new EstudianteMateria { Id = Guid.Parse("5ce8e837-d434-4acc-8e9a-024d33c42111"), EstudianteId = Guid.Parse("a154637f-7f82-404c-acc9-92c42b7ff111"), MateriaId = Guid.Parse("06a1dfd3-0754-4730-adc7-5d8d587b6222") },
                    new EstudianteMateria { Id = Guid.Parse("5ce8e837-d434-4acc-8e9a-024d33c42222"), EstudianteId = Guid.Parse("a154637f-7f82-404c-acc9-92c42b7ff111"), MateriaId = Guid.Parse("06a1dfd3-0754-4730-adc7-5d8d587b6888") },
                    new EstudianteMateria { Id = Guid.Parse("5ce8e837-d434-4acc-8e9a-024d33c42333"), EstudianteId = Guid.Parse("a154637f-7f82-404c-acc9-92c42b7ff111"), MateriaId = Guid.Parse("06a1dfd3-0754-4730-adc7-5d8d587b6000") },
                    new EstudianteMateria { Id = Guid.Parse("5ce8e837-d434-4acc-8e9a-024d33c42444"), EstudianteId = Guid.Parse("a154637f-7f82-404c-acc9-92c42b7ff222"), MateriaId = Guid.Parse("06a1dfd3-0754-4730-adc7-5d8d587b6222") },
                    new EstudianteMateria { Id = Guid.Parse("5ce8e837-d434-4acc-8e9a-024d33c42555"), EstudianteId = Guid.Parse("a154637f-7f82-404c-acc9-92c42b7ff222"), MateriaId = Guid.Parse("06a1dfd3-0754-4730-adc7-5d8d587b6777") },
                    new EstudianteMateria { Id = Guid.Parse("5ce8e837-d434-4acc-8e9a-024d33c42666"), EstudianteId = Guid.Parse("a154637f-7f82-404c-acc9-92c42b7ff222"), MateriaId = Guid.Parse("06a1dfd3-0754-4730-adc7-5d8d587b6999") },
                    new EstudianteMateria { Id = Guid.Parse("5ce8e837-d434-4acc-8e9a-024d33c42777"), EstudianteId = Guid.Parse("a154637f-7f82-404c-acc9-92c42b7ff333"), MateriaId = Guid.Parse("06a1dfd3-0754-4730-adc7-5d8d587b6111") },
                    new EstudianteMateria { Id = Guid.Parse("5ce8e837-d434-4acc-8e9a-024d33c42888"), EstudianteId = Guid.Parse("a154637f-7f82-404c-acc9-92c42b7ff333"), MateriaId = Guid.Parse("06a1dfd3-0754-4730-adc7-5d8d587b6555") },
                    new EstudianteMateria { Id = Guid.Parse("5ce8e837-d434-4acc-8e9a-024d33c42999"), EstudianteId = Guid.Parse("a154637f-7f82-404c-acc9-92c42b7ff333"), MateriaId = Guid.Parse("06a1dfd3-0754-4730-adc7-5d8d587b6999") }
                );
            }

            context.SaveChanges();

        }
    }
}
