
namespace Gestión_de_estudiantes_por_asignatura.Core.Domain.Entities
{
    public class EstudiantePresencial : Estudiante
    {
        //Clase hija de estudiante, con implementación específica para calcular la nota final
        public EstudiantePresencial(string matricula, string nombre) : base(matricula, nombre)
        {
        }
        public override double CalcularNotaFinal()
        {
            double promedioExamenes = CalificacionesExamenes.Count > 0 ? CalificacionesExamenes.Average() : 0.0;
            double promedioPracticas = CalificacionesPracticas.Count > 0 ? CalificacionesPracticas.Average() : 0.0;
            return (promedioExamenes * 0.7) + (promedioPracticas * 0.3);
        }
    }
}