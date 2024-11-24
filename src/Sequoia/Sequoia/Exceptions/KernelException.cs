using Sequoia.Constants;
using Sequoia.Interfaces;

namespace Sequoia.Exceptions;

public abstract class KernelException : Exception, IKernelException
{
    public int Code { get; private set; }
    public string Type { get; private set; }
    public string Description { get; private set; }
    public dynamic Details { get; set; }

    protected KernelException(int code, string description, string type = DefaultExceptionType.KernelError, dynamic details = null)
    {
        Code = code;
        Type = type;
        Description = description ?? base.Message;
        Details = details;
    }
}