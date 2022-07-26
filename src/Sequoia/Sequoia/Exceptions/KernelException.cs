using Sequoia.Constants;

namespace Sequoia.Exceptions
{
    public class KernelException : Exception
    {
        public int Code { get; private set; }
        public new string Message { get; private set; }
        public string Type { get; private set; }
        public new dynamic Data { get; set; }

        public KernelException(int code, string message, string type = DefaultExceptionType.KernelError, dynamic data = null)
        {
            Code = code;
            Message = message;
            Type = type;
            Data = data;
        }
    }
}
