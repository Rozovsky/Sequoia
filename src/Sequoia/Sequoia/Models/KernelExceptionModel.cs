using Sequoia.Interfaces;

namespace Sequoia.Models
{
    public class KernelExceptionModel : IKernelException
    {
        public int Code { get; private set; }
        public string Type { get; private set; }
        public string Description { get; private set; }
        public dynamic Details { get; set; }
    }
}
