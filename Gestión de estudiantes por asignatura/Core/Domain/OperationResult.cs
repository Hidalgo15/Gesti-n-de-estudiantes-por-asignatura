

namespace Gestión_de_estudiantes_por_asignatura.Core.Domain
{
    public class OperationResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public dynamic Data { get; set; }

        public static OperationResult BuildSuccess(string message, dynamic data = null)
        {
            return new OperationResult { Success = true, Message = message, Data = data };
        }

        public static OperationResult BuildFailure(string message)
        {
            return new OperationResult { Success = false, Message = message, Data = null };
        }
    }
}
