
namespace Gestión_de_estudiantes_por_asignatura.Core.Domain.Entities
{
    public class Asignatura
    {
        public string Codigo { get; private set; }
        public string Nombre { get; private set; }
        public List<Grupo> Grupos { get; private set; }

        public Asignatura(string codigo, string nombre)
        {
            Codigo = codigo;
            Nombre = nombre;
            Grupos = new List<Grupo>();
        }

        public void AgregarGrupo(Grupo grupo) => Grupos.Add(grupo);
    }
}
