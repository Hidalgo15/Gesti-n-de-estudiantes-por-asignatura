
namespace Gestión_de_estudiantes_por_asignatura.Core.Domain.Entities
{
    public abstract class Estudiante
    {
        //Clase padre estudiante, con propiedades comunes a ambos tipos de estudiantes (presencial y distancia)
        //y métodos para registrar calificaciones y calcular la nota final.
        public string Matricula { get; private set; }
        public string Nombre { get; private set; }
        public List<double> CalificacionesExamenes { get; protected set; }
        public List<double> CalificacionesPracticas { get; protected set; }

        protected Estudiante(string matricula, string nombre)
        {
            if (string.IsNullOrWhiteSpace(matricula)) throw new ArgumentException("La matrícula es requerida.");
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre es requerido.");

            Matricula = matricula;
            Nombre = nombre;
            CalificacionesExamenes = new List<double>();
            CalificacionesPracticas = new List<double>();
        }

        public void RegistrarExamen(double nota) => CalificacionesExamenes.Add(nota);
        public void RegistrarPractica(double nota) => CalificacionesPracticas.Add(nota);

        public abstract double CalcularNotaFinal();

        public bool ValidarAprobado() => CalcularNotaFinal() >= 70.0;

        public override string ToString()
        {
            return $"[Matrícula: {Matricula}] {Nombre,-25} | Nota Final: {CalcularNotaFinal(),6:F2} | Estado: {(ValidarAprobado() ? "APROBADO" : "REPROBADO")}";
        }
    }
}