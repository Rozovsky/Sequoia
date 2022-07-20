namespace Sequoia.Kernel.Exceptions
{
    internal class KernelException : Exception
    {
        public int Code { get; private set; }
        public string ErrorMessage { get; private set; }
        public string ErrorType { get; private set; }

        public KernelException(int code, string errorMessage, string errorType = "DEFAULT_ERROR")
        {
            Code = code;
            ErrorMessage = errorMessage;
            ErrorType = errorType;
        }
    }
}
