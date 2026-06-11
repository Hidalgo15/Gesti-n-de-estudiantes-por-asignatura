using Gestión_de_estudiantes_por_asignatura.Core.Application.EntityService;
using Gestión_de_estudiantes_por_asignatura.Core.Application.InterfaceService;
using Gestión_de_estudiantes_por_asignatura.Core.Domain;
using Gestión_de_estudiantes_por_asignatura.Core.Domain.Entities;
using Gestión_de_estudiantes_por_asignatura.Presentation.MenuInterface;

namespace Gestión_de_estudiantes_por_asignatura.Presentation.Menu
{
    public class MenuConsole : IMenuInterface
    {
        private readonly IAsignaturaService _asignaturaService;

        public MenuConsole(IAsignaturaService asignaturaService)
        {
            _asignaturaService = asignaturaService;
        }

        public void Renderizar()
        {
            var asignatura = _asignaturaService.ObtenerAsignatura();
            var grupo = _asignaturaService.ObtenerGrupoDefecto();
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("==================================================================");
                Console.WriteLine($" GESTIÓN ACADÉMICA - {asignatura.Codigo}: {asignatura.Nombre}");
                Console.WriteLine("==================================================================");
                Console.ResetColor();
                Console.WriteLine("1. Registrar Alumno en el Grupo 01");
                Console.WriteLine("2. Cargar Calificaciones Parciales");
                Console.WriteLine("3. Desplegar Reporte Analítico de Calificaciones");
                Console.WriteLine("4. Salir");
                Console.Write("\nSeleccione una opción: ");

                switch (Console.ReadLine())
                {
                    case "1": MenuAgregarEstudiante(grupo); break;
                    case "2": MenuRegistrarNotas(grupo); break;
                    case "3": MenuMostrarReporte(grupo); break;
                    case "4": continuar = false; break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opción inválida. Presione una tecla...");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void MenuAgregarEstudiante(Grupo grupo)
        {
            Console.Clear();
            Console.WriteLine(">>> REGISTRAR NUEVO ESTUDIANTE <<<");
            Console.Write("Matrícula (Ej: 2023-1003): ");
            string matricula = Console.ReadLine();
            Console.Write("Nombre Completo: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Modalidad académica:\n1. Presencial\n2. A Distancia");
            Console.Write("Opción: ");
            string mod = Console.ReadLine();

            Estudiante estudiante = mod switch
            {
                "1" => new EstudiantePresencial(matricula, nombre),
                "2" => new EstudianteDistancia(matricula, nombre),
                _ => null
            };

            if (estudiante == null)
            {
                Console.WriteLine("\nModalidad incorrecta. Operación abortada.");
                Console.ReadKey();
                return;
            }

            OperationResult resultado = grupo.AgregarEstudiante(estudiante);
            Console.ForegroundColor = resultado.Success ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine($"\n{resultado.Message}");
            Console.ResetColor();
            Console.ReadKey();
        }

        private void MenuRegistrarNotas(Grupo grupo)
        {
            Console.Clear();
            Console.WriteLine(">>> REGISTRAR CALIFICACIONES <<<");
            Console.Write("Ingrese la matrícula del alumno: ");
            string matricula = Console.ReadLine();

            Estudiante estudiante = grupo.BuscarEstudiante(matricula);
            if (estudiante == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Estudiante no registrado.");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"\nAlumno: {estudiante.Nombre}");
            Console.WriteLine("1. Evaluaciones / Exámenes\n2. Prácticas / Entregables");
            Console.Write("Seleccione el componente de evaluación: ");
            string tipo = Console.ReadLine();

            Console.Write("Calificación obtenida (0 - 100): ");
            if (double.TryParse(Console.ReadLine(), out double nota) && nota >= 0 && nota <= 100)
            {
                if (tipo == "1") estudiante.RegistrarExamen(nota);
                else if (tipo == "2") estudiante.RegistrarPractica(nota);
                Console.WriteLine("Nota registrada de forma correcta.");
            }
            else Console.WriteLine("Entrada de nota no válida.");

            Console.ReadKey();
        }

        private void MenuMostrarReporte(Grupo grupo)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=====================================================================================");
            Console.WriteLine($" LISTADO OFICIAL DE CALIFICACIONES - {grupo.CodigoGrupo}");
            Console.WriteLine("=====================================================================================");
            Console.ResetColor();

            var estudiantes = grupo.ObtenerEstudiantes();
            if (estudiantes.Count == 0) Console.WriteLine("El grupo no cuenta con estudiantes registrados.");
            else
            {
                foreach (var e in estudiantes) Console.WriteLine(e.ToString());

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n-------------------------------------------------------------------------------------");
                Console.WriteLine($"Índice de Aprobación del Grupo: {grupo.CalcularPorcentajeAprobados():F2}%");
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.ResetColor();
            }
            Console.ReadKey();
        }

    }
}
