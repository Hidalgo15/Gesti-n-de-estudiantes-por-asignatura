using Gestión_de_estudiantes_por_asignatura.Core.Application.EntityService;
using Gestión_de_estudiantes_por_asignatura.Presentation.Menu;
using Gestión_de_estudiantes_por_asignatura.Presentation.MenuInterface;

namespace Gestión_de_estudiantes_por_asignatura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Inicialización de dependencias de la arquitectura limpia
            AsignaturaService coreService = new AsignaturaService();
            MenuConsole UI = new MenuConsole(coreService);

            IMenuInterface menuPrincipal = new MenuConsole(coreService);

            // Ejecución del hilo de presentación
            menuPrincipal.Renderizar();
        }
    }
}
