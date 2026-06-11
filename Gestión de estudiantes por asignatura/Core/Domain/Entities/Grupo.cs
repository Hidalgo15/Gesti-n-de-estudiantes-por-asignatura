
namespace Gestión_de_estudiantes_por_asignatura.Core.Domain.Entities
{
    public class Grupo
    {
        public string CodigoGrupo { get; private set; }
        private readonly List<Estudiante> _estudiantes;

        public Grupo(string codigoGrupo)
        {
            CodigoGrupo = codigoGrupo;
            _estudiantes = new List<Estudiante>();
        }

        public OperationResult AgregarEstudiante(Estudiante estudiante)
        {
            if (_estudiantes.Any(e => e.Matricula.Equals(estudiante.Matricula, StringComparison.OrdinalIgnoreCase)))
            {
                return OperationResult.BuildFailure($"La matrícula {estudiante.Matricula} ya existe en este grupo.");
            }

            _estudiantes.Add(estudiante);
            return OperationResult.BuildSuccess("Estudiante registrado con éxito.");
        }

        public List<Estudiante> ObtenerEstudiantes() => _estudiantes;

        public Estudiante BuscarEstudiante(string matricula)
        {
            return _estudiantes.FirstOrDefault(e => e.Matricula.Equals(matricula, StringComparison.OrdinalIgnoreCase));
        }

        // Método para calcular el porcentaje de estudiantes aprobados en el grupo
        public double CalcularPorcentajeAprobados()
        {
            if (_estudiantes.Count == 0) return 0.0;
            int aprobados = _estudiantes.Count(e => e.ValidarAprobado());
            return ((double)aprobados / _estudiantes.Count) * 100;
        }
    }
}
