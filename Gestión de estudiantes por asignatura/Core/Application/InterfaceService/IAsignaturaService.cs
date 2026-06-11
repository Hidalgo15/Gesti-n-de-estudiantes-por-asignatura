
using Gestión_de_estudiantes_por_asignatura.Core.Domain.Entities;

namespace Gestión_de_estudiantes_por_asignatura.Core.Application.InterfaceService
{
    public interface IAsignaturaService
    {
        Asignatura ObtenerAsignatura();
        Grupo ObtenerGrupoDefecto();
    }
}
