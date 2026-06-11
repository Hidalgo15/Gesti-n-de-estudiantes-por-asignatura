
using Gestión_de_estudiantes_por_asignatura.Core.Application.InterfaceService;
using Gestión_de_estudiantes_por_asignatura.Core.Domain.Entities;

namespace Gestión_de_estudiantes_por_asignatura.Core.Application.EntityService
{
    public class AsignaturaService : IAsignaturaService
    {
        private readonly Asignatura _asignatura;

        public AsignaturaService()
        {
            // Inicialización de la asignatura base y su grupo inicial en memoria
            _asignatura = new Asignatura("TDS-010", "Estructura de Datos");
            _asignatura.AgregarGrupo(new Grupo("Grupo 01"));
        }

        // Métodos para obtener la asignatura y el grupo por defecto (Grupo 01)
        public Asignatura ObtenerAsignatura() => _asignatura;

        public Grupo ObtenerGrupoDefecto() => _asignatura.Grupos[0];
    }
}
